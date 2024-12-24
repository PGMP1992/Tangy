using Microsoft.EntityFrameworkCore;
using Radzen;
using Tangy_Business.Repos;
using Tangy_Business.Repos.IRepos;
using Tangy_DataAccess.Data;
using TangyWeb_Server.Components;
using TangyWeb_Server.Service;
using TangyWeb_Server.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();
builder.Services.AddScoped<IProductRepos, ProductRepos>();
builder.Services.AddScoped<IProductPriceRepos, ProductPriceRepos>();
builder.Services.AddScoped<IFileUpload, FileUpload>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddRadzenComponents();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
