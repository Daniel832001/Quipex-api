namespace Quipex.Application.DTOs;

public class CompanyRecordDto
{
    public CompanyRecordDto(long id, string name, string stockTicker, string exchange, string Isin, string? website)
    {
        Id = id;
        Name = name;
        StockTicker = stockTicker;
        Exchange = exchange;
        ISIN = Isin;
        Website = website;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string StockTicker { get; set; }
    public string Exchange { get; set; }
    public string ISIN { get; set; }
    public string? Website { get; set; }
}
