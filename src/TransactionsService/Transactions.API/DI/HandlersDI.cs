using Transactions.Application.Handlers.Cards;
using Transactions.Application.Handlers.Transactions;

namespace Transactions.API.DI
{
    public static class HandlersDI
    {
        public static IServiceCollection AddCardHandlers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<CreateCardCommandHandler>();
            serviceCollection.AddScoped<DeleteCardCommandHandler>();
            serviceCollection.AddScoped<DeleteUserCardsCommandHandler>();
            serviceCollection.AddScoped<GetDetailCardQueryHandler>();
            serviceCollection.AddScoped<GetUserCardsQueryHandler>();
            serviceCollection.AddScoped<UpdateCardCommandHandler>();

            return serviceCollection;
        }
        public static IServiceCollection AddTransactionHandlers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<CardsTransactionCommandHandler>();
            serviceCollection.AddScoped<DetailTransactionQueryHandler>();
            serviceCollection.AddScoped<UserTransactionsQueryHandler>();

            return serviceCollection;
        }
    }
}
