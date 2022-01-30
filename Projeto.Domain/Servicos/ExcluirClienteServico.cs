using Projeto.Dominio.Enumeradores;
using Projeto.Dominio.ObjetosDeValor;
using Projeto.Dominio.Repositorios;
using Projeto.Utilitarios.InjecaoDeDependencia.DryIoc;
using System;
using System.Threading.Tasks;

namespace Projeto.Dominio.Servicos
{
    public class ExcluirClienteServico : ServicoBase<Guid>
    {
        protected override async Task RealizarProcesso(Guid codigo)
        {
            var repositorioDoCliente = DIContainer.CreateInstanceWithSession<IClienteRepositorio>();
            var cliente = repositorioDoCliente.SelecionarPeloCodigo(codigo);
            var sucesso = repositorioDoCliente.Excluir(cliente);
            if (sucesso) 
                Mensagens.Add(new Mensagem("Excluido com sucesso", TipoDeMensagemEnumerador.Informacao));         
        }
    }
}
