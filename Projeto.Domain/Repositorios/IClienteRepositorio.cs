using Projeto.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Projeto.Dominio.Repositorios
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        IList<Cliente> SelecionarTodosOsClientes();

        Cliente SelecionarPeloCodigo(Guid id);
    }
}
