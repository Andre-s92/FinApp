using FinApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Data.IRepository
{
    public interface IOperationRepository
    {
        Task<OperationEntity> GetOperationsByIdAsync(int id);
        Task<IEnumerable<OperationEntity>> GetOperationsByDescriptionAsync(string description);
        Task<IEnumerable<OperationEntity>> GetOperationAsync();
    }
}
