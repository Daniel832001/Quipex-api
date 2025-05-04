using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quipex.Application.Exceptions;
using Quipex.Application.Interfaces;
using Quipex.Domain.Entities;

namespace Quipex.Persistence.Repositories;

public class CompanyRecordRepository : ICompanyRecordRepository
{
    private readonly AppDbContext _context;

    public CompanyRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CompanyRecord companyRecord)
    {
        try { 
            await _context.CompanyRecords.AddAsync(companyRecord);
            var numRowsAffected = await _context.SaveChangesAsync();
            if (numRowsAffected != 1)
            {
                throw new Exception("Insert failed. No rows affected.");
            }

        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
        {
            throw new DuplicateISINException(companyRecord.ISIN);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error while saving.");
        }
    }

    public async Task UpdateAsync(long id, string name, string stockTicker, string exchange, string isin, string? website)
    {
        var toBeUpdatedCompanyRecord = await _context.CompanyRecords.FindAsync(id);
        if (toBeUpdatedCompanyRecord == null)
        {
            throw new CompanyRecordNotFoundException(id);
        }

        toBeUpdatedCompanyRecord.Update(name, stockTicker, exchange, isin, website);

        try
        {
            var numRowsAffected = await _context.SaveChangesAsync();
            if (numRowsAffected != 1)
            {
                throw new Exception("Update failed. No rows affected.");
            }
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
        {
            throw new DuplicateISINException(isin);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error while saving.");
        }

    }

}
