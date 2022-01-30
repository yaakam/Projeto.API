using Projeto.Utilitarios.ORM.NHibernate;

namespace Projeto.API.Configuracoes
{
    public static class ConstrutorDeConexao
    {
        public static void Construir()
        {
            NHibernateConfiguracoes.Dialect = "NHibernate.Dialect.MsSql2012Dialect";
            //NHibernateConfiguracoes.DriverClass = "NHibernate.Driver.SqlClientDriver";
            NHibernateConfiguracoes.Timeout = "5000";
            NHibernateConfiguracoes.Connection =
                new DadosConexao
                {
                    Server = "LOCALHOST\\SQLSERVER",
                    Port = string.Empty,
                    Database = "BDPROJETO",
                    User = "SA",
                    Password = "M1n3Rv@7"
                };
                NHibernateConfiguracoes.Assembly.Add("Projeto.Repositorio");

        }
    }
}
