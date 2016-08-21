using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Data
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        private DataContext db = new DataContext();
       
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetProductos(int? punto_venta_id = null)
        {
            PuntoVentaProducto[] productos;
            if (punto_venta_id.HasValue)
            {
                productos = db.PuntosVentaProductos.Include(p => p.Producto)
                                                                    .Where(p => p.PuntoVentaId == punto_venta_id)
                                                                    .AsNoTracking().ToArray();
            } else
            {
                productos = db.PuntosVentaProductos.Include(p => p.Producto)
                                                                    .AsNoTracking().ToArray();
            }
            
            if (productos.Length == 0) return Ok(new ProductoPuntoVentaDTO[] { });

            ProductoPuntoVentaDTO[] dtos = productos.Select(p => new ProductoPuntoVentaDTO(p, p.Producto)).ToArray();

            return Ok(dtos);
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
