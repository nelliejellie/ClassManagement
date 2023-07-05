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
        Task<bool> Delete(string id);
        Task<T> Update(string id, JsonPatchDocument patchDocument);
        Task<T> GetById(string id);

        Task<T> GetAll();
    }
}
