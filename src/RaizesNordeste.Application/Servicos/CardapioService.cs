using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Servicos
{
    public class CardapioService
    {

        private readonly ICardapioRepository _cardapioRepository;


        public CardapioService(ICardapioRepository cardapioRepository)
        {
            _cardapioRepository = cardapioRepository;
        }


        public async Task<Cardapio?> BuscarCardapioporUnidade(long unidadeId)
        {
            return await _cardapioRepository.BuscarCardapioPorUnidade(unidadeId);
        }



    }
}
