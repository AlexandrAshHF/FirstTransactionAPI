using Microsoft.EntityFrameworkCore;
using Shared.Core.Abstractions;
using Transactions.Persistance;

namespace Transactions.Application.Handlers.Cards
{
    public class DeleteUserCardsCommandHandler : IHandlerAsync<List<Guid>, Guid>
    {
        private ApplicationContext _context;
        public DeleteUserCardsCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Guid>> HandleAsync(Guid request)
        {
            var cards = await Task.Run(async () => await _context.Cards
            .Where(x => x.UserId == request)
            .ToListAsync());

            _context.RemoveRange(cards);
            await _context.SaveChangesAsync();

            return cards.Select(x => x.Id).ToList();
        }
    }
}
