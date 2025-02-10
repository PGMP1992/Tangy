using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Tangy_Business.Repos;
using Tangy_Business.Repos.IRepos;
using Tangy_DataAccess.Data;
using TangyWeb_Server.Components.Account;
using TangyWeb_Server.Service;
using TangyWeb_Server.Service.IService; // Add this line to resolve the conflict

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Rest of the code remains unchanged
builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();
builder.Services.AddScoped<IProductRepos, ProductRepos>();
builder.Services.AddScoped<IProductPriceRepos, ProductPriceRepos>();
builder.Services.AddScoped<IFileUpload, FileUpload>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddRadzenComponents();

// Added for Authentication - PM
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
// End - > Added for Authentication - PM

builder.Services.AddSingleton<IEmailSender<IdentityUser>, IdentityNoOpEmailSender>();

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
app.UseAuthentication(); /*Added might be wrong ????? */
app.UseAuthorization();  /*Added might be wrong ????? */
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<TangyWeb_Server.Components.App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.Run();
