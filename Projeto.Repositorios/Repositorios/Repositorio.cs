using NHibernate;
using Projeto.Dominio.Repositorios;
using Projeto.Utilitarios.ORM.NHibernate;
using System;
using System.Collections.Generic;

namespace Projeto.Repositorio.Repositorios
{
    public class Repositorio<obj> : IRepositorio<obj>
    {
        #region "Propriedades"
        protected ISession Sessao { get; set; }
        #endregion

        #region "Construtor"
        public Repositorio(ISessaoGenerica sessao)
        {
            if (sessao == null) throw new Exception("A sessão não pode ser nula!");
            Sessao = ((NHibernateSessao)sessao).Session;
        }
        #endregion

        #region "Persistência externa"
        public obj Salvar(obj entidade)
        {
            try
            {
                SalvarObjeto(entidade);
                return entidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public IEnumerable<obj> Salvar(IEnumerable<obj> lista)
        {
            try
            {
                foreach (var entity in lista)
                    SalvarObjeto(entity);                
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
        
        public bool Excluir(obj entidade)
        {
            try
            {
                ExcluirObjeto(entidade);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(IEnumerable<obj> lista)
        {
            try
            {
                foreach (var entidade in lista)                
                    ExcluirObjeto(entidade);              
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void RemoverDaSessao(obj entity)
        {
            Sessao.Evict(entity);
        }

        public void RemoverDaSessao(IEnumerable<obj> list)
        {
            foreach (var item in list)
            {
                Sessao.Evict(item);
            }
        }

        #endregion     

        #region "Persistênca interna"
        private void SalvarObjeto(obj entity)
        {
            Sessao.SaveOrUpdate(entity);
        }

        private void ExcluirObjeto(obj entity)
        {
            Sessao.Delete(entity);
        }

        #endregion
    }
}
