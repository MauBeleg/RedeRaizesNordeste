using RaizesNordeste.Application.Models;
using RaizesNordeste.Application.Repositories;
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

        public PedidoService(IUsuarioRepository usuarioRepository, IUnidadeRepository unidadeRepository, EstoqueService estoqueService)
        {
            _usuarioRepository = usuarioRepository;
            _unidadeRepository = unidadeRepository;
            _estoqueService = estoqueService;
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

            var estoqueDisponivel = await _estoqueService.VerificarDisponibilidadePedido(unidade.Id, input.Itens);

            if (!estoqueDisponivel)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Estoque indisponível para o pedido"
                };
            }


            return new ResultadoOperacao
            {
                Resultado = true,
                Mensagem = "Pedido válido para criação"
            };

        }


    }
}
