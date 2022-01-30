using Projeto.Utilitarios.ORM.NHibernate;

namespace Projeto.API.Configuracoes
{
    public static class ConstrutorDeConexao
    {
        public static void Construir()
        {
            NHibernateConfiguracoes.Dialect = "NHibernate.Dialect.MsSql2012Dialect";
            NHibernateConfiguracoes.Timeout = "5000";
            NHibernateConfiguracoes.Connection =
                new DadosConexao
                {
                    Server = "{Servidor}",
                    Port = "{Porta}",
                    Database = "{Banco de dados}",
                    User = "{Usuário}",
                    Password = "{Senha}"
                };
                NHibernateConfiguracoes.Assembly.Add("Projeto.Repositorio");

        }
    }
}
