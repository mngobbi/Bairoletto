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
    [RoutePrefix("api/reposiciones")]
    public class ReposicionesController : ApiController
    {
        private DataContext db = new DataContext();

        #region "GETTERS"
        
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetOrden(int id)
        {
            OrdenReposicion orden = db.OrdenesReposicion.Where(x => x.Id == id).FirstOrDefault();

            if (orden == null) return NotFound();

            ReposicionDTO dto = new ReposicionDTO(orden, orden.PuntoVenta, orden.Productos.ToArray(), orden.Camion);

            return Ok(dto);
        }

        [Route("nuevas")]
        [HttpGet]
        public IHttpActionResult GetOrdenesNuevas()
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                                          .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.nueva)
                                                          .AsNoTracking().ToArray();

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        [Route("aprobadas")]
        [HttpGet]
        public IHttpActionResult GetOrdenesAprobadas()
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                                          .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.confirmada)
                                                          .AsNoTracking().ToArray();

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        [Route("canceladas")]
        [HttpGet]
        public IHttpActionResult GetOrdenesCanceladas()
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                                          .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.cancelada)
                                                          .AsNoTracking().ToArray();

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        [Route("entransito")]
        [HttpGet]
        public IHttpActionResult GetOrdenesEntransito()
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                                          .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.en_transito)
                                                          .AsNoTracking().ToArray();

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        [Route("entregadas")]
        [HttpGet]
        public IHttpActionResult GetOrdenesEntregas()
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                                          .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.entregada)
                                                          .AsNoTracking().ToArray();

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        #endregion

        #region "SETTERS"

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(ReposicionResumenDTO))]
        public IHttpActionResult PostNuevaReposicion(ReposicionNuevaDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            PlantaElaboracion pe = db.PlantasElaboracion.Where(x => x.Id == dto.planta_elaboracion_id).FirstOrDefault();
            if (pe == null) return NotFound();

            PuntoVenta pv = db.PuntosVenta.Where(x => x.Id == dto.punto_venta_id).FirstOrDefault();          
            if (pv == null) return NotFound();

            OrdenReposicion orden = new OrdenReposicion();
            orden.PlantaElaboracionId = pe.Id;
            orden.PuntoVentaId = pv.Id;
            orden.FechaEntregaDeseada = dto.fecha_entrega_deseada;
            orden.Comentario = dto.comentario;

            OrdenReposicionDetalle repos_producto;
            foreach (ProductoReposicionNuevoDTO p in dto.productos)
            {
                repos_producto = new OrdenReposicionDetalle();
                repos_producto.ProductoId = p.producto_id;
                repos_producto.CantidadSolicitada = p.cantidad_solicitada;
                repos_producto.PrecioUnitario = p.precio_unitario;

                orden.Productos.Add(repos_producto);
            }

            db.OrdenesReposicion.Add(orden);
            db.SaveChanges();

            return Ok(new ReposicionResumenDTO(orden, pv));
        }

        #endregion

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
