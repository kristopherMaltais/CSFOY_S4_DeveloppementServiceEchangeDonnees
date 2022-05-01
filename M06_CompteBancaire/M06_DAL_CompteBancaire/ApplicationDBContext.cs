using M06_DAL_CompteBancaire.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;

namespace M06_DAL_CompteBancaire
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<CompteSQLDTO> Comptes { get; set; }
        public DbSet<TransactionSQLDTO> Transactions { get; set; }
    }
}