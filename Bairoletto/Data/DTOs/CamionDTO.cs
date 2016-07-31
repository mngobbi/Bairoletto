using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CamionDTO
    {
        public int id { get; set; }
        public int numero { get; set; }
        public CamionEstado estado { get; set; }
        public double capacidad { get; set; }
        public string patente { get; set; }
        public string descripcion { get; set; }

        public CamionDTO() { }

        public CamionDTO(Camion c) {
            id = c.Id;
            numero = c.Numero;
            estado = c.Estado;
            capacidad = c.Capacidad;
            patente = c.Patente;
            descripcion = c.Descripcion;
        }
    }
}
