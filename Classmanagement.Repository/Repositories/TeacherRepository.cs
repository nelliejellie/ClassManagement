using Classmanagement.Repository.Interfaces;
using ClassManagement.Api.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classmanagement.Repository.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public Task<Teacher> Add(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> Update(string id, JsonPatchDocument patchDocument)
        {
            throw new NotImplementedException();
        }
    }
}
