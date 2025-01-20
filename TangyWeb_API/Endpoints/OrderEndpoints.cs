using Tangy_Business.Repos.IRepos;

namespace TangyWeb_API.Endpoints
{
    public static class OrderEndpoints
    {
        public static WebApplication MapOrderEndpoints(this WebApplication app)
        {
            app.MapGet("/api/order", async (IOrderRepos _orderRepos) =>
                await _orderRepos.GetAll());
            
            app.MapGet("/api/order/{id:int}", async (IOrderRepos _orderRepos, int id) =>
            {
                var order = await _orderRepos.Get(id);
                return order is not null ? Results.Ok(order) : Results.NotFound();
            });

            return app;
        }
    }
}
