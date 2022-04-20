using M03_REST01.DAL_MunicipaliteSQLServer.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace M03_REST01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MunicipaliteDTO> Municipalites { get; set; }
        public DbSet<ClefAPIDTO> CLefAPI { get; set; }
    }
}