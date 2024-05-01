namespace ChatApi.Repos
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(string codice);
        T? GetByCod(string codice);
    }
}
