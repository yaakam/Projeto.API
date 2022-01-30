using DryIoc;
using Projeto.Utilitarios.ORM.NHibernate;
using System;

namespace Projeto.Utilitarios.InjecaoDeDependencia.DryIoc
{
    public static class DIContainer
    {
        private const string SESSION_REPOSITORY = "sessao";

        private static Container Container = new Container(F => F.WithDefaultReuse(Reuse.Singleton));

        public static void AddDependencyInjection<From, To>() where To : From
        {
            Container.Register<From, To>();
        }

        public static void AddDependencyInjection(Type from, object to)
        {
            Container.RegisterInstance(from, to);
        }

        public static T CreateInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static T CreateInstance<T>(string key, object value)
        {
            return Container.Resolve<T>(new object[] { key, value });
        }

        public static T CreateInstanceWithSession<T>()
        {
            return Container.Resolve<T>(new object[] { SESSION_REPOSITORY, NHibernateFabricaDeSessoes.Sessao() });
        }
    }
}
