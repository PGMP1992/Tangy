using Tangy_Models;

namespace Tangy_Business.Repos.IRepos
{
    public interface IProductRepos
    {
        public Task<ProductDTO> Create(ProductDTO obj);
        public Task<ProductDTO> Update(ProductDTO obj);
        public Task<int> Delete(int id);
        public Task<ProductDTO> Get(int id);
        public Task<IEnumerable<ProductDTO>> GetAll();
    }
}
