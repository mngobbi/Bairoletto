using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Data
{
    [Authorize]
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        private DataContext db = new DataContext();
       
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetProductos(int? punto_venta_id = null)
        {
            if (punto_venta_id != null)
            {
                PuntoVentaProducto[] productos = db.PuntosVentaProductos.Include(p => p.Producto)
                                                   .Where(p => p.PuntoVentaId == punto_venta_id)
                                                   .AsNoTracking().ToArray();
                if (productos.Length == 0) return Ok(new ProductoPuntoVentaDTO[] { });
                var dtos = productos.Select(p => new ProductoPuntoVentaDTO(p, p.Producto)).ToArray();

                return Ok(dtos);
            }
            else
            {
                Producto[] productos = db.Productos.AsNoTracking().ToArray();
                if (productos.Length == 0) return Ok(new ProductoPuntoVentaDTO[] { });
                var dtos = productos.Select(p => new ProductoDTO(p)).ToArray();


                return Ok(dtos);
            }          
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetProducto(int id)
        {
            Producto producto = db.Productos.Where(p => p.Id == id).AsNoTracking().FirstOrDefault();
            if (producto == null) return NotFound();

            var dto = new ProductoDTO(producto);

            return Ok(dto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
