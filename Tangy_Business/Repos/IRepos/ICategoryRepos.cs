using Tangy_Models;

namespace Tangy_Business.Repos.IRepos
{
    public interface ICategoryRepos
    {
        public CategoryDTO Create(CategoryDTO obj);
        public CategoryDTO Update(CategoryDTO obj);
        public int Delete(int id);
        public CategoryDTO Get(int id);
        public IEnumerable<CategoryDTO> GetAll();
    }
}
