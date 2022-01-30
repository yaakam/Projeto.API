namespace Projeto.Utilitarios.ORM.NHibernate
{
    public static class NHibernateFabricaDeSessoes 
    {
        private static ISessaoGenerica _Session;

        public static ISessaoGenerica Sessao()
        {
            if (_Session == null || !_Session.IsSessionActive || !_Session.IsConnectionActive)
            {
                _Session = new NHibernateSessao();
                _Session.OpenSession();
            }

            if (!_Session.IsTransactionActive)
            {
                _Session.BeginTransaction();
            }

            return _Session;
        }

    }
}
