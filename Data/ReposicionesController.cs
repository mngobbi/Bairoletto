using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Data
{
    [Authorize]
    [RoutePrefix("api/reposiciones")]
    public class ReposicionesController : ApiController
    {
        private DataContext db = new DataContext();

        #region "GETTERS"
        
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetOrdenes(int? punto_venta_id = null)
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] ordenes;
            if (punto_venta_id != null)
            {
                ordenes = db.OrdenesReposicion.Where(r => r.PuntoVentaId == punto_venta_id && r.FechaSolicitud > fecha_solicitud)
                                              .AsNoTracking().ToArray();
            }
            else
            {
                ordenes = db.OrdenesReposicion.Where(r => r.FechaSolicitud > fecha_solicitud).AsNoTracking().ToArray();
            }

            if (ordenes.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            var dtos = ordenes.Select(x => new ReposicionResumenDTO(x)).ToArray();

            return Ok(dtos);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetOrden(int id)
        {
            OrdenReposicion orden = db.OrdenesReposicion.Include(r => r.PuntoVenta)
                                                        .Include(r => r.Productos)
                                                        .Include(r => r.Camion)
                                                        .Where(x => x.Id == id).FirstOrDefault();

            if (orden == null) return NotFound();

            ReposicionDTO dto = new ReposicionDTO(orden, orden.PuntoVenta, orden.Productos, orden.Camion);

            return Ok(dto);
        }

        [Route("nuevas")]
        [HttpGet]
        public IHttpActionResult GetOrdenesNuevas(int? punto_venta_id = null)
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos;
            if (punto_venta_id != null)
            {
                repos = db.OrdenesReposicion.Where(r => r.PuntoVentaId == punto_venta_id && r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.nueva)
                                            .AsNoTracking().ToArray();
            } else
            {
                repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                            .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.nueva)
                                            .AsNoTracking().ToArray();
            }

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        [Route("aprobadas")]
        [HttpGet]
        public IHttpActionResult GetOrdenesAprobadas(int? punto_venta_id = null)
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos;
            if (punto_venta_id != null)
            {
                repos = db.OrdenesReposicion.Where(r => r.PuntoVentaId == punto_venta_id && r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.confirmada)
                                            .AsNoTracking().ToArray();
            }
            else
            {
                repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                            .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.confirmada)
                                            .AsNoTracking().ToArray();
            }

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        [Route("canceladas")]
        [HttpGet]
        public IHttpActionResult GetOrdenesCanceladas(int? punto_venta_id = null)
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos;
            if (punto_venta_id != null)
            {
                repos = db.OrdenesReposicion.Where(r => r.PuntoVentaId == punto_venta_id && r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.cancelada)
                                            .AsNoTracking().ToArray();
            }
            else
            {
                repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                            .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.cancelada)
                                            .AsNoTracking().ToArray();
            }

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        [Route("entransito")]
        [HttpGet]
        public IHttpActionResult GetOrdenesEntransito(int? punto_venta_id = null)
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos;
            if (punto_venta_id != null)
            {
                repos = db.OrdenesReposicion.Where(r => r.PuntoVentaId == punto_venta_id && r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.en_transito)
                                            .AsNoTracking().ToArray();
            }
            else
            {
                repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                            .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.en_transito)
                                            .AsNoTracking().ToArray();
            }

            if (repos.Length == 0) return Ok(new ReposicionResumenDTO[] { });

            ReposicionResumenDTO[] dtos = repos.Select(r => new ReposicionResumenDTO(r, r.PuntoVenta)).ToArray();

            return Ok(dtos);
        }

        [Route("entregadas")]
        [HttpGet]
        public IHttpActionResult GetOrdenesEntregas(int? punto_venta_id = null)
        {
            var fecha_solicitud = DateTime.Today.AddMonths(-1);

            OrdenReposicion[] repos;
            if (punto_venta_id != null)
            {
                repos = db.OrdenesReposicion.Where(r => r.PuntoVentaId == punto_venta_id && r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.entregada)
                                            .AsNoTracking().ToArray();
            }
            else
            {
                repos = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                            .Where(r => r.FechaSolicitud > fecha_solicitud && r.Estado == OrdenReposicionEstado.entregada)
                                            .AsNoTracking().ToArray();
            }

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

            return Ok(new ReposicionResumenDTO(orden));
        }

        [Route("{id:int}/aprobar")]
        [HttpPost]
        [ResponseType(typeof(ReposicionResumenDTO))]
        public IHttpActionResult PostAprobar(int id, ReposicionAprobarDTO aprobar)
        {
            if (!ModelState.IsValid || id != aprobar.reposicion_id) return BadRequest(ModelState);

            OrdenReposicion orden = db.OrdenesReposicion.Include(x => x.PuntoVenta).Where(x => x.Id == id).FirstOrDefault();
            if (orden == null) return NotFound();
            if (orden.Estado != OrdenReposicionEstado.nueva) return BadRequest("La orden de reposición ya fue procesada");


            var prod_ids = orden.Productos.Select(p => p.Producto.Id).ToArray();
            var productos = db.Productos.Where(x => prod_ids.Contains(x.Id)).ToArray();
            OrdenReposicionDetalle orden_prod;
            foreach (Producto p in productos)
            {
                orden_prod = orden.Productos.Where(x => x.Producto.Id == p.Id).FirstOrDefault();
                p.Stock = p.Stock - orden_prod.CantidadSolicitada;
            }


            var ev = new OrdenReposicionEventoConfirmacion(orden, aprobar.usuario, aprobar.comentario);
            db.OrdenesReposicionEventos.Add(new OrdenReposicionEvento(ev.GetEvento(), orden));

            orden.FechaProcesada = DateTime.UtcNow;
            orden.FechaEntegaEstimada = aprobar.fecha_entrega_estimada;
            orden.Estado = OrdenReposicionEstado.confirmada;

            db.SaveChanges();

            return Ok(new ReposicionResumenDTO(orden, orden.PuntoVenta));
        }

        [Route("{id:int}/rechazar")]
        [HttpPost]
        [ResponseType(typeof(ReposicionResumenDTO))]
        public IHttpActionResult PostRechazar(int id, ReposicionRechazarDTO rechazar)
        {
            if (!ModelState.IsValid || id != rechazar.reposicion_id) return BadRequest(ModelState);

            OrdenReposicion orden = db.OrdenesReposicion.Include(x => x.PuntoVenta).Where(x => x.Id == id).FirstOrDefault();
            if (orden == null) return NotFound();

            if (orden.CamionId != null)
            {
                Camion camion = db.Camiones.Where(c => c.Id == orden.CamionId).FirstOrDefault();
                if (camion == null) return NotFound();

                camion.Estado = CamionEstado.disponible;
            }

            if (orden.Estado != OrdenReposicionEstado.nueva)
            {
                var orden_prod_ids = orden.Productos.Select(p => p.ProductoId).ToArray();
                Producto[] productos = db.Productos.Where(p => orden_prod_ids.Contains(p.Id)).ToArray();
                OrdenReposicionDetalle orden_prod;
                foreach (Producto p in productos)
                {
                    orden_prod = orden.Productos.Where(x => x.ProductoId == p.Id).FirstOrDefault();
                    p.Stock = p.Stock + orden_prod.CantidadSolicitada;
                }
            }

            var ev = new OrdenReposicionEventoCancelacion(orden, rechazar.causa, rechazar.usuario, rechazar.comentario);
            db.OrdenesReposicionEventos.Add(new OrdenReposicionEvento(ev.GetEvento(), orden));

            orden.FechaProcesada = DateTime.UtcNow;
            orden.Estado = OrdenReposicionEstado.cancelada;

            db.SaveChanges();

            return Ok(new ReposicionResumenDTO(orden, orden.PuntoVenta));
        }

        [Route("{id:int}/agendar")]
        [HttpPost]
        [ResponseType(typeof(ReposicionDTO))]
        public IHttpActionResult PostAgendar(int id, ReposicionAgendarDTO agendar)
        {
            if (!ModelState.IsValid || id != agendar.reposicion_id) return BadRequest(ModelState);

            OrdenReposicion orden = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                                        .Include(x => x.Productos)
                                                        .Include(x => x.Eventos)
                                                        .Where(x => x.Id == id).FirstOrDefault();
            if (orden == null) return NotFound();

            var ev = new OrdenReposicionEventoAgenda(orden, agendar.fecha_agenda, orden.FechaEntegaEstimada, agendar.usuario, agendar.comentario);
            db.OrdenesReposicionEventos.Add(new OrdenReposicionEvento(ev.GetEvento(), orden));

            orden.FechaEntegaEstimada = agendar.fecha_agenda;

            db.SaveChanges();

            return Ok(new ReposicionDTO(orden, orden.PuntoVenta, orden.Productos));
        }

        [Route("{id:int}/enviar")]
        [HttpPost]
        [ResponseType(typeof(ReposicionDTO))]
        public IHttpActionResult PostEnviar(int id, ReposicionEnviarDTO enviar)
        {
            if (!ModelState.IsValid || id != enviar.reposicion_id) return BadRequest(ModelState);

            OrdenReposicion orden = db.OrdenesReposicion.Include(x => x.PuntoVenta)
                                                        .Include(x => x.Productos)
                                                        .Include(x => x.Eventos)
                                                        .Where(x => x.Id == id).FirstOrDefault();
            if (orden == null) return NotFound();
            if (orden.Estado != OrdenReposicionEstado.confirmada) return BadRequest("La orden de reposición se encuentra en el estado incorrecto");

            Camion camion = db.Camiones.Where(x => x.Id == enviar.camion_id && x.Estado == CamionEstado.disponible).FirstOrDefault();
            if (camion == null) return NotFound();

            var ev = new OrdenReposicionEventoEnTransito(orden, camion.Numero, enviar.usuario, enviar.comentario);
            db.OrdenesReposicionEventos.Add(new OrdenReposicionEvento(ev.GetEvento(), orden));

            orden.CamionId = camion.Id;
            orden.Estado = OrdenReposicionEstado.en_transito;

            camion.Estado = CamionEstado.no_disponible;

            db.SaveChanges();

            return Ok(new ReposicionDTO(orden, orden.PuntoVenta, orden.Productos, camion));
        }

        [Route("{id:int}/recepcion")]
        [HttpPost]
        [ResponseType(typeof(ReposicionResumenDTO))]
        public IHttpActionResult PostRecepcion(int id, ReposicionBasicaDTO recepcion)
        {
            if (!ModelState.IsValid || id != recepcion.reposicion_id) return BadRequest(ModelState);

            OrdenReposicion orden = db.OrdenesReposicion.Include(x => x.PuntoVenta).Where(x => x.Id == id).FirstOrDefault();
            if (orden == null) return NotFound();
            if (orden.Estado != OrdenReposicionEstado.en_transito) return BadRequest("La orden de reposición se encuentra en el estado incorrecto");

            Camion camion = db.Camiones.Where(x => x.Id == orden.CamionId).FirstOrDefault();
            if (camion == null) return NotFound();

            orden.FechaEntrega = DateTime.UtcNow;
            orden.Estado = OrdenReposicionEstado.entregada;

            camion.Estado = CamionEstado.disponible;

            var orden_prod_ids = orden.Productos.Select(p => p.ProductoId).ToArray();
            PuntoVentaProducto[] productos = db.PuntosVentaProductos.Where(x => x.PuntoVentaId == orden.PuntoVentaId && orden_prod_ids.Contains(x.ProductoId)).ToArray();
            OrdenReposicionDetalle orden_producto;
            foreach (PuntoVentaProducto p in productos)
            {
                orden_producto = orden.Productos.Where(op => op.ProductoId == p.ProductoId).FirstOrDefault();
                p.Stock = p.Stock + orden_producto.CantidadSolicitada;
            }

            var ev = new OrdenReposicionEventoRecepcion(orden, orden.FechaEntrega, recepcion.usuario, recepcion.comentario);
            db.OrdenesReposicionEventos.Add(new OrdenReposicionEvento(ev.GetEvento(), orden));

            db.SaveChanges();

            return Ok(new ReposicionResumenDTO(orden, orden.PuntoVenta));
        }

        [Route("{id:int}/comentario")]
        [HttpPost]
        [ResponseType(typeof(EventoDTO))]
        public IHttpActionResult PostComentario(int id, ReposicionBasicaDTO comentario)
        {
            if (!ModelState.IsValid || id != comentario.reposicion_id) return BadRequest(ModelState);
            OrdenReposicion orden = db.OrdenesReposicion.Where(x => x.Id == id).FirstOrDefault();
            if (orden == null) return NotFound();

            var ev = new OrdenReposicionEventoComentario(orden, comentario.usuario, comentario.comentario);
            db.OrdenesReposicionEventos.Add(new OrdenReposicionEvento(ev.GetEvento(), orden));

            db.SaveChanges();

            return Ok(new EventoDTO(ev));
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
