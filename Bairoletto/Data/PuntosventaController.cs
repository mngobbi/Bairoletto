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
    [RoutePrefix("api/puntosventa")]
    public class PuntosventaController : ApiController
    {
        private DataContext db = new DataContext();
      
        [Route("{id:int}/reposiciones")]
        [HttpGet]
        public IHttpActionResult GetPuntoventaReposiciones(int id)
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos = db.OrdenesReposicion.Where(r => r.FechaSolicitud > fecha_solicitud && r.PuntoVentaId == id)
                                                          .AsNoTracking().ToArray();

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r)).ToArray();

            return Ok(dtos);
        }
       
        [Route("{id:int}/productos")]
        [HttpGet]
        public IHttpActionResult GetPuntoventaProductos(int id)
        {
            PuntoVentaProducto[] productos = db.PuntosVentaProductos.Include(p => p.Producto)
                                                                    .Where(p => p.PuntoVentaId == id)
                                                                    .AsNoTracking().ToArray();

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
