using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.IO.Compression;
using Models.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Models.Interfaces.Servicios;

namespace Servicios
{
    
    public static class _ExtensionServicios
    {
        public enum ConnectionType
        {
            EntityFrameworkInMemory,
            EntityFrameworkSQLLite,
            EntityFrameworkSQLServer,
            //Dapper
        }

        private static ConnectionType _connectionType;
        private static readonly string DatabaseName = "Test";
        public static void AddConnectionService(this IServiceCollection serviceCollection, ConnectionType type = ConnectionType.EntityFrameworkInMemory, string? databaseConnectionString= null)
        {

            _connectionType = type;
            if (_connectionType.ToString().Contains("EntityFramework"))
            {
                switch (_connectionType)
                {
                    case ConnectionType.EntityFrameworkInMemory:
                        serviceCollection.AddDbContext<RepositorioEF._DatabaseContext>(opt => opt.UseLazyLoadingProxies()
                        .UseInMemoryDatabase(databaseName: DatabaseName)
                        .ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                        .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                        );
                        break;
                    case ConnectionType.EntityFrameworkSQLLite:
                        if (!Directory.Exists(DatabaseName))
                        {
                            Directory.CreateDirectory(DatabaseName);
                        }
                        serviceCollection.AddDbContext<RepositorioEF._DatabaseContext>(opt => opt.UseLazyLoadingProxies().UseSqlite(new SqliteConnection($"Data Source={DatabaseName}/data.db"))
                        //.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                        //.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                        );
                        break;
                    case ConnectionType.EntityFrameworkSQLServer:

                        serviceCollection.AddDbContext<RepositorioEF._DatabaseContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(databaseConnectionString)
                        //.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                        //.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                        );
                        break;
                }
                serviceCollection.AddScoped<IRepositorioClientes, RepositorioEF.RepositorioClientes>();
                serviceCollection.AddScoped<IRepositorioCompras, RepositorioEF.RepositorioCompras>();
            }

            serviceCollection.AddScoped<IServicioClientes, ServicioClientes>();
            serviceCollection.AddScoped<IServicioCompras, ServicioCompras>();

        }
        public static void SeedDatabase(this IApplicationBuilder applicationBuilder)
        {
            if (_connectionType.ToString().Contains("EntityFramework"))
            {
                var scope = applicationBuilder.ApplicationServices.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<RepositorioEF._DatabaseContext>();

                RepositorioEF.GeneradorDatos.DatosPrueba(context);
            }


        }
        public static void AddPerformance(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddMemoryCache();

            serviceCollection.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });


            serviceCollection.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

        }

        public static void UsePerformance(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseResponseCompression();
        }
    }
}
