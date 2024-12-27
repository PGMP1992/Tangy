using Tangy_Models;

namespace TangyWeb_Client.Service
{
    public class ProductService : IProductService
    {
        public Task<ProductDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
