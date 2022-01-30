using Projeto.Dominio.Entidades;
using Projeto.Dominio.Enumeradores;
using Projeto.Dominio.ObjetosDeValor;
using Projeto.Dominio.Repositorios;
using Projeto.Utilitarios.InjecaoDeDependencia.DryIoc;
using System.Threading.Tasks;

namespace Projeto.Dominio.Servicos
{
    public class SalvarClienteServico : ServicoBase<ClienteRequisicao>
    {
        protected override async Task RealizarProcesso(ClienteRequisicao entidade)
        {
            var repositorio = DIContainer.CreateInstanceWithSession<IClienteRepositorio>();
            Dados = repositorio.Salvar(entidade.ConverterEmCliente());
            if (Dados != null) 
                Mensagens.Add(new Mensagem("Salvo com sucesso.", TipoDeMensagemEnumerador.Informacao));
        }
    }
}
