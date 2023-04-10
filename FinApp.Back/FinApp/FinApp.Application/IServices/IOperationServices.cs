using FinApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.IServices
{
    public interface IOperationServices
    {
        Task<IEnumerable<OperationModel>?> GetOperationsByDescriptionAsync(string description);
        Task<OperationModel?> GetOperationsByIdAsync(int id);
        Task<IEnumerable<OperationModel>?> GetOperationsAsync();
        Task<OperationModel?> AddOperation(OperationModel model);
        Task<OperationModel?> UpdateOperation(int id, OperationModel model);
        Task<bool> DeleteOperation(int id);
    }
}
