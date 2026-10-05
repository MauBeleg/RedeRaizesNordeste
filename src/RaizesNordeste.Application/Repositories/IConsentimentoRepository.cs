using System;
using System.Collections.Generic;
using System.Text;
using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Application.Repositories
{
    public interface IConsentimentoRepository
    {
        Task SalvarConsentimento(Consentimento consentimento);
        Task<List<Consentimento>> ListarPorUsuario(long usuarioId);
        Task<List<Consentimento>> ListarTodos(long? usuarioId);
    }
}
