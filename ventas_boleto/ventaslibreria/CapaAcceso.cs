using System.Collections.Generic;
using System.Data.SqlClient;

public interface IDAL
{
    List<T> ObtenerTodos<T>();
    T ObtenerPorId<T>(int id);
    int Insertar<T>(T entidad);
    int Actualizar<T>(T entidad);
    int Eliminar<T>(int id);
    Ruta ObtenerPorId(int id);
}}
public class ClienteDAL : IDAL
{
    private readonly string connectionString;

    public ClienteDAL(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public override List<ClienteDAL> GetObtenerTodos()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Clientes", connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                List<ClienteDAL> clientes = new List<ClienteDAL>();
                while (reader.Read())
                {
                    clientes.Add(item: new Cliente
                    {
                        ID_cliente = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        DNI = reader.GetString(3),
                        Telefono = reader.GetString(4),
                        Correo_electronico = reader.GetString(5)
                    });
                }

                reader.Close();
                return clientes;

            }
        }
    }

    public override bool Equals(object obj)
    {
        return obj is ClienteDAL dAL &&
               this.connectionString == dAL.connectionString;
    }

    public override int GetHashCode()
    {
        return 1629884948 + EqualityComparer<string>.Default.GetHashCode(this.connectionString);
    }

    private readonly string connectionString = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
    ClienteDAL clienteDAL = new ClienteDAL(connectionString);

    public static object ConfigurationManager { get; private set; }
}

    public class RutaDAL : RutaDALBase, IDAL, IRutaDAL
    {
        public RutaDAL(string connectionString)
        {
            this.connectionString = connectionString;
    public override List<Ruta> GetObtenerTodos1()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Rutas", connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                List<Ruta> rutas = new List<Ruta>();
                while (reader.Read())
                {
                    rutas.Add(new Ruta
                    {
                        ID_ruta = reader.GetInt32(0),
                        Origen = reader.GetString(1),
                        Destino = reader.GetString(2),
                        Precio = reader.GetDecimal(3)
                    });
                }

                reader.Close();
                return rutas;
            }
        }
    }

    public override Ruta ObtenerPorId(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Rutas WHERE ID_ruta = @ID_ruta", connection))
            {
                command.Parameters.AddWithValue("@ID_ruta", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Ruta
                    {
                        ID_ruta = reader.GetInt32(0),
                        Origen = reader.GetString(1),
                        Destino = reader.GetString(2),
                        Precio = reader.GetDecimal(3)
                    };
                }
                else
                {
                    return null; // Ruta no encontrada
                }
            }
        }
    }
    public override int Insertar(Ruta ruta)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("INSERT INTO Rutas (Origen, Destino, Precio) VALUES (@Origen, @Destino, @Precio)", connection))
            {
                command.Parameters.AddWithValue("@Origen", ruta.Origen);
                command.Parameters.AddWithValue("@Destino", ruta.Destino);
                command.Parameters.AddWithValue("@Precio", ruta.Precio);

                return command.ExecuteNonQuery();
            }
        }
    }
    public override int Actualizar(Ruta ruta)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("UPDATE Rutas SET Origen = @Origen, Destino = @Destino, Precio = @Precio WHERE ID_ruta = @ID_ruta", connection))
            {
                command.Parameters.AddWithValue("@ID_ruta", ruta.ID_ruta);

            }
        }
    }

    public List<T> ObtenerTodos<T>()
    {
        throw new System.NotImplementedException();
    }

    public T ObtenerPorId<T>(int id)
    {
        throw new System.NotImplementedException();
    }

    public int Insertar<T>(T entidad)
    {
        throw new System.NotImplementedException();
    }

    public int Actualizar<T>(T entidad)
    {
        throw new System.NotImplementedException();
    }

    public int Eliminar<T>(int id)
    {
        throw new System.NotImplementedException();
    }
}

public class VentaDAL : IDAL
{
    private readonly string connectionString;

    public VentaDAL(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public override List<Venta> ObtenerTodos()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Ventas", connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                List<Venta> ventas = new List<Venta>();
                while (reader.Read())
                {
                    ventas.Add(new Venta
                    {
                        ID_venta = reader.GetInt32(0),
                        ID_cliente = reader.GetInt32(1),
                        ID_ruta = reader.GetInt32(2),
                        Cantidad = reader.GetInt32(3),
                        ImporteTotal = reader.GetDecimal(4),
                        Fecha_venta = reader.GetDateTime(5)
                    });
                }

                reader.Close();
                return ventas;
            }
        }
    }

    public override Venta ObtenerPorId(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Ventas WHERE ID_venta = @ID_venta", connection))
            {
                command.Parameters.AddWithValue("@ID_venta", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Venta
                    {
                        ID_venta = reader.GetInt32(0),
                        ID_cliente = reader.GetInt32(1),
                        ID_ruta = reader.GetInt32(2),
                        Cantidad = reader.GetInt32(3),
                        ImporteTotal = reader.GetDecimal(4),
                        Fecha_venta = reader.GetDateTime(5)
                    };
                }
                else
                {
                    return null; 
                }
            }
        }
    }

    public override int Insertar(Venta venta)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("INSERT INTO Ventas (ID_cliente, ID_ruta, Cantidad, ImporteTotal, Fecha_venta) VALUES (@ID_cliente, @ID_ruta, @Cantidad, @ImporteTotal, @Fecha_venta)", connection))
            {
                command.Parameters.AddWithValue("@ID_cliente", venta.ID_cliente);
                command.Parameters.AddWithValue("@ID_ruta", venta.ID_ruta);
                command.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                command.Parameters.AddWithValue("@ImporteTotal", venta.ImporteTotal);
                command.Parameters.AddWithValue("@Fecha_venta", venta.Fecha_venta);

                return command.ExecuteNonQuery();
            }
        }
    }

    public override int Actualizar(Venta venta)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("UPDATE Ventas SET ID_cliente = @ID_cliente, ID_ruta = @ID_ruta, Cantidad = @Cantidad, ImporteTotal = @ImporteTotal, Fecha_venta = @Fecha_venta WHERE ID_venta = @ID_venta", connection))
            {
                command.Parameters.AddWithValue("@ID_venta", venta.ID_venta);
                command.Parameters.AddWithValue("@ID_cliente", venta.ID_cliente);
                command.Parameters.AddWithValue("@ID_ruta", venta.ID_ruta);
                command.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                command.Parameters.AddWithValue("@ImporteTotal", venta.ImporteTotal);
                command.Parameters.AddWithValue("@Fecha_venta", venta.Fecha_venta);

                return command.ExecuteNonQuery();
            }
        }
    }

    public override int Eliminar(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("DELETE FROM Ventas WHERE ID_venta = @ID_venta", connection))
            {
                command.Parameters.AddWithValue("@ID_venta", id);

                return command.ExecuteNonQuery();
            }
        }
    }
}




