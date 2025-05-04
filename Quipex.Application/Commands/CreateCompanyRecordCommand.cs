using System.Xml.Linq;
using MediatR;

namespace Quipex.Application.Commands;

public class CreateCompanyRecordCommand : IRequest<Unit>
{
    public CreateCompanyRecordCommand(string name, string stockTicker, string exchange, string Isin, string? website)
    {
        Name = name;
        StockTicker = stockTicker;
        Exchange = exchange;
        ISIN = Isin;
        Website = website;
    }

    public string Name { get; set; }
    public string StockTicker { get; set; }
    public string Exchange { get; set; }
    public string ISIN { get; set; }
    public string? Website { get; set; }
}