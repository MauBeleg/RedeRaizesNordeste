using System;
using System.Collections.Generic;
using System.Text;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Application.Security;
using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Application.Servicos
{
    public class UnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;
    


    public UnidadeService(
        IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }


    public async Task<List<Unidade>> BuscarUnidadesAtivas()
        {
            return await _unidadeRepository.BuscarUnidadesAtivas();
        }

    public async Task<Unidade?> BuscarUnidadePorId (long id)
        {
            return await _unidadeRepository.BuscarUnidadePorId(id);
        }


    }
}
