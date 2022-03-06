using M01_DAL_Municipalite_SQLServer.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;

namespace M01_DAL_Municipalite_SQLServer
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {
            ;
        }

        public DbSet<MunicipaliteDTO> Municipalite { get; set; }
    }
}
