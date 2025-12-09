namespace Interfaces;

/// <summary>
/// Interfaz genérica que define operaciones CRUD (Create, Read, Update, Delete) para acceso a datos.
/// Implementa el patrón DAO (Data Access Object) permitiendo abstracción de la capa de persistencia.
/// </summary>
/// <typeparam name="T">Tipo de entidad con la que se trabajará (ej: Product)</typeparam>
public interface IRepositorioDAO<T>
{
    /// <summary>
    /// Obtiene todos los registros del repositorio.
    /// </summary>
    /// <returns>Lista de todas las entidades almacenadas.</returns>
    List<T> GetAll();

    /// <summary>
    /// Obtiene una entidad específica por su identificador.
    /// </summary>
    /// <param name="id">Identificador único de la entidad.</param>
    /// <returns>La entidad encontrada o null si no existe.</returns>
    T GetById(int id);

    /// <summary>
    /// Guarda una nueva entidad en el repositorio.
    /// </summary>
    /// <param name="entity">La entidad a guardar.</param>
    void Save(T entity);

    /// <summary>
    /// Actualiza una entidad existente en el repositorio.
    /// </summary>
    /// <param name="id">Identificador de la entidad a actualizar.</param>
    /// <param name="entity">Los nuevos datos de la entidad.</param>
    void Update(int id, T entity);

    /// <summary>
    /// Elimina una entidad del repositorio.
    /// </summary>
    /// <param name="id">Identificador de la entidad a eliminar.</param>
    void Delete(int id);
}
