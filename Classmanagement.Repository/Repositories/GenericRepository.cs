using ClassManagement.Api.AppContext;
using ClassManagement.Api.Entities;
using Classmanagement.Repository.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classmanagement.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            //_validator.ValidateAndThrow(entity);

            try
            {
                await _table.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _table.SingleOrDefaultAsync(x => x.Id == id);
            if (entity != null)
                _table.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var entities = await _table.Select(x => x).ToListAsync();
                return entities;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await _table.SingleOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<T> Update(Guid id, JsonPatchDocument patchDocument)
        {
            var entity = await _table.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();
            patchDocument.ApplyTo(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


    }
}
