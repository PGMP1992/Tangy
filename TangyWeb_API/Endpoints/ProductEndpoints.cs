using Tangy_Business.Repos.IRepos;

namespace TangyWeb_API.Endpoints
{
    public static class ProductEndpoints
    {
        public static WebApplication MapProductEndpoints(this WebApplication app)
        {
            app.MapGet("/api/product", async (IProductRepos _prodRepos) =>
                await _prodRepos.GetAll());
            //await context.Products
            ////.Include(p => p.Category)
            ////.Include(p => p.ProductPrices)
            //.ToListAsync());

            app.MapGet("/api/product/{id:int}", async (IProductRepos _prodRepos, int id) =>
            {
                var prod = await _prodRepos.Get(id);
                //.Include(p => p.Category)
                //.Include(p => p.ProductPrices)
                //.FirstOrDefaultAsync(p => p.Id == id);
                return prod is not null ? Results.Ok(prod) : Results.NotFound();
            });

            return app;
        }
    }
}
