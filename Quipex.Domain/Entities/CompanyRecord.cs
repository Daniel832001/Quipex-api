
using Quipex.Domain.Exceptions;

namespace Quipex.Domain.Entities;

public class CompanyRecord
{
    // for ef
    private CompanyRecord() { }

    public CompanyRecord(string name, string stockTicker, string exchange, string Isin, string? website)
    {
        if (string.IsNullOrWhiteSpace(Isin) || Isin.Length != 12 || char.IsDigit(Isin[0]) || char.IsDigit(Isin[1]))
        {
            throw new InvalidCompanyRecordISINException(Isin);
        }

        Id = 0;
        Name = name;
        StockTicker = stockTicker;
        Exchange = exchange;
        ISIN = Isin;
        Website = website;
    }

    public long Id { get; }
    public string Name { get; set; }
    public string StockTicker { get; set; }
    public string Exchange { get; set; }
    public string ISIN { get; set; }
    public string? Website { get; set; }
}
