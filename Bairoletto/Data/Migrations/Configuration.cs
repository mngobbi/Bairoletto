namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.DataContext context)
        {
            context.PlantasElaboracion.AddOrUpdate(
                new PlantaElaboracion {
                    Id = 1,
                    Codigo = "BAI_FAB_01",
                    Nombre = "Planta 01 - Parque Industrial Roca",
                    FechaAlta = new DateTime(2007, 1, 1),
                    Direccion = "Independencia 1607, Parque Industrial",
                    Telefono = "(0298) 4356229",
                    Ciudad = "General Roca",
                    Provincia = "Rio Negro",
                    Pais = "Argentina"
                });

            context.PuntosVenta.AddOrUpdate(
                new PuntoVenta
                {
                    Id = 1,
                    PlantaElaboracionId = 1,
                    Codigo = "BAI_SUC_001",
                    Nombre = "Bairoletto Empanadas Sureñas",
                    Tipo = PuntoVentaTipo.sucursal,
                    Telefono = "4432100",
                    Direccion = "San Juan casi Villegas",
                    Ciudad = "General Roca",
                    Provincia = "Rio Negro",
                    Pais = "Argentina"
                },
                new PuntoVenta {
                    Id = 2,
                    PlantaElaboracionId = 1,
                    Codigo = "BAI_SUC_002",
                    Nombre = "Bairoletto Empanadas Sureñas",
                    Tipo = PuntoVentaTipo.sucursal,
                    Telefono = "0299 448-9600",
                    Direccion = "Gral. Manuel Belgrano 2000, 8300",
                    Ciudad = "Neuquen",
                    Provincia = "Neuquen",
                    Pais = "Argentina"
                },
                new PuntoVenta
                {
                    Id = 3,
                    PlantaElaboracionId = 1,
                    Codigo = "BAI_SUC_003",
                    Nombre = "Bairoletto Empanadas Sureñas",
                    Tipo = PuntoVentaTipo.sucursal,
                    Telefono = "0299 478-4600",
                    Direccion = "Gral. San Martín 252, 8324",
                    Ciudad = "Cipolletti",
                    Provincia = "Rio Negro",
                    Pais = "Argentina"
                });
        }
    }
}
