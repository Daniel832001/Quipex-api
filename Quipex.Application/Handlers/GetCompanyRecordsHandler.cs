using AutoMapper;
using MediatR;
using Quipex.Application.Commands;
using Quipex.Application.DTOs;
using Quipex.Application.Interfaces;
using Quipex.Application.Queries;
using Quipex.Domain.Entities;

namespace Quipex.Application.Handlers;

internal class GetCompanyRecordsHandler : IRequestHandler<GetCompanyRecordsQuery, IEnumerable<CompanyRecordDto>>
{
    private readonly ICompanyRecordQueryDataStore _queryDataStore;
    private readonly IMapper _mapper;
    public GetCompanyRecordsHandler(ICompanyRecordQueryDataStore queryDataStore, IMapper mapper)
    {
        _queryDataStore = queryDataStore;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompanyRecordDto>> Handle(GetCompanyRecordsQuery query, CancellationToken cancellationToken)
    {
        var result = await _queryDataStore.GetCompanyRecordsAsync();
        return _mapper.Map<IEnumerable<CompanyRecordDto>>(result);
    }
}
