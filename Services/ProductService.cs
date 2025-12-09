using Interfaces;
using Models;

namespace InventoryManager.Services;

/// <summary>
/// Servicio que gestiona la lógica de operaciones CRUD para productos.
/// Actúa como intermediario entre el controlador y el repositorio de datos.
/// Encapsula la lógica de negocio relacionada con productos.
/// </summary>
public class ProductService
{
    /// <summary>
    /// Repositorio genérico encargado del acceso a datos de productos.
    /// </summary>
    private readonly IRepositorioDAO<Product> _repository;

    /// <summary>
    /// Constructor que inicializa el servicio con un repositorio.
    /// </summary>
    /// <param name="repository">Implementación del repositorio a utilizar.</param>
    public ProductService(IRepositorioDAO<Product> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Obtiene todos los productos disponibles en el repositorio.
    /// </summary>
    /// <returns>Lista de todos los productos.</returns>
    public List<Product> obtenerProductos()
    {
        return _repository.GetAll();
    }

    /// <summary>
    /// Crea un nuevo producto en el repositorio.
    /// </summary>
    /// <param name="p">El producto a crear.</param>
    public void CrearProducto(Product p)
    {
        
        _repository.Save(p);
     
    }

    /// <summary>
    /// Actualiza los datos de un producto existente.
    /// Busca el producto por ID y actualiza sus propiedades.
    /// </summary>
    /// <param name="id">Identificador del producto a actualizar.</param>
    /// <param name="nuevosDatos">Objeto con los nuevos datos del producto.</param>
    /// <exception cref="KeyNotFoundException">Si no existe un producto con el ID especificado.</exception>
    public void ActualizarProducto(int id, Product nuevosDatos)
    {
       
        var prod = _repository.GetById(id)
                  ?? throw new KeyNotFoundException("No existe un producto con ese ID.");

        prod.ProductName = nuevosDatos.ProductName;
        prod.Precio = nuevosDatos.Precio;
        prod.Stock = nuevosDatos.Stock;
        prod.Categoria = nuevosDatos.Categoria;
        _repository.Update(id, prod);
    }

    /// <summary>
    /// Elimina un producto del repositorio.
    /// </summary>
    /// <param name="id">Identificador del producto a eliminar.</param>
    public void EliminarProducto(int id)
    {
        _repository.Delete(id);
       
    }

}