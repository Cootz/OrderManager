using Microsoft.EntityFrameworkCore;
using Orders.Implementation.Database;
using Orders.Implementation.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddScoped<OrdersProvider>()
    .AddOpenApi()
    .AddDbContext<OrdersDbContext>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString("OrdersDatabase")))
    .AddControllers();

var app = builder.Build();

app.MapOpenApi();

// Ensuring database exists and up to date
using (IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    OrdersDbContext context = serviceScope.ServiceProvider.GetRequiredService<OrdersDbContext>();

    context.Database.Migrate();
}

app.MapControllers();

app.Run();
