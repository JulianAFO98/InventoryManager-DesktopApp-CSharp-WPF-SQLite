using Models;
using Interfaces;

public class ProductRepository : IRepositorioDAO<Product>
{
    private readonly string _connectionString =
        "Data Source=productos.db";

    /*public ProductRepository()
    {
        using var con = new SQLiteConnection(_connectionString);
        con.Open();

        string sql = @"CREATE TABLE IF NOT EXISTS Productos(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT,
                        Categoria TEXT,
                        Precio REAL,
                        Stock INTEGER,
                        FechaCreacion TEXT
                       )";

        using var cmd = new SQLiteCommand(sql, con);
        cmd.ExecuteNonQuery();
    }

    public List<Product> GetAll()
    {
        var lista = new List<Product>();
        using var con = new SQLiteConnection(_connectionString);
        con.Open();

        string sql = "SELECT * FROM Productos";
        using var cmd = new SQLiteCommand(sql, con);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            lista.Add(new Product
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nombre = reader["Nombre"].ToString(),
                Categoria = reader["Categoria"].ToString(),
                Precio = Convert.ToDecimal(reader["Precio"]),
                Stock = Convert.ToInt32(reader["Stock"]),
                FechaCreacion = DateTime.Parse(reader["FechaCreacion"].ToString())
            });
        }
        return lista;
    }
    
    // Métodos Save, Update, Delete...
    */

    public List<Product> GetAll()
    {
        return new List<Product>();
    }

    public void Save(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Product entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}