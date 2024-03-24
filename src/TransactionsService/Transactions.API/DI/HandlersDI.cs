using Transactions.Application.Handlers.Cards;

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
            return serviceCollection;
        }
    }
}
