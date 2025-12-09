
using Models;
using Interfaces;

/// <summary>
/// Implementación en memoria del repositorio de productos usando una List<Product>.
/// Almacena los productos en memoria durante la ejecución de la aplicación.
/// Los datos se pierden al cerrar la aplicación.
/// </summary>
public class ProductRepositoryList : IRepositorioDAO<Product>
{
    /// <summary>
    /// Lista interna que almacena los productos en memoria.
    /// </summary>
    private readonly List<Product> productos = new List<Product>();

    /// <summary>
    /// Obtiene todos los productos almacenados en la lista.
    /// </summary>
    /// <returns>Lista completa de productos.</returns>
    public List<Product> GetAll()
    {
        return productos;
    }

    /// <summary>
    /// Guarda un nuevo producto en la lista.
    /// </summary>
    /// <param name="p">El producto a guardar.</param>
    public void Save(Product p)
    {
        productos.Add(p);
    }

    /// <summary>
    /// Actualiza un producto existente en la lista.
    /// </summary>
    /// <param name="id">Identificador del producto a actualizar.</param>
    /// <param name="p">Los nuevos datos del producto.</param>
    public void Update(int id, Product p)
    {
        var index = productos.FindIndex(prod => prod.Id == id);
        productos[index] = p;

    }

    /// <summary>
    /// Elimina un producto de la lista por su identificador.
    /// </summary>
    /// <param name="id">Identificador del producto a eliminar.</param>
    public void Delete(int id)
    {
        var producto = productos.FirstOrDefault(prod => prod.Id == id);
        productos.Remove(producto);

    }

    /// <summary>
    /// Obtiene un producto específico por su identificador.
    /// </summary>
    /// <param name="id">Identificador del producto buscado.</param>
    /// <returns>El producto encontrado o null si no existe.</returns>
    public Product GetById(int id)
    {
        var p = productos.FirstOrDefault(prod => prod.Id == id);
        return p;
    }

    
}