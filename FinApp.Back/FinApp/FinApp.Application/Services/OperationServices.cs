using AutoMapper;
using FinApp.Application.IServices;
using FinApp.Data.Entities;
using FinApp.Data.IRepository;
using FinApp.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Services
{
    public class OperationServices : IOperationServices
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;
        public OperationServices(IBaseRepository baseRepository, IOperationRepository operationRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OperationModel>?> GetOperationsByDescriptionAsync(string description)
        {
            try
            {
                var operation = await _operationRepository.GetOperationsByDescriptionAsync(description);
                if (operation == null) return null;
                var result = _mapper.Map<OperationModel[]>(operation);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<OperationModel?> GetOperationsByIdAsync(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("id must be greater than 0");
                var operation = await _operationRepository.GetOperationsByIdAsync(id);
                if (operation == null) return null;
                var result = _mapper.Map<OperationModel>(operation);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<OperationModel>?> GetOperationsAsync()
        {
            try
            {
                var operation = await _operationRepository.GetOperationAsync();
                if (operation == null) return null;
                var result = _mapper.Map<OperationModel[]>(operation);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<OperationModel?> AddOperation( OperationModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Description) || string.IsNullOrEmpty(model.Status))
                    throw new Exception("operation must contain values");
                if(model.FinancialRelease.Count() == 0)
                    throw new Exception("the financial release must contain values");
                var operation = _mapper.Map<OperationEntity>(model);

                _baseRepository.Add<OperationEntity>(operation);

                if (await _baseRepository.SaveChangesAsync())
                {
                    var result = await _operationRepository.GetOperationsByIdAsync(operation.Id);

                    return _mapper.Map<OperationModel>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<OperationModel?> UpdateOperation(int id, OperationModel model)
        {
            try
            {
                if (id== 0)
                    throw new Exception("id must be greater than 0");
                var operation = await _operationRepository.GetOperationsByIdAsync(id);
                if (operation == null) return null;
                var FinancialToDelete = operation?.FinancialRelease?
               .Where( x => model.FinancialRelease
               .All(y => y.Id != x.Id)).ToArray();
                if (FinancialToDelete.Any())
                    _baseRepository.DeleteRange<FinancialReleaseEntity>(FinancialToDelete);
                model.Id = operation.Id;
                _mapper.Map(model, operation);
                _baseRepository.Update<OperationEntity>(operation);
                if (await _baseRepository.SaveChangesAsync())
                {
                    var result = await _operationRepository.GetOperationsByIdAsync(operation.Id);

                    return _mapper.Map<OperationModel>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteOperation( int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("id must be greater than 0");
                var operation = await _operationRepository.GetOperationsByIdAsync(id);
                if (operation == null) throw new Exception("Operation not found.");

                _baseRepository.Delete<OperationEntity>(operation);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
