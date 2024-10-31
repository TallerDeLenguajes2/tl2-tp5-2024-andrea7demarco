using EspacioPrograma;
using Microsoft.Data.Sqlite;
public class ProductosRepository
{
   private readonly string CadenaDeConexion = @"Data Source=Tienda.db;Cache=Shared";
   public void CrearProducto(Producto producto)
   {
      using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
      {
         var query = "INSERT INTO Productos(Descripcion, Precio) VALUES(@Descripcion, @Precio)";
         connection.Open();
         var command = new SqliteCommand(query, connection);
         command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
         command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
         command.ExecuteNonQuery();
         connection.Close();

      }

   }

   public List<Producto> ListarProducto()
   {
      List<Producto> listaProd = new List<Producto>();
      using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
      {
         string query = "SELECT * FROM Productos;";
         SqliteCommand command = new SqliteCommand(query, connection);
         connection.Open();
         using (SqliteDataReader reader = command.ExecuteReader())
         {
            while (reader.Read())
            {
               var prod = new Producto();
               prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
               prod.Descripcion = reader["Descripcion"].ToString();
               prod.Precio = Convert.ToInt32(reader["Precio"]);
               listaProd.Add(prod);
            }
         }
         connection.Close();

      }
      return listaProd;
   }
}

