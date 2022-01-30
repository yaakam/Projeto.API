using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Dominio.Extensoes;
using Projeto.Dominio.ObjetosDeValor;
using System.Threading.Tasks;

namespace Projeto.API.Controladores
{
    public class ControllerBase : Controller
    {
        protected async virtual Task<IActionResult> Responder(MensagemDeResposta resposta)
        {
            if (!resposta.Mensagens.TemErros())
            {
                return StatusCode(StatusCodes.Status200OK, resposta); //200 -> Processado e retornado com sucesso
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, resposta); //422 -> Requisição recebida porém com correções a serem feitas
            }
        }
    }
}
