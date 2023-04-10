using FinApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Data.Seeds
{
    public static class ModelSeed
    {
        public static void SeedModel(this ModelBuilder builder)
        {
            SeedOperation(builder);
            SeedFinancialRelease(builder);
        }
        private static void SeedOperation(ModelBuilder builder)
        {
            builder.Entity<OperationEntity>().HasData(new OperationEntity()
            {
                Id = 1,
                Description = "EMPRESA XYP",
                Status = "Enviando",
                
            });
         
        }

        private static void SeedFinancialRelease(ModelBuilder builder)
        {
            builder.Entity<FinancialReleaseEntity>().HasData(new FinancialReleaseEntity()
            {
                Id = 1,
                OperationId = 1,
                CNPJ = "15098917000148",
                Name = "EMPRESA XYP",
                Phone = "47 9998-74566",
                ZipCode = "89295-024",
                Address = "Rua dos Canários, 123",
                State = "PR",
                City = "Curitiba",
                District = "Centro",
                ReleaseDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Discount = 20000m,
                Amount = 40000m,
                Number = "ID 9932931",
                

            });
            builder.Entity<FinancialReleaseEntity>().HasData(new FinancialReleaseEntity()
            {
                Id = 2,
                OperationId = 1,
                CNPJ = "15098917000148",
                Name = "EMPRESA XYP",
                Phone = "47 9998-74566",
                ZipCode = "89295-024",
                Address = "Rua dos Canários, 123",
                State = "PR",
                City = "Curitiba",
                District = "Centro",
                ReleaseDate = DateTime.Now.AddDays(30),
                DueDate = DateTime.Now.AddDays(60),
                Discount = 20000m,
                Amount = 40000m,
                Number = "ID 9932931",


            });
            builder.Entity<FinancialReleaseEntity>().HasData(new FinancialReleaseEntity()
            {
                Id = 3,
                OperationId = 1,
                CNPJ = "15098917000148",
                Name = "EMPRESA XYP",
                Phone = "47 9998-74566",
                ZipCode = "89295-024",
                Address = "Rua dos Canários, 123",
                State = "PR",
                City = "Curitiba",
                District = "Centro",
                ReleaseDate = DateTime.Now.AddDays(60),
                DueDate = DateTime.Now.AddDays(90),
                Discount = 20000m,
                Amount = 40000m,
                Number = "ID 9932931",


            });

        }

    }
}
