using Quipex.Domain.Entities;

namespace Quipex.Application.Interfaces;

public interface ICompanyRecordRepository
{
    Task AddAsync(CompanyRecord companyRecord);
    Task UpdateAsync(long id, string name, string stockTicker, string exchange, string isin, string? website);
}
