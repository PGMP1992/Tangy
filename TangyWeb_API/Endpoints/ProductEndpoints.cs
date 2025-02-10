using Tangy_Business.Repos.IRepos;
using Tangy_Models;

namespace TangyWeb_API.Endpoints
{
    public static class ProductEndpoints
    {
        public static WebApplication MapProductEndpoints(this WebApplication app)
        {
            app.MapGet("/api/product", async (IProductRepos _prodRepos) =>
                await _prodRepos.GetAll());
            
            app.MapGet("/api/product/{id:int}", async (IProductRepos _prodRepos, int id) =>
            {
                var prod = await _prodRepos.Get(id);
                return prod is not null ? Results.Ok(prod) : Results.NotFound();
            });

            app.MapPost("/api/product", async (IProductRepos _prodRepos, ProductDTO prodDTO) =>
            {
                var prod = await _prodRepos.Create(prodDTO);
                return prod is not null ? Results.Ok(prod) : Results.NotFound();
            });

            app.MapPut("/api/product", async (IProductRepos _prodRepos, ProductDTO prodDTO) =>
            {
                var prod = await _prodRepos.Update(prodDTO);
                return prod is not null ? Results.Ok(prod) : Results.NotFound();
            });

            app.MapDelete("/api/product/{id:int}", async (IProductRepos _prodRepos, int id) =>
            {
                var prod = await _prodRepos.Delete(id);
                return prod > 0 ? Results.Ok(prod) : Results.NotFound();
            });

            return app;
        }
    }
}
