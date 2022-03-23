using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;

namespace M03_REST01.Data
{
    public class DbContextGeneration
    {
        private static DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private static PooledDbContextFactory<ApplicationDbContext> _pooledDbContextFactory;
        static DbContextGeneration()
        {
            IConfigurationRoot configuration =
                 new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json", false)
                    .Build();
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
#if DEBUG
                .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                .EnableSensitiveDataLogging()
#endif
                .Options;
            _pooledDbContextFactory = new PooledDbContextFactory<ApplicationDbContext>(_dbContextOptions);
        }
        public static ApplicationDbContext ObtenirApplicationDBContext()
        {
            return _pooledDbContextFactory.CreateDbContext();
        }
    }
}
