using FinApp.Data.Context;
using FinApp.Data.Entities;
using FinApp.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Data.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly DataContext _context;

        public OperationRepository( DataContext context)
        {
            _context = context;
        }

        public async Task<OperationEntity> GetOperationsByIdAsync(int id)
        {
            IQueryable<OperationEntity> query = _context.Operation.Include(e => e.FinancialRelease).AsNoTracking();
            return await query.OrderBy(e => e.Id).Where(e => e.Id == id).SingleAsync();
        }

        public async Task<IEnumerable<OperationEntity>> GetOperationsByDescriptionAsync(string description)
        {
            IQueryable<OperationEntity> query = _context.Operation.AsNoTracking()
                .Where(e => e.Description.Contains(description)).OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }
        public async Task<IEnumerable<OperationEntity>> GetOperationAsync()
        {
            IQueryable<OperationEntity> query = _context.Operation.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }
    }
}
