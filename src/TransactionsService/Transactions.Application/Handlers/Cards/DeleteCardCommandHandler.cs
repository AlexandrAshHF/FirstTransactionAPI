using Shared.Core.Abstractions;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Cards
{
    public class DeleteCardCommandHandler : IHandlerAsync<Guid, Guid>
    {
        private ApplicationContext _context;
        public DeleteCardCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Guid> HandleAsync(Guid request)
        {
            var card = await _context.Cards.FindAsync(request);

            if (card == null)
                return Guid.Empty;

            _context.Remove(card);
            await _context.SaveChangesAsync();

            return request;
        }
    }
}
