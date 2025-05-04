using AutoMapper;
using Quipex.Domain.Entities;
using Quipex.Application.DTOs;

namespace Quipex.Application.Mappings;

public class CompanyRecordProfile : Profile
{
    public CompanyRecordProfile()
    {
        CreateMap<CompanyRecord, CompanyRecordDto>();
    }
}
