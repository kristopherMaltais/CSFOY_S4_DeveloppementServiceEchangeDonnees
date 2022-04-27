using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace M06_DAL_CompteBancaire
{
    public class DbContextGeneration
    {
        private static DbContextOptions<ApplicationDBContext> _dbContextOptions;
        private static PooledDbContextFactory<ApplicationDBContext> _pooledDbContextFactory;
        static DbContextGeneration()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseSqlServer("data source = DESKTOP-7EOCD8N; Initial Catalog = Ex_municipalite; Integrated Security = True;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
#if DEBUG
                .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                .EnableSensitiveDataLogging()
#endif
                .Options;
            _pooledDbContextFactory = new PooledDbContextFactory<ApplicationDBContext>(_dbContextOptions);
        }
        public static ApplicationDBContext ObtenirApplicationDBContext()
        {
            return _pooledDbContextFactory.CreateDbContext();
        }
    }
}