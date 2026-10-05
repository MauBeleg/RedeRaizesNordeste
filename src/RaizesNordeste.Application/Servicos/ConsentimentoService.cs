using System;
using System.Collections.Generic;
using System.Text;

using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Domain.Entities;

namespace RaizesNordeste.Application.Services
{
    public class ConsentimentoService
    {
        private readonly IConsentimentoRepository _consentimentoRepository;

        public ConsentimentoService(IConsentimentoRepository consentimentoRepository)
        {
            _consentimentoRepository = consentimentoRepository;
        }

        public async Task<Consentimento> RegistrarConsentimento(long usuarioId, string tipoConsentimento, bool aceito)
        {
            if (string.IsNullOrWhiteSpace(tipoConsentimento))
            {
                throw new ArgumentException("O tipo de consentimento deve ser informado.");
            }

            tipoConsentimento = tipoConsentimento.Trim().ToUpperInvariant();

            if (tipoConsentimento != "FIDELIZACAO" && tipoConsentimento != "CAMPANHAS")
            {
                throw new ArgumentException("Tipo de consentimento inválido.");
            }

            var consentimento = new Consentimento
            {
                UsuarioId = usuarioId,
                TipoConsentimento = tipoConsentimento,
                Aceito = aceito,
                CriadoPor = usuarioId,
                DataCriacao = DateTime.UtcNow
            };

            await _consentimentoRepository.SalvarConsentimento(consentimento);

            return consentimento;
        }


        public async Task<List<Consentimento>> ListarPorUsuario(long usuarioId)
        {
            return await _consentimentoRepository.ListarPorUsuario(usuarioId);
        }

        public async Task<List<Consentimento>> ListarTodos(long? usuarioId)
        {
            return await _consentimentoRepository.ListarTodos(usuarioId);
        }
    }
}