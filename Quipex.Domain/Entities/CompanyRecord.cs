
using System.Data;
using Quipex.Domain.Exceptions;

namespace Quipex.Domain.Entities;

public class CompanyRecord
{
    // for ef
    private CompanyRecord() { }

    public CompanyRecord(string name, string stockTicker, string exchange, string isin, string? website)
    {
        validateISIN(isin);
        Id = 0;
        Name = name;
        StockTicker = stockTicker;
        Exchange = exchange;
        ISIN = isin;
        Website = website;
    }

    public long Id { get; }
    public string Name { get; set; }
    public string StockTicker { get; set; }
    public string Exchange { get; set; }
    public string ISIN { get; set; }
    public string? Website { get; set; }

    public void Update(string name, string stockTicker, string exchange, string isin, string? website)
    {
        validateISIN(isin);
        Name = name;
        StockTicker = stockTicker;
        Exchange = exchange;
        ISIN = isin;
        Website = website;
    }

    private void validateISIN(string isin)
    {
        if (string.IsNullOrWhiteSpace(isin) || isin.Length != 12 || char.IsDigit(isin[0]) || char.IsDigit(isin[1]))
        {
            throw new InvalidCompanyRecordISINException(isin);
        }
    }
}
