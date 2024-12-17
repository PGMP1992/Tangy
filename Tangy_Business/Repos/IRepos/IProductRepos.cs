using Tangy_Models;

namespace Tangy_Business.Repos.IRepos
{
    public interface IProductRepos
    {
        public ProductDTO Create(ProductDTO obj);
        public ProductDTO Update(ProductDTO obj);
        public int Delete(int id);
        public ProductDTO Get(int id);
        public IEnumerable<ProductDTO> GetAll();
    }
}
