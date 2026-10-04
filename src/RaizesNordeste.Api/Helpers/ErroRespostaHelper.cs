using RaizesNordeste.Api.DTOs;

namespace RaizesNordeste.Api.Helpers
{
    public static class ErroRespostaHelper
    {
        public static ErroRespostaDTO Criar(int status, string erro, string mensagem)
        {
            return new ErroRespostaDTO
            {
                Status = status,
                Erro = erro,
                Mensagem = mensagem
            };
        }

        public static ErroRespostaDTO RequisicaoInvalida(string mensagem) => Criar(400, "Requisição inválida", mensagem);

        public static ErroRespostaDTO NaoAutenticado(string mensagem) => Criar(401, "Não autenticado", mensagem);

        public static ErroRespostaDTO AcessoNegado(string mensagem) => Criar(403, "Acesso negado", mensagem);

        public static ErroRespostaDTO NaoEncontrado(string mensagem) => Criar(404, "Recurso não encontrado", mensagem);

        public static ErroRespostaDTO Conflito(string mensagem) => Criar(409, "Conflito", mensagem);

        public static ErroRespostaDTO RegraNegocio(string mensagem) => Criar(422, "Regra de negócio não atendida", mensagem);
    }
}