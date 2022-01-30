using System.Collections.Generic;

namespace Projeto.Dominio.Repositorios
{
    public interface IRepositorio<obj>  
    {
        obj Salvar(obj entidade);
        IEnumerable<obj> Salvar(IEnumerable<obj> lista);                
        bool Excluir(obj entity);
        bool Excluir(IEnumerable<obj> lista);
        void RemoverDaSessao(obj entidade);
        void RemoverDaSessao(IEnumerable<obj> lista);
    }
}
