using MediatR;
using Quipex.Application.Commands;
using Quipex.Application.Interfaces;
using Quipex.Domain.Entities;

namespace Quipex.Application.Handlers;

internal class UpdateCompanyRecordHandler : IRequestHandler<UpdateCompanyRecordCommand, Unit>
{
    private readonly ICompanyRecordRepository _repository;

    public UpdateCompanyRecordHandler(ICompanyRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateCompanyRecordCommand command, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(command.Id, command.Name, command.StockTicker, command.Exchange, command.ISIN, command.Website);

        return Unit.Value;
    }
}
