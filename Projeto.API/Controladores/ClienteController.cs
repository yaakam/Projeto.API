using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Dominio.Entidades;
using Projeto.Dominio.Servicos;
using System;
using System.Threading.Tasks;

namespace Projeto.API.Controladores
{
    /// <summary>
    /// Controlador do CRUD de clientes
    /// </summary>

    [Route("api/cliente/")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        /// <summary>
        /// Retorna todos os clientes sem filtros.
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet]
        [Route("selecionarTodos")]
        public async Task<IActionResult> SelecionarTodos()
        {
            return await Responder(await new SelecionarTodosOsClientesServico().Process());
        }

        /// <summary>
        /// Retorna o cliente pelo código informado.
        /// </summary>
        /// <returns>Entidade cliente</returns>
        [HttpGet]
        [Route("selecionarPorCodigo/{codigo}")]
        public async Task<IActionResult> selecionarPorCodigo(Guid codigo)
        {
            return await Responder(await new SelecionarClientePeloCodigoServico().Process(codigo));
        }

        /// <summary>
        /// Salva ou atualiza um cliente enviado.
        /// </summary>
        /// <param name="cliente">Cliente que será atualizado</param>
        /// <returns>Entidade do cliente atualizada</returns>
        [HttpPost]
        [Route("salvar")]
        public async Task<IActionResult> Salvar([FromBody] Cliente cliente)
        {
            return await Responder(await new SalvarClienteServico().Process(cliente));
        }

        /// <summary>
        /// Exclui o registro pelo código.
        /// </summary>
        /// <param name="codigo">Código do cliente que será exluido</param>
        /// <returns>Erro ou sucesso</returns>
        [HttpDelete]
        [Route("excluir/{codigo}")]
        public async Task<IActionResult> Excluir(Guid codigo)
        {
            return await Responder(await new ExcluirClienteServico().Process(codigo));
        }

        
    }
}
