using Interfaces;
using Models;

namespace InventoryManager.Services;

public class ProductService
{
    private readonly IRepositorioDAO<Product> _repository;

    public ProductService(IRepositorioDAO<Product> repository)
    {
        _repository = repository;
    }

    public List<Product> obtenerProductos()
    {
        return _repository.GetAll();
    }

    public void CrearProducto(Product p)
    {
        
        _repository.Save(p);
     
    }

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


    public void EliminarProducto(int id)
    {
        _repository.Delete(id);
       
    }

}