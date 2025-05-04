using Quipex.Domain.Entities;

namespace Quipex.Application.Interfaces;

public interface ICompanyRecordQueryDataStore
{
    Task<IEnumerable<CompanyRecord>> GetAllAsync();
    Task<CompanyRecord> GetCompanyRecordByIdAsync(long id);
}
