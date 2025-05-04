using MediatR;
using Quipex.Application.DTOs;

namespace Quipex.Application.Queries;

public class GetCompanyRecordsQuery : IRequest<IEnumerable<CompanyRecordDto>>;