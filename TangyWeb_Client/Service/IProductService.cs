using Tangy_Models;

namespace TangyWeb_Client.Service
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductDTO> Get(int id);
    }
}
