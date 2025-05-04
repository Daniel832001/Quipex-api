using MediatR;
using Quipex.Application.DTOs;

namespace Quipex.Application.Queries;

public class GetCompanyRecordByIdQuery : IRequest<CompanyRecordDto>
{
    public GetCompanyRecordByIdQuery(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}