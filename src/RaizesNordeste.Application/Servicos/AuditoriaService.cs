using System;
using System.Collections.Generic;
using System.Text;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Application.Services
{
    public class AuditoriaService
    {
        private readonly IAuditoriaRepository _auditoriaRepository;

        public AuditoriaService(IAuditoriaRepository auditoriaRepository)
        {
            _auditoriaRepository = auditoriaRepository;
        }

        public async Task Registrar(long usuarioId, string acao, string entidade, long registroId, string? detalhes = null)
        {
            var auditoria = new Auditoria
            {
                UsuarioId = usuarioId,
                Acao = acao,
                Entidade = entidade,
                RegistroId = registroId,
                Detalhes = detalhes,
                DataCriacao = DateTime.UtcNow
            };

            await _auditoriaRepository.SalvarAuditoria(auditoria);
        }

        public async Task<List<Auditoria>> ListarAuditorias(long? usuarioId, string? acao, string? entidade, long? registroId)
        {
            return await _auditoriaRepository.ListarAuditorias(
                usuarioId,
                acao,
                entidade,
                registroId
            );
        }
    }
}