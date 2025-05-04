using AutoMapper;
using MediatR;
using Quipex.Application.Commands;
using Quipex.Application.DTOs;
using Quipex.Application.Interfaces;
using Quipex.Application.Queries;
using Quipex.Domain.Entities;

namespace Quipex.Application.Handlers;

internal class GetCompanyRecordByIdHandler : IRequestHandler<GetCompanyRecordByIdQuery, CompanyRecordDto>
{
    private readonly ICompanyRecordQueryDataStore _queryDataStore;
    private readonly IMapper _mapper;
    public GetCompanyRecordByIdHandler(ICompanyRecordQueryDataStore queryDataStore, IMapper mapper)
    {
        _queryDataStore = queryDataStore;
        _mapper = mapper;
    }

    public async Task<CompanyRecordDto> Handle(GetCompanyRecordByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _queryDataStore.GetCompanyRecordByIdAsync(query.Id);
        return _mapper.Map<CompanyRecordDto>(result);
    }
}
