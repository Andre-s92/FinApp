using FinApp.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinApp.Domain.Models;
using FinApp.Data.Entities;

namespace FinApp.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<OperationModel, OperationEntity>().ReverseMap();
            CreateMap<OperationEntity, OperationModel>().ReverseMap();

            CreateMap<FinancialReleaseModel, FinancialReleaseEntity>().ReverseMap();
            CreateMap<FinancialReleaseEntity, FinancialReleaseModel>().ReverseMap();
        }
    }
}
