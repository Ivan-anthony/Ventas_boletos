using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaslibreria
{
    internal class capaserviciosweb
    {
        public class ClienteService
        {
            private readonly ClienteBL clienteBL;

            public ClienteService(ClienteBL clienteBL)
            {
                this.clienteBL = clienteBL;
            }

            public List<Cliente> GetAllClientes()
            {
                return clienteBL.ObtenerTodosLosClientes();
            }

            public Cliente GetClienteById(int id)
            {
                return clienteBL.ObtenerClientePorId(id);
            }

            public int CreateCliente(Cliente cliente)
            {
                return clienteBL.RegistrarCliente(cliente);
            }

            public void UpdateCliente(int id, Cliente cliente)
            {
                cliente.ID_cliente = id; 
                clienteBL.ActualizarCliente(cliente);
            }

            public void DeleteCliente(int id)
            {
                clienteBL.EliminarCliente(id);
            }
        }
        [Route("api/[controller]")]
        [ApiController]
        public class ClientesController : ControllerBase
        {
            private readonly ClienteService clienteService;

            public ClientesController(ClienteService clienteService)
            {
                this.clienteService = clienteService;
            }

            [HttpGet]
            public List<Cliente> GetClientes()
            {
                return clienteService.GetAllClientes();
            }

            [HttpGet("{id}")]
            public Cliente GetCliente(int id)
            {
                return clienteService.GetClienteById(id);
            }

            [HttpPost]
            public IActionResult CreateCliente([FromBody] Cliente cliente)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    clienteService.CreateCliente(cliente);
                    return CreatedAtRoute("GetCliente", new { id = cliente.ID_cliente }, cliente);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }

            [HttpPut("{id}")]
            public IActionResult UpdateCliente(int id, [FromBody] Cliente cliente)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    clienteService.UpdateCliente(id, cliente);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteCliente(int id)
            {
                try
                {
                    clienteService.DeleteCliente(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
        }

    }
}
public class RutaService
{
    private readonly RutaBL rutaBL;

    public RutaService(RutaBL rutaBL)
    {
        this.rutaBL = rutaBL;
    }

    public List<Ruta> GetAllRutas()
    {
        return rutaBL.ObtenerTodasLasRutas();
    }

    public Ruta GetRutaById(int id)
    {
        return rutaBL.ObtenerRutaPorId(id);
    }

    public int CreateRuta(Ruta ruta)
    {
        return rutaBL.RegistrarRuta(ruta);
    }

    public void UpdateRuta(int id, Ruta ruta)
    {
        ruta.ID_ruta = id; 
        rutaBL.ActualizarRuta(ruta);
    }

    public void DeleteRuta(int id)
    {
        rutaBL.EliminarRuta(id);
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly RutaService rutaService;

        public RutasController(RutaService rutaService)
        {
            this.rutaService = rutaService;
        }

        [HttpGet]
        public List<Ruta> GetRutas()
        {
            return rutaService.GetAllRutas();
        }

        [HttpGet("{id}")]
        public Ruta GetRuta(int id)
        {
            return rutaService.GetRutaById(id);
        }

        [HttpPost]
        public IActionResult CreateRuta([FromBody] Ruta ruta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                rutaService.CreateRuta(ruta);
                return CreatedAtRoute("GetRuta", new { id = ruta.ID_ruta }, ruta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRuta(int id, [FromBody] Ruta ruta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                rutaService.UpdateRuta(id, ruta);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRuta(int id)
        {
            try
            {
                rutaService.DeleteRuta(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    } }

    public class VentaService
    {
        private readonly VentaBL ventaBL;

        public VentaService(VentaBL ventaBL)
        {
            this.ventaBL = ventaBL;
        }

        public List<Venta> GetAllVentas()
        {
            return ventaBL.ObtenerTodasLasVentas();
        }

        public Venta GetVentaById(int id)
        {
            return ventaBL.ObtenerVentaPorId(id);
        }

        public int CreateVenta(Venta venta)
        {
            return ventaBL.RegistrarVenta(venta);
        }
        [Route("api/[controller]")]
        [ApiController]
        public class VentasController : ControllerBase
        {
            private readonly VentaService ventaService;

            public VentasController(VentaService ventaService)
            {
                this.ventaService = ventaService;
            }

            [HttpGet]
            public List<Venta> GetVentas()
            {
                return ventaService.GetAllVentas();
            }

            [HttpGet("{id}")]
            public Venta GetVenta(int id)
            {
                return ventaService.GetVentaById(id);
            }

            [HttpPost]
            public IActionResult CreateVenta([FromBody] Venta venta)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    int idVentaRegistrada = ventaService.CreateVenta(venta);
                    return CreatedAtRoute("GetVenta", new { id = idVentaRegistrada }, venta);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
        }

