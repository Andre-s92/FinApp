using AutoMapper;
using FinApp.Application.Services;
using FinApp.Data.IRepository;
using FinApp.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Test.Services
{
    public class OperationServiceTests
    {
        private OperationServices services;
        
        public OperationServiceTests()
        {
            services = new OperationServices(new Mock<IBaseRepository>().Object, new Mock<IOperationRepository>().Object, new Mock<IMapper>().Object);
        }
        // Operation Model Preenchido
        OperationModel operation = new OperationModel()
        {
            Id = 1,
            Description = "EMPRESA XYP",
            Status = "enviando",
             FinancialRelease = new List<FinancialReleaseModel> 
             {
                new FinancialReleaseModel 
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
                },
                 new FinancialReleaseModel
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
                ReleaseDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Discount = 20000m,
                Amount = 40000m,
                Number = "ID 9932931",
                }, new FinancialReleaseModel
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
                ReleaseDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Discount = 20000m,
                Amount = 40000m,
                Number = "ID 9932931",
                }
             }

        };
        // Operation Model Preenchido sem dados no Financial Release
        OperationModel operationWithoutDataFinancialRelease = new OperationModel()
        {
            Id = 1,
            Description = "EMPRESA XYP",
            Status = "enviando",
            FinancialRelease = new FinancialReleaseModel[] { }
        };
        // Operation Model Preenchido sem Financial Release
        OperationModel operationWithoutFinancialRelease = new OperationModel()
        {
            Id = 1,
            Description = "EMPRESA XYP",
            Status = "enviando",
        };
        //Operation Model Vazio
        OperationModel operationEmpty = new OperationModel();

        [Fact]
        //Verifica se o campo name do financialRelease tem mais de 8 caracteries
        public void Verify_If_Name_have_more_then_8_char()
        {
            var name ="";
            foreach (var release in operation.FinancialRelease)
            {
                 name = release.Name;
            }
            var result = services.AddOperation(operation);
            Assert.True(name.Length >= 8);
        }
        [Fact]
        /*Valida se o Operation Model tem dados como name e description para inserir no banco, foi passado um um model
         vazio (operationEmpty) para validação, caso a exceção retorne a mensagem de erro o teste foi concluido com sucesso */
        
        public async void ValidatePostOperationData()
        {
           var exception = await Assert.ThrowsAsync<Exception>(() => services.AddOperation(operationEmpty));
            Assert.Equal("operation must contain values",exception.Message);
        }
        [Fact]
        /*Valida se o FinancialRelease Model tem dados para inserir no banco, foi passado um um model com financial release
         vazio (operationWithoutDataFinancialRelease) para validação, caso a exceção retorne a mensagem de erro o teste foi concluido com sucesso */

        public async void ValidatePostFinancialReleaseWithoutData()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => services.AddOperation(operationWithoutDataFinancialRelease));
            Assert.Equal("the financial release must contain values", exception.Message);
        }
        [Fact]
        /*Valida se o operation tem financial release, foi passado um um model sem financial release
         (operationWithoutFinancialRelease) para validação, caso a exceção retorne a mensagem de erro o teste foi concluido com sucesso */

        public async void ValidatePostFinancialReleaseData()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => services.AddOperation(operationWithoutFinancialRelease));
            Assert.Equal("Value cannot be null. (Parameter 'source')", exception.Message);
        }
        [Fact]
        /*Valida se o id informado ao fazer a alteração dos dados é igual a zero, caso seja o teste vai retornar uma mensagem de erro */

        public async void ValidatePutOperationId()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => services.UpdateOperation(0,operation));
            Assert.Equal("id must be greater than 0", exception.Message);
        }
        [Fact]
        /*Valida se o id informado ao fazer a consulta por id é igual a zero, caso seja o teste vai retornar uma mensagem de erro */

        public async void ValidateGetOperationId()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => services.GetOperationsByIdAsync(0));
            Assert.Equal("id must be greater than 0", exception.Message);
        }
        [Fact]
        /*Valida se o id informado ao fazer a exclusão por id é igual a zero, caso seja o teste vai retornar uma mensagem de erro */

        public async void ValidateDeleteOperationId()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => services.DeleteOperation(0));
            Assert.Equal("id must be greater than 0", exception.Message);
        }
    }
}
