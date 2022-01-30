using Projeto.Dominio.Repositorios;
using Projeto.Utilitarios.InjecaoDeDependencia.DryIoc;
using System;
using System.Threading.Tasks;

namespace Projeto.Dominio.Servicos
{
    public class SelecionarClientePeloCodigoServico: ServicoBase<Guid>
    {
        protected override async Task RealizarProcesso(Guid codigo)
        {
            var repository = DIContainer.CreateInstanceWithSession<IClienteRepositorio>();
            Dados = repository.SelecionarPeloCodigo(codigo);
        }
    }
}
