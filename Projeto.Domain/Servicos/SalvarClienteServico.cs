using Projeto.Dominio.Entidades;
using Projeto.Dominio.Enumeradores;
using Projeto.Dominio.ObjetosDeValor;
using Projeto.Dominio.Repositorios;
using Projeto.Utilitarios.InjecaoDeDependencia.DryIoc;
using System.Threading.Tasks;

namespace Projeto.Dominio.Servicos
{
    public class SalvarClienteServico : ServicoBase<Cliente>
    {
        protected override async Task DoProcess(Cliente entidade)
        {
            var repositorio = DIContainer.CreateInstanceWithSession<IClienteRepositorio>();
            Dados = repositorio.Salvar(entidade);
            if (Dados != null) 
                Mensagens.Add(new Mensagem("Salvo com sucesso.", TipoDeMensagemEnumerador.Informacao));
        }
    }
}
