﻿using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class OrdenReposicionDetalle
    {
        public int Id { get; set; }

        public int OrdenReposicionId { get; set; }

        public int ProductoId { get; set; }

        [Required]
        public int CantidadSolicitada { get; set; }

        [Required]
        public float PrecioUnitario { get; set; }

        public virtual OrdenReposicion OrdenReposicion { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
