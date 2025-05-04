namespace Quipex.Api.Requests;

public class UpdateCompanyRecordRequest
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string StockTicker { get; set; }
    public string Exchange { get; set; }
    public string ISIN { get; set; }
    public string? Website { get; set; }
}
