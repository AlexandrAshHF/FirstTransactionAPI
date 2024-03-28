using Quotes.Application.Implementation;
using Quotes.Core.Abstractions;

namespace Quotes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "quotes";
            });

            builder.Services.AddTransient<IRateTracker, HttpRateTracker>();
            builder.Services.AddScoped<QuotesQueryHandler>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGet("/rates", async (QuotesQueryHandler handler) =>
            {
                var result = await handler.HandleAsync(null);
            
                return Results.Ok(result);
            });

            app.Run();
        }
    }
}