using FinApp.Data.Entities;
using FinApp.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Data.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<OperationEntity> Operation { get; set; }
        public DbSet<FinancialReleaseEntity> FinancialRelease { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FinancialReleaseEntity>(x =>
            {
                x.HasOne(e => e.Operations)
                  .WithMany(e => e.FinancialRelease)
                  .HasForeignKey(e => e.OperationId)
                  .OnDelete(DeleteBehavior.Cascade);
            }
           );
            modelBuilder.SeedModel();
        }
        
    }
}