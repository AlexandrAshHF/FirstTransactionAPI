using Microsoft.EntityFrameworkCore;
using Transactions.API.DI;
using Transactions.Persistance;

namespace Transactions.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connectionString = builder.Configuration.GetConnectionString("LocalConnection");
            builder.Services.AddDbContext<ApplicationContext>
                (options => options.UseSqlServer(connectionString, opth => opth.MigrationsAssembly("Transactions.Persistance")));

            builder.Services.AddCardHandlers();
            builder.Services.AddTransactionHandlers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
