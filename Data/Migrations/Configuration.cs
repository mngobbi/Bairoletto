namespace Data
{
    using System;
    using System.Data.Entity.Migrations;

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
                    Nombre = "Bairoletto Empanadas Sure�as",
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
                    Nombre = "Bairoletto Empanadas Sure�as",
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
                    Nombre = "Bairoletto Empanadas Sure�as",
                    Tipo = PuntoVentaTipo.sucursal,
                    Telefono = "0299 478-4600",
                    Direccion = "Gral. San Mart�n 252, 8324",
                    Ciudad = "Cipolletti",
                    Provincia = "Rio Negro",
                    Pais = "Argentina"
                });

            context.Productos.AddOrUpdate(new Producto[] {
                new Producto { Id = 1, TipoProducto = TipoProducto.comestible, Codigo = "COM_EMP_001", Nombre = "Empanada carne suave", Stock=1745, PrecioCosto = 9.60, Descripcion = "Carne picada, cebolla, aji rojo" },
                new Producto { Id = 2, TipoProducto = TipoProducto.comestible, Codigo = "COM_EMP_002", Nombre = "Empanada carne picante", Stock=840,PrecioCosto = 9.80, Descripcion = "Carne picada, cebolla, aji rojo, pimienta" },
                new Producto { Id = 3, TipoProducto = TipoProducto.comestible, Codigo = "COM_EMP_003", Nombre = "Empanada pollo", Stock=1450,PrecioCosto = 8.80, Descripcion = "Pollo, cebolla, aji rojo" },
                new Producto { Id = 4, TipoProducto = TipoProducto.comestible, Codigo = "COM_EMP_004", Nombre = "Empanada verdura", Stock=960,PrecioCosto = 7.50, Descripcion = "Acelga, cebolla, salsa blanca, provolone rayado" },
                new Producto { Id = 5, TipoProducto = TipoProducto.comestible, Codigo = "COM_EMP_005", Nombre = "Empanada humita", Stock=1110,PrecioCosto = 8.20, Descripcion = "Choclo crema, salsa blanca, provolone" },
                new Producto { Id = 6, TipoProducto = TipoProducto.comestible, Codigo = "COM_EMP_006", Nombre = "Empanada jam�n y queso", Stock=1235,PrecioCosto = 8.50, Descripcion = "Jam�n cocido, mozzarella" },
                new Producto { Id = 7, TipoProducto = TipoProducto.comestible, Codigo = "COM_PIZ_001", Nombre = "Pizza muzzarella con jam�n", Stock=620,PrecioCosto = 23.60, Descripcion = "Mozzarella, jam�n cocido, aceitunas verdes" },
                new Producto { Id = 8, TipoProducto = TipoProducto.comestible, Codigo = "COM_PIZ_002", Nombre = "Pizza napolitana", Stock=580,PrecioCosto = 22.50, Descripcion = "Mozzarella, tomate, ajo, aceitunas verdes" },
                new Producto { Id = 9, TipoProducto = TipoProducto.comestible, Codigo = "COM_PIZ_003", Nombre = "Pizza  fugazzeta", Stock=560,PrecioCosto = 20.25, Descripcion = "Mozzarella, cebolla, oregano" },
                new Producto { Id = 10, TipoProducto = TipoProducto.bebible, Codigo = "BEB_GAS_001", Nombre = "Coca cola zero 2 1/4", Stock=330,PrecioCosto = 24.60 },
                new Producto { Id = 11, TipoProducto = TipoProducto.bebible, Codigo = "BEB_GAS_002", Nombre = "7up 1 1/2", Stock=315,PrecioCosto = 18.50 },
                new Producto { Id = 12, TipoProducto = TipoProducto.bebible, Codigo = "BEB_JUG_001", Nombre = "Levite pomelo 1 1/2", Stock=287,PrecioCosto = 15.40 },
                new Producto { Id = 13, TipoProducto = TipoProducto.bebible, Codigo = "BEB_JUG_002", Nombre = "Aquarius multifruta 1 1/2", Stock=250,PrecioCosto = 14.80 },
            });

            context.PuntosVentaProductos.AddOrUpdate(new PuntoVentaProducto[] {
                new PuntoVentaProducto { Id = 1, PuntoVentaId = 1, ProductoId = 1, Stock = 45, Precio = 17.50 },
                new PuntoVentaProducto { Id = 2, PuntoVentaId = 1, ProductoId = 3, Stock = 52, Precio = 17.50 },
                new PuntoVentaProducto { Id = 3, PuntoVentaId = 1, ProductoId = 4, Stock = 10, Precio = 17.50 },
                new PuntoVentaProducto { Id = 4, PuntoVentaId = 1, ProductoId = 5, Stock = 20, Precio = 17.50 },
                new PuntoVentaProducto { Id = 5, PuntoVentaId = 1, ProductoId = 10, Stock = 15, Precio = 30 },
                new PuntoVentaProducto { Id = 6, PuntoVentaId = 2, ProductoId = 1, Stock = 54, Precio = 18.50 },
                new PuntoVentaProducto { Id = 7, PuntoVentaId = 2, ProductoId = 2, Stock = 48, Precio = 18.50 },
                new PuntoVentaProducto { Id = 8, PuntoVentaId = 2, ProductoId = 4, Stock = 25, Precio = 18.50 },
                new PuntoVentaProducto { Id = 9, PuntoVentaId = 2, ProductoId = 7, Stock = 34, Precio = 40.25 },
                new PuntoVentaProducto { Id = 10, PuntoVentaId = 2, ProductoId = 6, Stock = 20, Precio = 18.50 }
            });

            context.Camiones.AddOrUpdate(new Camion[] {
                new Camion { Id = 1, Numero = 45, Capacidad = 600, Patente = "UBD789"},
                new Camion { Id = 2, Numero = 23, Capacidad = 500, Patente = "ABR154"}
            });
        }
    }
}
