using Microsoft.Extensions.Configuration;
using Projeto.Dominio.Repositorios;
using Projeto.Repositorio.Repositorios;
using Projeto.Utilitarios.InjecaoDeDependencia.DryIoc;

namespace Projeto.API.Configuracoes
{
    public static class ConstrutorDeInjecoes
    {
        public static void Construir()
        {
            DIContainer.AddDependencyInjection<IClienteRepositorio, ClienteRepositorio>();
        }
    }
}