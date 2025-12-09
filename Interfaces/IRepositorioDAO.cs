namespace Interfaces;

public interface IRepositorioDAO<T>
{
    List<T> GetAll();
    T GetById(int id);
    void Save(T entity);
    void Update(int id, T entity);
    void Delete(int id);
}
