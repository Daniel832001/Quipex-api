using MediatR;
using Quipex.Application.Commands;
using Quipex.Application.Interfaces;
using Quipex.Domain.Entities;

namespace Quipex.Application.Handlers;

internal class CreateCompanyRecordHandler : IRequestHandler<CreateCompanyRecordCommand, Unit>
{
    private readonly ICompanyRecordRepository _repository;

    public CreateCompanyRecordHandler(ICompanyRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateCompanyRecordCommand command, CancellationToken cancellationToken)
    {
        var commandRecord = new CompanyRecord(command.Name, command.StockTicker, command.Exchange, command.ISIN, command.Website);
        await _repository.AddAsync(commandRecord);

        return Unit.Value;
    }
}
