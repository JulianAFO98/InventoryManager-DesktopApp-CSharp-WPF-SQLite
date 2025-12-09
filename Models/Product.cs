
namespace Models;

/// <summary>
/// Modelo que representa un producto en el inventario.
/// Contiene información básica del producto como nombre, precio, stock y categoría.
/// </summary>
public class Product
{
    /// <summary>
    /// Identificador único del producto.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre descriptivo del producto.
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Categoría a la que pertenece el producto (Juguete, Consumo, Cristalería, etc).
    /// </summary>
    public string Categoria { get; set; }

    /// <summary>
    /// Precio unitario del producto.
    /// </summary>
    public decimal Precio { get; set; }

    /// <summary>
    /// Cantidad disponible en el inventario.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Calcula automáticamente el precio total (Precio × Stock).
    /// </summary>
    public decimal PrecioTotal => Precio * Stock;

    /// <summary>
    /// Fecha de creación del producto. Se asigna automáticamente a la fecha actual.
    /// </summary>
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}