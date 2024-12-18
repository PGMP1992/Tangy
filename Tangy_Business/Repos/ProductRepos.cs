using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repos.IRepos;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repos
{
    public class ProductRepos : IProductRepos
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepos(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO objDTO)
        {
            var obj = _mapper.Map<ProductDTO, Product>(objDTO);

            var addedObj = _db.Products.Add(obj);
            _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Products.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0; // No success
        }

        public async Task<ProductDTO> Get(int id)
        {
            var obj = await _db.Products.Include(p=>p.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO() { 
                Category = new CategoryDTO { }
            };
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(p=>p.Category));
        }

        public async Task<ProductDTO> Update(ProductDTO objDTO)
        {
            var objFromDB = await _db.Products.FirstOrDefaultAsync(x => x.Id == objDTO.Id);
            if (objFromDB != null)
            {
                objFromDB.Name = objDTO.Name;
                objFromDB.Description = objDTO.Description;
                objFromDB.ImageUrl = objDTO.ImageUrl;
                objFromDB.CategoryId = objDTO.CategoryId;
                objFromDB.Color = objDTO.Color;
                objFromDB.ShopFavorites = objDTO.ShopFavorites;
                objFromDB.CustomerFavorites = objDTO.CustomerFavorites;

                _db.Products.Update(objFromDB);
                _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(objFromDB);
            }
            return objDTO;

        }
    }
}
