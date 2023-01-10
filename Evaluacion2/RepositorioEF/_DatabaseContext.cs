using Microsoft.EntityFrameworkCore;
using Models.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEF
{
    //add-migration create_db -Context _DatabaseContext -OutputDir Migrations -verbose
    //update-database -Context _DatabaseContext
    public class _DatabaseContext : DbContext
    {
        public virtual DbSet<TablaClientes> Clientes { get; set; }
        public virtual DbSet<TablaCompras> Compras { get; set; }
        public _DatabaseContext() { }
        public _DatabaseContext(DbContextOptions<_DatabaseContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var conection = "Data Source=localhost; Initial Catalog=test; User Id=sa; Password=12345Root;TrustServerCertificate=True";
            //optionsBuilder.UseSqlServer(conection);
        }

    }
    public class GeneradorDatos
    {
        public static void DatosPrueba(_DatabaseContext context)
        {
            if (context.Clientes!.Count() == 0)
            {
                var cliente = new TablaClientes
                {

                    
                    Nombre = "John",
                    Direccion = "Mexico",
                    Edad = 30,
                    Sexo = Sexo.M,
                    Telefono = "7351183761",
                    CuentaBancaria = "123"
                
                   
                };
                context.Clientes!.Add(cliente);
                context.SaveChanges();

                var compra = new TablaCompras
                {
                    ClienteId = cliente.Id,
                    Monto=10000,
                    Compra="ML",
                    NumeroTarjeta="123",
                    TipoProduto= TipoProduto.VISA,
                    TipoTarjeta=TipoTarjeta.TDC,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    Activo = true,
                };
                context.Compras!.Add(compra);
                context.SaveChanges();
            }

        }
    }
}
