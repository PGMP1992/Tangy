using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repos.IRepos;
using Tangy_Business.Repos;
using Tangy_DataAccess.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwagger();
//Same as WebServer
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();
builder.Services.AddScoped<IProductRepos, ProductRepos>();
builder.Services.AddScoped<IProductPriceRepos, ProductPriceRepos>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
