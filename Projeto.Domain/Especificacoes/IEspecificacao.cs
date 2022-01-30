namespace Projeto.Dominio.Especificacoes
{
    public interface IEspecificacao<T>
    {
        bool EhSatisfatorio(T entity);
    }
}
