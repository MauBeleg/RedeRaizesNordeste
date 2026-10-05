using System;
using System.Collections.Generic;
using System.Text;
using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Application.Repositories
{
    public interface IAuditoriaRepository
    {
        Task SalvarAuditoria(Auditoria auditoria);


        Task<List<Auditoria>> ListarAuditorias(long? usuarioId, string? acao, string? entidade, long? registroId); //auditorias com filtros

    }
}