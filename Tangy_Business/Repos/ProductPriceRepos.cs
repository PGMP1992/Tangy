using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repos.IRepos;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repos
{
    public class ProductPriceRepos : IProductPriceRepos
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ProductPriceRepos(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductPriceDTO> Create(ProductPriceDTO objDTO)
        {
            var obj = _mapper.Map<ProductPriceDTO, ProductPrice>(objDTO);

            var addedObj = _db.ProductPrices.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductPrice, ProductPriceDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.ProductPrices.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.ProductPrices.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0; // No success
        }

        public async Task<ProductPriceDTO> Get(int id)
        {
            var obj = await _db.ProductPrices.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<ProductPrice, ProductPriceDTO>(obj);
            }
            return new ProductPriceDTO();
        }

        public async Task<IEnumerable<ProductPriceDTO>> GetAll(int? id = null)
        {
            if(id != null && id > 0)
            {
                return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>
                    (_db.ProductPrices.Where(u => u.ProductId == id));
            } else {
                return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>
                    (_db.ProductPrices);
            }
        }

        public async Task<ProductPriceDTO> Update(ProductPriceDTO objDTO)
        {
            var objFromDB = await _db.ProductPrices.FirstOrDefaultAsync(x => x.Id == objDTO.Id);
            if (objFromDB != null)
            {
                objFromDB.ProductId = objDTO.ProductId;
                objFromDB.Size = objDTO.Size;
                objFromDB.Price = objDTO.Price;
                
                _db.ProductPrices.Update(objFromDB);
                _db.SaveChangesAsync();
                return _mapper.Map<ProductPrice, ProductPriceDTO>(objFromDB);
            }
            return objDTO;
        }
    }
}
