using FluentValidation.Results;
using Shared.Core.Abstractions;
using Transactions.Application.Contracts.Requests;

namespace Transactions.Application.Handlers.Transactions
{
    public class CreateTransactionCommandHandler : IHandlerAsync<ValidationResult, CreateTransactionRequest>
    {
        public async Task<ValidationResult> HandleAsync(CreateTransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
