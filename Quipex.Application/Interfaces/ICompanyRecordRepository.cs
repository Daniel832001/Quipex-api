using Quipex.Domain.Entities;

namespace Quipex.Application.Interfaces;

public interface ICompanyRecordRepository
{
    Task AddAsync(CompanyRecord companyRecord);
}
