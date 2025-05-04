using Quipex.Domain.Entities;

namespace Quipex.Application.Interfaces;

public interface ICompanyRecordQueryDataStore
{
    Task<CompanyRecord> GetCompanyRecordByIdAsync(long id);
    Task<IEnumerable<CompanyRecord>> GetCompanyRecordsAsync();
}
