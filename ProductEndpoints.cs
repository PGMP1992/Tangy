using System;

public static class ProductEndpoints
{
	public static WebApplication MapProductEndpoints ( this WebApplication app)
	{
		app.MapGet("/api/products"), async (AppDbContext context) =>
			await context.Products.ToListAsync();
	}
	
}
