using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Projeto.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Dominio.Manipuladores
{
    public class TratamentoDeExececaoGlobal : IMiddleware
    {
        private readonly ILogger<TratamentoDeExececaoGlobal> _logger;

        public TratamentoDeExececaoGlobal(ILogger<TratamentoDeExececaoGlobal> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("Ocorreu um erro inesperado: ", ex));
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            const int statusCode = StatusCodes.Status500InternalServerError;

            var json = JsonConvert.SerializeObject(new MensagemDeResposta
            {
                Status = false,
                Dados = "Ocorreu um erro não tratado.",
                Mensagens = new List<Mensagem>(){{ new Mensagem(exception.Message)}}
            });

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(json);
        }
    }
}
