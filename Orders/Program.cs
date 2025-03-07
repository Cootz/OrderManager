using Microsoft.EntityFrameworkCore;
using Orders.Implementation.Database;
using Orders.Implementation.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddScoped<OrdersProvider>()
    .AddOpenApi()
    .AddCors(options =>
    {
        options.AddDefaultPolicy(policy => 
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    })
    .AddDbContext<OrdersDbContext>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString("OrdersDatabase")))
    .AddControllers();

var app = builder.Build();

app.MapOpenApi();
app.UseCors();

// Ensuring database exists and up to date
using (IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    OrdersDbContext context = serviceScope.ServiceProvider.GetRequiredService<OrdersDbContext>();

    context.Database.Migrate();
}

app.MapControllers();

app.Run();
