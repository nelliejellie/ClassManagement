using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classmanagement.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<T> Update(Guid id, JsonPatchDocument patchDocument);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
