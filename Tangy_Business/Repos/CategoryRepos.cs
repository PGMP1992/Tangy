﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repos.IRepos;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repos
{
    public class CategoryRepos : ICategoryRepos
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepos(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            obj.CreatedDate = DateTime.Now;

            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0; // No success
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO() { Name = "" };
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            var objFromDB = await _db.Categories.FirstOrDefaultAsync(x => x.Id == objDTO.Id);
            if (objFromDB != null)
            {
                objFromDB.Name = objDTO.Name;
                _db.Categories.Update(objFromDB);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDB);
            }
            return objDTO;

        }
    }
}
