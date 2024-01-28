using ChromaticStdo.Modelos;
using ChromaticStdo.Utilidades;
using Microsoft.EntityFrameworkCore;


namespace ChromaticStdo.DataAcess
{
    public class ChromaticStdoDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDb = $"Filename={ConexionDB.DevolverRuta("ChromaticStdo.db")}";
            optionsBuilder.UseSqlite(conexionDb);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.IdCategoria);
                entity.Property(c => c.IdCategoria).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(c => c.IdDireccion);
                entity.Property(c => c.IdDireccion).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(c => c.IdTarjeta);
                entity.Property(c => c.IdTarjeta).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Producto>(entity => {
                entity.HasKey(c => c.IdProducto);
                entity.Property(c => c.IdProducto).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefCategoria).WithMany(p => p.Productos)
                .HasForeignKey(p => p.IdCategoria);
            });

            modelBuilder.Entity<Compra>(entity => {
                entity.HasKey(c => c.IdCompra);
                entity.Property(c => c.IdCompra).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefDireccion).WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdDireccion);
                entity.HasOne(c => c.RefTarjeta).WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdTarjeta);
            });


            modelBuilder.Entity<DetalleCompra>(entity => {
                entity.HasKey(c => c.IdDetalleCompra);
                entity.Property(c => c.IdDetalleCompra).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefCompra).WithMany(p => p.RefDetalleCompra)
                .HasForeignKey(p => p.IdCompra);
                entity.HasOne(c => c.RefProducto).WithMany(p => p.RefDetalleCompra)
               .HasForeignKey(p => p.IdProducto);
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(c => c.IdCarrito);
                entity.Property(c => c.IdCarrito).IsRequired().ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { IdCategoria = 1, Descripcion = "Textil", Imagen = "bx_textil.svg" },
                new Categoria { IdCategoria =2, Descripcion = "Personalizables" , Imagen = "bx_personalizables.svg" },
                new Categoria { IdCategoria = 3, Descripcion = "Didacticos", Imagen = "bx_didacticos.svg" },
                new Categoria { IdCategoria = 4, Descripcion = "Deportes", Imagen = "cat_deportes.svg" },
                new Categoria { IdCategoria = 5, Descripcion = "Hogar", Imagen = "bx_hogar.svg" },
                new Categoria { IdCategoria = 6, Descripcion = "Accesorios", Imagen = "cat_accesorios.svg" },
                new Categoria { IdCategoria = 7, Descripcion = "Oficina", Imagen = "bx_oficina.svg" },
                new Categoria { IdCategoria = 8, Descripcion = "Tecnologia", Imagen = "cat_tecnologia.svg" }
                );

            modelBuilder.Entity<Producto>().HasData(
                new Producto { 
                    IdProducto = 1, 
                    Nombre = "Camisetas y Polos ", 
                    Descripcion = "Tipo: Textil\r\nCamisetas: Polo\r\nTipo: Premiun",
                    IdCategoria = 1,
                    Precio = 15,
                    Imagen = "prod1.jpg"
                },
                new Producto
                {
                    IdProducto = 2,
                    Nombre = "Bolsos",
                    Descripcion = "Tipo: Bolsos de Tela\r\nModelo: Bolsos de lienzo con fuelle",
                    IdCategoria = 1,
                    Precio = 2,
                    Imagen = "prod2.jpg"
                },
                new Producto
                {
                    IdProducto = 3,
                    Nombre = "Gorras",
                    Descripcion = "Tipo: Gorra Daddy\r\nModelo: Gorra Dry fit de 6 paneles",
                    IdCategoria = 1,
                    Precio = 6,
                    Imagen = "prod3.jpg"
                },
                new Producto
                {
                    IdProducto = 4,
                    Nombre = "Mandil full color",
                    Descripcion = "Tipo: Mandil de tela con bolsillo\r\nTalla: única,Incluye logo o diseño impreso full color\r\nTipo: Premiun",
                    IdCategoria = 1,
                    Precio = 3,
                    Imagen = "prod4.jpg"
                },
                new Producto
                {
                    IdProducto = 5,
                    Nombre = "Toallas",
                    Descripcion = "Tipo: Franela para auto Libi\r\nTalla: Franela personalizada para carro\r\nTipo: Premiun",
                    IdCategoria = 1,
                    Precio = 1,
                    Imagen = "prod5.jpg"
                },
                new Producto
                {
                    IdProducto = 6,
                    Nombre = "Tomatodo plástico Travel 550ml",
                    Descripcion = "Tipo: Tomatodo\r\nModelo: Tomatodo plástico transparente con agarradera sin BPA, capacidad de 550 ml",
                    IdCategoria = 2,
                    Precio = 1,
                    Imagen = "prod6.jpg"
                },
                new Producto
                {
                    IdProducto = 7,
                    Nombre = "Mochila Basic",
                    Descripcion = "Tipo: Mochila\r\nModelo: Mochila de 28 x 40 cm con bolsillo delantero, malla al costado, espalda y mangas con esponja para su comodidad. Incluye logo impreso full color hasta 8 x 8 cm.",
                    IdCategoria =2,
                    Precio = 7,
                    Imagen = "prod7.jpg"
                },
                new Producto
                {
                    IdProducto = 8,
                    Nombre = "Libreta Deluxe",
                    Descripcion = "Tipo: Libreta Deluxe 14,6 x 21 cm\r\nModelo:Libreta 14,6×21 cm, 80 hojas de línea, sepatador de hojas y elástico para cierre.",
                    IdCategoria = 2,
                    Precio = 4,
                    Imagen = "prod7_1.jpg"
                },

                new Producto
                {
                    IdProducto = 9,
                    Nombre = "Boligrafo white elegant + Estuche",
                    Descripcion = "Bolígrafo con cuerpo metalizado y estuche fabricado en metal con interior acolchado\r\nOpcional: Se puede elegir la personalización del estuche",
                    IdCategoria = 3,
                    Precio = 2,
                    Imagen = "prod8.jpg"
                },
                new Producto
                {
                    IdProducto = 10,
                    Nombre = "Crayones Edu",
                    Descripcion = "Caja con 4 crayones de colores\r\nIncluye logo impreso en caja a full color",
                    IdCategoria = 3,
                    Precio = 038,
                    Imagen = "prod9.jpg"
                },
                new Producto
                {
                    IdProducto = 11,
                    Nombre = "Set resaltadores 3 colores",
                    Descripcion = "Conjunto de resaltadores tipo crayón incluyen 3 colores:\r\nrosado, amarillo y verde (no se secan)",
                    IdCategoria = 3,
                    Precio = 2,
                    Imagen = "prod10.jpg"
                },
                new Producto
                {
                    IdProducto = 12,
                    Nombre = "Kit de herramientas Complex",
                    Descripcion = "Kit de herramientas completo con 24 destornilladores y un soporte magnético\r\nCaja con apertura push de base magnética para evitar caída. Personalizable al 100%. Full color",
                    IdCategoria = 3,
                    Precio = 7,
                    Imagen = "prod11.jpg"
                },
                new Producto
                {
                    IdProducto = 13,
                    Nombre = "Balón de fútbol con logo",
                    Descripcion = "Pelota de fútbol hecha con cámara inflable de LATEX",
                    IdCategoria = 4,
                    Precio = 5,
                    Imagen = "prod12.jpg"
                },
                new Producto
                {
                    IdProducto = 14,
                    Nombre = "Chompa rompeviento premium",
                    Descripcion = "Chompa ligera con capucha desprendible y malla interior, 100% poliéster.",
                    IdCategoria = 4,
                    Precio = 16,
                    Imagen = "prod13.jpg"
                },
                new Producto
                {
                    IdProducto = 15,
                    Nombre = "Camiseta premium para running",
                    Descripcion = "Camiseta sublimada sin mangas full color\r\nDisponible en tallas S a XL, con opción de camisetas en tallas XXL o XXXL por un costo adicional",
                    IdCategoria = 4,
                    Precio = 6,
                    Imagen = "prod13_1.jpg"
                },
                new Producto
                {
                    IdProducto = 16,
                    Nombre = "Jarro Frosted 11oz",
                    Descripcion = "Jarro de 11 oz fabricado con vidrio de alta calidad, su acabado traslúcido (esmerilado) proporciona un toque único y agradable al agarre. Incluye logo impreso full color.",
                    IdCategoria = 5,
                    Precio = 1,
                    Imagen = "prod14.jpg"
                },
                new Producto
                {
                    IdProducto = 17,
                    Nombre = "Set de Vino Lujo",
                    Descripcion = "Set de accesorios para vino, contiene sacacorchos de dos tiempos ( navaja y destapador ), boquilla y corta gota, su empaque es en forma de una botella de vino. Incluye logo impreso a full color.",
                    IdCategoria = 5,
                    Precio = 7,
                    Imagen = "prod15.jpg"
                },
                new Producto
                {
                    IdProducto = 18,
                    Nombre = "Paraguas Top",
                    Descripcion = "Paragua de 8 paneles de tela impermeable, mango ergonómico de esponja para mayor comodidad y estructura interna resistente de alta calidad.",
                    IdCategoria = 5,
                    Precio = 5,
                    Imagen = "prod15_1.jpg"
                },
                new Producto
                {
                    IdProducto = 19,
                    Nombre = "Mini Bowl plástico",
                    Descripcion = "Bowl plástico\r\nIncluye logo un color\r\n13,2cm x 6cm\r\nSe puede fabricar de todo color: 15 días de fabricación",
                    IdCategoria = 5,
                    Precio = 1,
                    Imagen = "prod15_2.jpg"
                },

                new Producto
                {
                    IdProducto = 20,
                    Nombre = "Kit De Cubiertos Eco",
                    Descripcion = "Set de utensilios de bambú de tres elementos (cuchara, tenedor y cuchillo) en práctico estuche de lienzo. Incluye logo impreso en empaque a full color.",
                    IdCategoria = 5,
                    Precio = 2,
                    Imagen = "prod15_3.jpg"
                },
                new Producto
                {
                    IdProducto = 21,
                    Nombre = "Destapador de acero inoxidable",
                    Descripcion = "Incluye grabado del logo un lado.\r\nMedia 6.5 x 3.6 cm\r\nGrosor 1.5 mm",
                    IdCategoria = 6,
                    Precio = 1,
                    Imagen = "prod16.jpg"
                },
                new Producto
                {
                    IdProducto = 22,
                    Nombre = "Soporte de laptop – MDF",
                    Descripcion = "Soporte para laptop con un logo a full color. Incluye dos piezas.",
                    IdCategoria = 6,
                    Precio = 6,
                    Imagen = "prod16_1.jpg"
                },
                new Producto
                {
                    IdProducto = 23,
                    Nombre = "Cajas de naipe personalizadas",
                    Descripcion = "Caja impresa full color.\r\nIncluye barajas genéricas.",
                    IdCategoria = 6,
                    Precio = 1,
                    Imagen = "prod16_2.jpg"
                },
                new Producto
                {
                    IdProducto = 24,
                    Nombre = "Tabla de madera Piqué",
                    Descripcion = "Tabla de quesos, jamones, asados o embutidos. Ideales para chacurtería, piqueos, catering, eventos y regalos gourmet.\r\nIncluye logo grabado.",
                    IdCategoria = 6,
                    Precio = 7,
                    Imagen = "prod16_3.jpg"
                },
                new Producto
                {
                    IdProducto = 25,
                    Nombre = "Wine box",
                    Descripcion = "Set de sacacorcho 2 piezas + tapón de acero inoxidable en caja de regalo negra. Incluye logo impreso en caja a full color.",
                    IdCategoria = 6,
                    Precio = 4,
                    Imagen = "prod17.jpg"
                },
                 new Producto
                 {
                     IdProducto = 26,
                     Nombre = "Porta lápices Bambi",
                     Descripcion = "Organizador cuadrado de mdf ideal para lápices, bolígrafos, tijeras y más.",
                     IdCategoria = 7,
                     Precio = 4,
                     Imagen = "prod18.jpg"
                 },
                  new Producto
                  {
                      IdProducto = 27,
                      Nombre = "Mouse Pad Ergonómico Full Color",
                      Descripcion = "Mousepad ergonómico con suave cojín que se ajusta a la muñeca.\r\nImpresión un logo full color 8x8cm o 64cm2.",
                      IdCategoria = 7,
                      Precio = 3,
                      Imagen = "prod19.jpg"
                  },
                  new Producto
                  {
                      IdProducto = 28,
                      Nombre = "Porta Post Its Office",
                      Descripcion = "Porta post its de cuerina con 8 filas de sticks de mini recordatorios de colores y dos blocks de memo sticks. Medida:13,4×10,4cm",
                      IdCategoria = 7,
                      Precio = 4,
                      Imagen = "prod20.jpg"
                  },
                  new Producto
                  {
                      IdProducto = 29,
                      Nombre = "Pendrive Duo USB + USB C 32GB",
                      Descripcion = "Innovador pendrive que combina la utilidad de dos conectores en uno solo: USB 3.0 y USB C",
                      IdCategoria = 8,
                      Precio = 8,
                      Imagen = "prod21.jpg"
                  },
                  new Producto
                  {
                      IdProducto = 30,
                      Nombre = "Parlante mini Yasuní",
                      Descripcion = "Parlante cilíndrico bluetooth de 3W en bambú con batería integrada de 300mAh. Ofrece función de manos libres y cuenta con luces LED incorporadas\r\nIncluye cable de carga tipo C. Personalizado con logo impreso full color.",
                      IdCategoria = 8,
                      Precio = 10,
                      Imagen = "prod22.jpg"
                  },
                  new Producto
                  {
                      IdProducto = 31,
                      Nombre = "Power Bank Eco",
                      Descripcion = "Cargador portátil de bambú para celulares. Incluye cable de carga tipo C/USB. Personalizado con logo impreso a full color.",
                      IdCategoria = 8,
                      Precio = 8,
                      Imagen = "prod23.jpg"
                  },
                  new Producto
                  {
                      IdProducto = 32,
                      Nombre = "Cargador inalámbrico Eco",
                      Descripcion = "Cargador inalámbrico de corcho compatible con dispositivos con tecnología de carga inalámbrica 10W.\r\nIncluye cable de carga con entrada puerto tipo C.\r\nPersonalizado con el logo impreso a full color.",
                      IdCategoria = 8,
                      Precio = 6,
                      Imagen = "prod24.jpg"
                  },
                  new Producto
                  {
                      IdProducto = 33,
                      Nombre = "Porta Celular De Acrílico",
                      Descripcion = "Porta Celular De Acrílico transparente. Impreso full color, un lado 100% personalizable.",
                      IdCategoria = 8,
                      Precio = 2,
                      Imagen = "prod25.jpg"
                  }
                );
        }

       
    }
}
