using Microsoft.Data.Sqlite;
using Models;
using Interfaces;

/// <summary>
/// Repositorio de productos basado en SQLite.
/// Esta clase implementaría el acceso a datos con persistencia en base de datos.
/// Actualmente está parcialmente implementada (esquema comentado).
/// 

public class ProductRepository : IRepositorioDAO<Product>
{
    private readonly string _connectionString =
        "Data Source=productos.db";

    public ProductRepository()
    {
        using var con = new SqliteConnection(_connectionString);
        con.Open();

        string sql = @"CREATE TABLE IF NOT EXISTS Productos(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ProductName TEXT,
                        Categoria TEXT,
                        Precio REAL,
                        Stock INTEGER,
                        FechaCreacion TEXT
                   )";

        using var cmd = new SqliteCommand(sql, con);
        cmd.ExecuteNonQuery();
    }

    public List<Product> GetAll()
    {
        var lista = new List<Product>();

        using var con = new SqliteConnection(_connectionString);
        con.Open();

        string sql = "SELECT * FROM Productos";

        using var cmd = new SqliteCommand(sql, con);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            lista.Add(new Product
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                Categoria = reader.GetString(reader.GetOrdinal("Categoria")),
                Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                FechaCreacion = DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaCreacion")))
            });
        }

        return lista;
    }


    public void Delete(int id)
    {
        using var con = new SqliteConnection(_connectionString);
        con.Open();
        string sql = @"DELETE FROM Productos WHERE Id = @Id";
        using var cmd = new SqliteCommand(sql, con);
        cmd.Parameters.AddWithValue("@Id",id);
        cmd.ExecuteNonQuery();
    }


    public Product GetById(int id)
    {
        using var con = new SqliteConnection(_connectionString);
        con.Open();
        string sql = @"SELECT * FROM Productos WHERE Id = @Id";
        using var cmd = new SqliteCommand(sql, con);
        cmd.Parameters.AddWithValue("@Id",id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Product
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                Categoria = reader.GetString(reader.GetOrdinal("Categoria")),
                Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                FechaCreacion = DateTime.Parse(reader.GetString(reader.GetOrdinal("FechaCreacion")))
            };
        }
        return null;
    }

    public void Save(Product p)
    {
        using var con = new SqliteConnection(_connectionString);
        con.Open();
        string sql = @"INSERT INTO Productos (ProductName, Categoria, Precio, Stock, FechaCreacion)
                       VALUES (@ProductName, @Categoria, @Precio, @Stock, @FechaCreacion)";
        using var cmd = new SqliteCommand(sql, con);
        cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
        cmd.Parameters.AddWithValue("@Categoria", p.Categoria); 
        cmd.Parameters.AddWithValue("@Precio", p.Precio);
        cmd.Parameters.AddWithValue("@Stock", p.Stock);
        cmd.Parameters.AddWithValue("@FechaCreacion", p.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.ExecuteNonQuery();
        
    }

    public void Update(int id, Product p)
    {
        using var con = new SqliteConnection(_connectionString);
        con.Open();
        string sql = @"UPDATE Productos 
                       SET ProductName = @ProductName, 
                           Categoria = @Categoria, 
                           Precio = @Precio, 
                           Stock = @Stock 
                       WHERE Id = @Id";
        using var cmd = new SqliteCommand(sql, con);
        cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
        cmd.Parameters.AddWithValue("@Categoria", p.Categoria);
        cmd.Parameters.AddWithValue("@Precio", p.Precio);
        cmd.Parameters.AddWithValue("@Stock", p.Stock);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }
}