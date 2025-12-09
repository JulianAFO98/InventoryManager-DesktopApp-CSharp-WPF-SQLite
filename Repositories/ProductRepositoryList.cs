
using Models;
using Interfaces;
public class ProductRepositoryList : IRepositorioDAO<Product>
{
    private readonly List<Product> productos = new List<Product>();

    public List<Product> GetAll()
    {
        return productos;
    }

    public void Save(Product p)
    {
        productos.Add(p);
    }

    public void Update(int id, Product p)
    {
        var index = productos.FindIndex(prod => prod.Id == id);
        productos[index] = p;

    }

    public void Delete(int id)
    {
        var producto = productos.FirstOrDefault(prod => prod.Id == id);
        productos.Remove(producto);

    }

    public Product GetById(int id)
    {
        var p = productos.FirstOrDefault(prod => prod.Id == id);
        return p;
    }

    
}