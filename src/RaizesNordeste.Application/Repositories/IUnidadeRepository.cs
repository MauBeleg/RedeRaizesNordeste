using RaizesNordeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Repositories
{
    public interface IUnidadeRepository
    {
        Task<List<Unidade>> BuscarUnidadesAtivas();

        Task<Unidade?> BuscarUnidadePorId(long id);
    }
}
