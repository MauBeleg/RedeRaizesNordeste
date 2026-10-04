using RaizesNordeste.Api.DTOs;

namespace RaizesNordeste.Api.Middlewares
{
    public class TratamentoErrosMiddleware
    {
        private readonly RequestDelegate _next;

        public TratamentoErrosMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await TratarExcecaoAsync(context, exception);
            }
        }


        private static async Task TratarExcecaoAsync(HttpContext context, Exception exception)
        {
            ErroRespostaDTO erroRespostaDTO = new ErroRespostaDTO
            {
                Status = 500,
                Erro = "Erro Interno",
                Mensagem = "Ocorreu um erro interno no servidor"
            };


            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(erroRespostaDTO);
        }


    }
}