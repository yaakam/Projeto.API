using Projeto.Dominio.Entidades;
using Projeto.Dominio.Repositorios;
using Projeto.Utilitarios.InjecaoDeDependencia.DryIoc;
using System.Threading.Tasks;

namespace Projeto.Dominio.Servicos
{
    public class SelecionarTodosOsClientesServico: ServicoBase<Cliente>
    {
        protected override async Task DoProcess()
        {
            var repository = DIContainer.CreateInstanceWithSession<IClienteRepositorio>();
            Dados = repository.SelecionarTodosOsClientes();
        }
    }
}
