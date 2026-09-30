using RaizesNordeste.Application.Models;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Servicos
{
    public class PedidoService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly EstoqueService _estoqueService;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IUsuarioRepository usuarioRepository, IUnidadeRepository unidadeRepository, EstoqueService estoqueService, 
            IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _unidadeRepository = unidadeRepository;
            _estoqueService = estoqueService;
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }


        public async Task<ResultadoOperacao> ValidarCriacaoPedido(CriarPedidoInput input)
        {
            var cliente = await _usuarioRepository.BuscarUsuarioPorId(input.ClienteId);

            if (cliente == null) //Verifica se o cliente existe
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Usuário inexistente"
                };
            }

            if (!cliente.Ativo || cliente.PerfilId != 4) //verifica se o cliente é ativo e se realmente é um cliente
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Cliente inválido ou inativo"
                };
            }


            var usuarioAutenticado = await _usuarioRepository.BuscarUsuarioPorId(input.UsuarioAutenticadoId); //Verifica quem é o usuário que fez o pedido

            if (usuarioAutenticado == null) 
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Usuário inexistente"
                };
            }

            if (!usuarioAutenticado.Ativo || usuarioAutenticado.PerfilId is not (2 or 3 or 4)) // Garante que o usuário está ativo e possui perfil autorizado
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Usuário inválido para operação ou inativo"
                };
            }

            if (usuarioAutenticado.PerfilId == 4 && usuarioAutenticado.Id != cliente.Id) //Garante que o usuário não é um cliente criando pedido para outro cliente
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Cliente do pedido inválido"
                };
            }


            var unidade = await _unidadeRepository.BuscarUnidadePorId(input.UnidadeId);

            if (unidade == null)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Unidade inválida"
                };
            }

            if (!Enum.IsDefined(input.CanalPedido)) //Verifica se o canal de pedido é válido
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Canal do pedido inválido"
                };
            }

            if (input.Itens.Count <= 0)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Não existem itens no pedido"
                };
            }

            foreach (var item in input.Itens)
            {
                if (item.Quantidade <= 0)
                {
                    return new ResultadoOperacao
                    {
                        Resultado = false,
                        Mensagem = "Cada item deve ter pelo menos 1 unidade"
                    };
                }


                if (item.ProdutoId <= 0)
                {
                    return new ResultadoOperacao
                    {
                        Resultado = false,
                        Mensagem = "Produto inválido"
                    };
                }

            }


            var itensAgrupados = new Dictionary<long, int>();

            foreach (var item in input.Itens)
            {
                if (itensAgrupados.ContainsKey(item.ProdutoId))
                {
                    itensAgrupados[item.ProdutoId] += item.Quantidade;
                }
                else
                {
                    itensAgrupados.Add(item.ProdutoId, item.Quantidade);
                }
            }

            var itensNormalizados = new List<CriarPedidoItemInput>();

            foreach (var item in itensAgrupados)
            {
                itensNormalizados.Add(new CriarPedidoItemInput
                {
                    ProdutoId = item.Key,
                    Quantidade = item.Value
                });
            }

            var pedidoItens = new List<PedidoItem>();
            decimal subtotal = 0;
            var pedidoItensOutput = new List<PedidoItemOutput>();

            foreach (var item in itensAgrupados)
            {
                var produto = await _produtoRepository.BuscarProdutoPorId(item.Key);

                if (produto == null)
                {
                    return new ResultadoOperacao
                    {
                        Resultado = false,
                        Mensagem = "Produto inválido"
                    };
                }

                var valorTotalItem = item.Value * produto.ValorUnitario;

                var pedidoItem = new PedidoItem
                {
                    ProdutoId = item.Key,
                    Quantidade = item.Value,
                    ValorUnitario = produto.ValorUnitario,
                    ValorTotal = valorTotalItem,
                    CriadoPor = input.UsuarioAutenticadoId,
                    DataCriacao = DateTime.UtcNow
                };

                var pedidoItemOutput = new PedidoItemOutput
                {
                    Produto = produto.Nome,
                    Quantidade = item.Value,
                    ValorUnitario = produto.ValorUnitario,
                    ValorTotal = valorTotalItem
                };

                pedidoItensOutput.Add(pedidoItemOutput);
                pedidoItens.Add(pedidoItem);
                subtotal += valorTotalItem;

            }

            var estoqueDisponivel = await _estoqueService.VerificarDisponibilidadePedido(unidade.Id, itensNormalizados);

            if (!estoqueDisponivel)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Estoque indisponível para o pedido"
                };
            }

            decimal desconto = 0;

            decimal valorTotal = subtotal - desconto;

            var pedido = new Pedido
            {
                ClienteId = input.ClienteId,
                UnidadeId = input.UnidadeId,
                CanalPedido = input.CanalPedido,
                Subtotal = subtotal,
                Desconto = desconto,
                ValorTotal = valorTotal,
                Status = StatusPedido.AguardandoPagamento,
                CriadoPor = usuarioAutenticado.Id,
                DataCriacao = DateTime.UtcNow,
                Itens = pedidoItens
            };

            await _pedidoRepository.SalvarPedido(pedido);


            var pedidoCriadoOutput = new PedidoCriadoOutput
            {
                Id = pedido.Id,
                Cliente = cliente.Nome,
                Unidade = unidade.Nome,
                CanalPedido = pedido.CanalPedido,
                Subtotal = pedido.Subtotal,
                Desconto = pedido.Desconto,
                ValorTotal = pedido.ValorTotal,
                Status = pedido.Status,
                DataCriacao = pedido.DataCriacao,
                Itens = pedidoItensOutput
            };


            return new ResultadoOperacao
            {
                Resultado = true,
                Mensagem = $"Pedido criado com sucesso:",
                Objeto = pedidoCriadoOutput
            };

        }


    }
}
