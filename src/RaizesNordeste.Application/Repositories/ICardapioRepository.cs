using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Repositories
{
    public interface ICardapioRepository
    {

        Task<Cardapio?> BuscarCardapioPorUnidade (long unidadeId);

    }
}
