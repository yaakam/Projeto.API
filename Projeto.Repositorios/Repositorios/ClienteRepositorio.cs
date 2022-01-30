using Projeto.Dominio.Entidades;
using Projeto.Dominio.Repositorios;
using Projeto.Utilitarios.ORM.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Repositorio.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ISessaoGenerica sessao) : base(sessao)
        {
        }

        public Cliente SelecionarPeloCodigo(Guid codigo)
        {
            return Sessao.Query<Cliente>().FirstOrDefault(F => F.Codigo == codigo);
        }

        public IList<Cliente> SelecionarTodosOsClientes()
        {
            return Sessao.Query<Cliente>().ToList();
        }
    }
}
