using RaizesNordeste.Application.Models;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace RaizesNordeste.Application.Servicos
{
    public class EstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;


        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<bool> VerificarDisponibilidade(long unidadeId, long produtoId, int quantidadePedida)
        {
            if (quantidadePedida <= 0)
            {
                return false;
            }

            var produto = await _estoqueRepository.BuscarProdutoComConsumo(produtoId);

            if (produto == null)
            {
                return false;
            }

            var estoque = await _estoqueRepository.BuscarEstoqueDaUnidade(unidadeId);

            if (estoque == null)
            {
                return false;
            }


            if (produto.Receita != null)
            {

                if (produto.Receita.Itens.Count <= 0)
                {
                    return false;
                }


                foreach (var itemReceita in produto.Receita.Itens)
                {

                    var saldo = await _estoqueRepository.BuscarSaldo(estoque.Id, itemReceita.ItemInventarioId);
                    var qntdNecessaria = itemReceita.Quantidade * quantidadePedida;


                    if (saldo == null)
                    {
                        return false;
                    }


                    if ((saldo.Quantidade - saldo.QuantidadeReservada) < qntdNecessaria)
                    {
                        return false;
                    }

                }
            }
            else
            {
                if (produto.ItensInventario.Count <= 0)
                {
                    return false;
                }

                foreach (var produtoItem in produto.ItensInventario)
                {
                    var saldo = await _estoqueRepository.BuscarSaldo(estoque.Id, produtoItem.ItemInventarioId);
                    var qntdNecessaria = produtoItem.QuantidadeConsumo * quantidadePedida;


                    if (saldo == null)
                    {
                        return false;
                    }


                    if ((saldo.Quantidade - saldo.QuantidadeReservada) < qntdNecessaria)
                    {
                        return false;
                    }
                }

            }

            return true;
        }



        public async Task<bool> VerificarDisponibilidadePedido(long unidadeId, List<CriarPedidoItemInput> itens)
        {
            var estoque = await _estoqueRepository.BuscarEstoqueDaUnidade(unidadeId);

            if (estoque == null)
            {
                return false;
            }

            var consumoTotal = new Dictionary<long, decimal>();

            foreach (var item in itens)
            {
                var produto = await _estoqueRepository.BuscarProdutoComConsumo(item.ProdutoId);

                if (produto == null)
                {
                    return false;
                }

                if (produto.Receita != null)
                {

                    if (produto.Receita.Itens.Count <= 0)
                    {
                        return false;
                    }

                    foreach (var itemReceita in produto.Receita.Itens)
                    {
                        var qntdNecessaria = itemReceita.Quantidade * item.Quantidade;

                        if (consumoTotal.ContainsKey(itemReceita.ItemInventarioId))
                        {
                            consumoTotal[itemReceita.ItemInventarioId] += qntdNecessaria;
                        }
                        else
                        {
                            consumoTotal.Add(itemReceita.ItemInventarioId, qntdNecessaria);
                        }
                    }
                }
                else
                {

                    if (produto.ItensInventario.Count <= 0)
                    {
                        return false;
                    }

                    foreach (var produtoItem in produto.ItensInventario)
                    {
                        var qntdNecessaria = produtoItem.QuantidadeConsumo * item.Quantidade;

                        if (consumoTotal.ContainsKey(produtoItem.ItemInventarioId))
                        {
                            consumoTotal[produtoItem.ItemInventarioId] += qntdNecessaria;
                        }
                        else
                        {
                            consumoTotal.Add(produtoItem.ItemInventarioId, qntdNecessaria);
                        }


                        
                    }
                }

            }

            foreach (var consumo in consumoTotal)
            {
                var saldo = await _estoqueRepository.BuscarSaldo(estoque.Id, consumo.Key);

                if (saldo == null)
                {
                    return false;
                }

                if ((saldo.Quantidade - saldo.QuantidadeReservada) < consumo.Value)
                {
                    return false;
                }
            }


            return true;
        }


    }
}
