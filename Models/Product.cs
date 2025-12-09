
namespace Models;
public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public decimal PrecioTotal => Precio * Stock;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}