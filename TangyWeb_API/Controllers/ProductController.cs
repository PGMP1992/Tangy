using Microsoft.AspNetCore.Mvc;
using Tangy_Business.Repos.IRepos;
using Tangy_Models;

namespace TangyWeb_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepos _productRepos;

        public ProductController(IProductRepos productRepos)
        {
            _productRepos = productRepos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepos.GetAll()); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest(new ErrorModelDTO() 
                { 
                    ErrorMessage = " Invalid Id", 
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
            var product = await _productRepos.Get(id.Value);
            if (product  == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = " Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                });

            }
            return Ok(product);
        }
    }
}
