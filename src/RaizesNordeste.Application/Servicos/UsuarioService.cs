using RaizesNordeste.Application.Models;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Application.Security;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaizesNordeste.Application.Servicos
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly ISenhaHasher _senhaHasher;

        public UsuarioService(
            IUsuarioRepository usuarioRepository, IUnidadeRepository unidadeRepository, ISenhaHasher senhaHasher)
        {
            _usuarioRepository = usuarioRepository;
            _unidadeRepository = unidadeRepository;
            _senhaHasher = senhaHasher;
        }

        //metodos do service de usuários

        public async Task<ResultadoOperacao> CriarCliente(string nome, string email, string senha, string cpf, DateTime dataNascimento)
        {
            var emailExiste = await _usuarioRepository.VerificarEmail(email);

            if (emailExiste)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Já existe um usuário cadastrado com este e-mail."
                };
            }

            var cpfExiste = await _usuarioRepository.VerificarCpf(cpf);

            if (cpfExiste)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Já existe um usuário cadastrado com este CPF."
                };
            }

            var usuario = new Usuario()
            {
                Nome = nome,
                Email = email,
                Cpf = cpf,
                DataNascimento = dataNascimento.Date,
                SenhaHash = _senhaHasher.GerarHash(senha),
                PerfilId = 4,
                Ativo = true
            };

            await _usuarioRepository.CreateUsuario(usuario);

            return new ResultadoOperacao
            {
                Resultado = true,
                Mensagem = "Usuário criado com sucesso."
            };
        }


        public async Task<ResultadoOperacao> CriarFuncionario(string nome, string email, string senha, string cpf, DateTime dataNascimento, long unidadeId, SetorFuncionario setor)
        {
            var emailExiste = await _usuarioRepository.VerificarEmail(email);

            if (emailExiste)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Já existe um usuário cadastrado com este e-mail."
                };
            }

            var cpfExiste = await _usuarioRepository.VerificarCpf(cpf);

            if (cpfExiste)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Já existe um usuário cadastrado com este CPF."
                };
            }

            var unidade = await _unidadeRepository.BuscarUnidadePorId(unidadeId);

            if (unidade == null)
            {
                return new ResultadoOperacao
                {
                    Resultado = false,
                    Mensagem = "Unidade não encontrada."
                };
            }

            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Cpf = cpf,
                DataNascimento = dataNascimento.Date,
                SenhaHash = _senhaHasher.GerarHash(senha),
                PerfilId = 3,
                UnidadeId = unidadeId,
                Setor = setor,
                Ativo = true
            };

            await _usuarioRepository.CreateUsuario(usuario);

            return new ResultadoOperacao
            {
                Resultado = true,
                Mensagem = "Funcionário criado com sucesso."
            };
        }


        //metodos para buscar usuarios
        public async Task<List<Usuario>> BuscarUsuarios()
        {
            return await _usuarioRepository.BuscarUsuarios();
        }


        //metodo para buscar usuario pelo id
        public async Task<Usuario?> BuscarUsuarioPorId(long id)
        {
            return await _usuarioRepository.BuscarUsuarioPorId(id);
        }
    }
}
