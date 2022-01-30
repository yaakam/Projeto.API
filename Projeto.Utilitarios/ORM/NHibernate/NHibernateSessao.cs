using NHibernate;
using NHibernate.Cfg;
using System.Data;

namespace Projeto.Utilitarios.ORM.NHibernate
{
    public class NHibernateSessao : ISessaoGenerica
    {
        #region "Constantes"

        private const string DIALECT = "dialect";
        private const string CONNECTION = "connection.connection_string";
        private const string ISOLATION = "connection.isolation";
        private const string TIME_OUT = "command_timeout";
        private const string DRIVER_CLASS = "connection.driver_class";
        private const string READ_COMMITTED = "ReadCommitted";

        #endregion

        #region "Propriedades"

        public ISession Session { get; private set; }

        public ITransaction Transaction { get; set; }

        public bool IsTransactionActive { get { return Transaction != null && Transaction.IsActive; } }

        public bool IsConnectionActive { get { return Session != null && Session.Connection != null && Session.Connection.State == ConnectionState.Open; } }

        public bool IsSessionActive { get { return Session != null && Session.IsOpen; } }

        #endregion

        #region "Controle da transação"
        public void OpenSession()
        {
            var cfg = new Configuration()
            .SetProperty(DIALECT, NHibernateConfiguracoes.Dialect)            
            .SetProperty(CONNECTION, NHibernateConfiguracoes.Connection.ToString())
            .SetProperty(ISOLATION, READ_COMMITTED)
            .SetProperty(TIME_OUT, NHibernateConfiguracoes.Timeout);

            if (!string.IsNullOrEmpty(NHibernateConfiguracoes.DriverClass))
                cfg.SetProperty(DRIVER_CLASS, NHibernateConfiguracoes.DriverClass);

            foreach (var item in NHibernateConfiguracoes.Assembly)
            {
                cfg.AddAssembly(item);
            }
            
            Session = cfg.BuildSessionFactory().OpenSession();
        }

        public void BeginTransaction()
        {
            if (!IsTransactionActive) Transaction = Session.BeginTransaction();
            
        }

        public void Confirmar()
        {
            Session.Flush();
            if (IsTransactionActive) Transaction.Commit();
        }

        public void Desfazer()
        {
            if (IsTransactionActive) Transaction.Rollback();
        }      

        public void Flush()
        {
            if (IsSessionActive) Session.Flush();
        }

        public void Clear()
        {
            if (IsSessionActive) Session.Clear();
        }

        public void Dispose()
        {
            if (IsTransactionActive)
            {
                Transaction.Rollback();
                Transaction = null;
            }
            if (IsSessionActive) Session.Connection.Close();
        }

        public object Clone()
        {
            return (NHibernateSessao)MemberwiseClone();
        }

        #endregion
    }
}