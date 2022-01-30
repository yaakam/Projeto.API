using System.Collections.Generic;

namespace Projeto.Utilitarios.ORM.NHibernate
{
    public static class NHibernateConfiguracoes
    {
        public static string Dialect { get; set; }
        public static string DriverClass { get; set; }
        public static DadosConexao Connection { get; set; }
        public static IList<string> Assembly { get; set; } = new List<string>();
        public static string Timeout { get; set; }
    }
}
