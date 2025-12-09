using Models;
using InventoryManager.Services;

/// <summary>
/// Controlador que gestiona la lógica de negocio para productos.
/// Actúa como intermediario entre la capa de presentación (ViewModel) y la capa de datos (Service).
/// Realiza validaciones de datos antes de procesarlos.
/// </summary>
public class ProductController
{
    /// <summary>
    /// Servicio encargado de las operaciones CRUD sobre productos.
    /// </summary>
    private readonly ProductService _service;

    /// <summary>
    /// Constructor que inicializa el controlador con un servicio de productos.
    /// </summary>
    /// <param name="service">Instancia del servicio de productos.</param>
    public ProductController(ProductService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene la lista de todos los productos disponibles.
    /// </summary>
    /// <returns>Lista de productos, o lanza excepción si hay error.</returns>
    /// <exception cref="ApplicationException">Si hay error al obtener los productos.</exception>
    public List<Product> ObtenerProductos()
    {
        try
        {
            return _service.obtenerProductos();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al obtener los productos.", ex);
        }
    }

    /// <summary>
    /// Crea un nuevo producto en el inventario.
    /// Valida que el nombre, precio y stock sean válidos antes de crear.
    /// </summary>
    /// <param name="p">El producto a crear.</param>
    /// <exception cref="ArgumentException">Si el nombre está vacío.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Si el precio o stock son negativos.</exception>
    /// <exception cref="ApplicationException">Si hay error al crear el producto en la BD.</exception>
    public void CrearProducto(Product p)
    {
        if (string.IsNullOrWhiteSpace(p.ProductName))
            throw new ArgumentException("El nombre del producto no puede estar vacío.");
        if (p.Precio < 0)
            throw new ArgumentOutOfRangeException("El precio del producto no puede ser negativo.");
        if (p.Stock < 0)
            throw new ArgumentOutOfRangeException("El stock del producto no puede ser negativo.");
        try
        {
            _service.CrearProducto(p);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al crear el producto.", ex);
        }
    }

    /// <summary>
    /// Actualiza un producto existente en el inventario.
    /// Valida que los datos sean correctos antes de actualizar.
    /// </summary>
    /// <param name="id">Identificador del producto a actualizar.</param>
    /// <param name="p">Los nuevos datos del producto.</param>
    /// <exception cref="ArgumentException">Si el nombre está vacío.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Si el precio o stock son negativos.</exception>
    /// <exception cref="ApplicationException">Si hay error al actualizar en la BD.</exception>
    public void ActualizarProducto(int id, Product p)
    {
        if (string.IsNullOrWhiteSpace(p.ProductName))
            throw new ArgumentException("El nombre del producto no puede estar vacío.");
        if (p.Precio < 0)
            throw new ArgumentOutOfRangeException("El precio del producto no puede ser negativo.");
        if (p.Stock < 0)
            throw new ArgumentOutOfRangeException("El stock del producto no puede ser negativo.");
        try
        {
            _service.ActualizarProducto(id, p);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al crear el producto.", ex);
        }
    }

    /// <summary>
    /// Elimina un producto del inventario.
    /// </summary>
    /// <param name="id">Identificador del producto a eliminar.</param>
    /// <exception cref="ApplicationException">Si hay error al eliminar el producto.</exception>
    public void EliminarProducto(int id)
    {
        try
        {
            _service.EliminarProducto(id);  
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al eliminar el producto.", ex);
        }
    }
}