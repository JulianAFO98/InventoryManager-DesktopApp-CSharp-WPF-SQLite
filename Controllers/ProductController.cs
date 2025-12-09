using Models;
using InventoryManager.Services;
public class ProductController
{
    private readonly ProductService _service;
    public ProductController(ProductService service)
    {
        _service = service;
    }

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


    /**
    * Valido nuevamente aunque ya se validó en la capa de vista,por seguridad o por cambios a futuro.
    */
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