using Microsoft.EntityFrameworkCore;
using Quipex.Application.Exceptions;
using Quipex.Application.Interfaces;
using Quipex.Domain.Entities;

namespace Quipex.Persistence.QueryDataStores;

public class CompanyRecordQueryDataStore : ICompanyRecordQueryDataStore
{
    private readonly ReadDbContext _context;

    public CompanyRecordQueryDataStore(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CompanyRecord>> GetAllAsync()
    {
        return await _context.CompanyRecords.AsNoTracking().ToListAsync();
    }

    public async Task<CompanyRecord> GetCompanyRecordByIdAsync(long id)
    {
        var result = await _context.CompanyRecords.AsNoTracking().SingleOrDefaultAsync(r => r.Id == id);
        if (result == null){
            throw new CompanyRecordNotFoundException(id);
        }

        return result;
    }
}
