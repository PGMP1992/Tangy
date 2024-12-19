using Tangy_Models;

namespace Tangy_Business.Repos.IRepos
{
    public interface IProductPriceRepos
    {
        public Task<ProductPriceDTO> Create(ProductPriceDTO obj);
        public Task<ProductPriceDTO> Update(ProductPriceDTO obj);
        public Task<int> Delete(int id);
        public Task<ProductPriceDTO> Get(int id);
        public Task<IEnumerable<ProductPriceDTO>> GetAll(int? id = null);
    }
}
