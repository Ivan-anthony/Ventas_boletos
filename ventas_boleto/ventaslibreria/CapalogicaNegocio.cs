using System.Collections.Generic;
using System;

public class VentaBL
{
    private readonly VentaDAL ventaDAL;

    public VentaBL(VentaDAL ventaDAL)
    {
        this.ventaDAL = ventaDAL;
    }

    public List<Venta> ObtenerTodasLasVentas()
    {
        return ventaDAL.ObtenerTodos();
    }

    public Venta ObtenerVentaPorId(int idVenta)
    {
        return ventaDAL.ObtenerPorId(idVenta);
    }

    public int RegistrarVenta(Venta venta)
    {
       
        if (venta.ID_cliente <= 0)
        {
            throw new Exception("El ID del cliente no puede ser nulo o negativo.");
        }

        if (venta.ID_ruta <= 0)
        {
            throw new Exception("El ID de la ruta no puede ser nulo o negativo.");
        }

        if (venta.Cantidad <= 0)
        {
            throw new Exception("La cantidad de la venta no puede ser nula o negativa.");
        }


        venta.ImporteTotal = venta.Cantidad * ObtenerPrecioRuta(venta.ID_ruta);

       
        return ventaDAL.Insertar(venta);
    }

    private decimal ObtenerPrecioRuta(int idRuta)
    {
        
        decimal precioRuta = 100.00m; 
       

        return precioRuta;
    }
}
public class ClienteBL
{
    private readonly ClienteDAL clienteDAL;

    public ClienteBL(ClienteDAL clienteDAL)
    {
        this.clienteDAL = clienteDAL;
    }

    public List<Cliente> ObtenerTodosLosClientes()
    {
        return clienteDAL.ObtenerTodos();
    }

    public Cliente ObtenerClientePorId(int idCliente)
    {
        return clienteDAL.ObtenerPorId(idCliente);
    }

    public int RegistrarCliente(Cliente cliente)
    {
       
        return clienteDAL.Insertar(cliente);
    }

    public int ActualizarCliente(Cliente cliente)
    {
        
        return clienteDAL.Actualizar(cliente);
    }

    public int EliminarCliente(int idCliente)
    {
        
        return clienteDAL.Eliminar(idCliente);
    }
}
public class RutaBL
{
    private readonly RutaDAL rutaDAL;

    public RutaBL(RutaDAL rutaDAL)
    {
        this.rutaDAL = rutaDAL;
    }

    public List<Ruta> ObtenerTodasLasRutas()
    {
        return rutaDAL.ObtenerTodos();
    }

    public Ruta ObtenerRutaPorId(int idRuta)
    {
        return rutaDAL.ObtenerPorId(idRuta);
    }

    public int RegistrarRuta(Ruta ruta)
    {
       
        return rutaDAL.Insertar(ruta);
    }

    public int ActualizarRuta(Ruta ruta)
    {
       
        return rutaDAL.Actualizar(ruta);
    }

    public int EliminarRuta(int idRuta)
    {
        return rutaDAL.Eliminar(idRuta);
    }
}
public interface IClienteBL
{
    List<Cliente> ObtenerTodosLosClientes(); 
    Cliente ObtenerClientePorId(int id); 
    int RegistrarCliente(Cliente cliente); 
    void ActualizarCliente(Cliente cliente); 
    void EliminarCliente(int id); 
}

