using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Data
{
    [Authorize]
    [RoutePrefix("api/camiones")]
    public class CamionesController : ApiController
    {
        private DataContext db = new DataContext();

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetCamiones()
        {
            Camion[] camiones = db.Camiones.AsNoTracking().ToArray();

            if (camiones.Length == 0) return Ok(new CamionDTO[] { });

            var dtos = camiones.Select(c => new CamionDTO(c)).ToArray();

            return Ok(dtos);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetCamion(int id)
        {
            Camion camion = db.Camiones.Where(c => c.Id == id).AsNoTracking().FirstOrDefault();

            if (camion == null) return NotFound();

            var dto = new CamionDTO(camion);

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
