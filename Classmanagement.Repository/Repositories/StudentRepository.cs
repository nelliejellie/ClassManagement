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
    public class StudentRepository : IStudentRepository
    {
        public Task<Student> Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Update(string id, JsonPatchDocument patchDocument)
        {
            throw new NotImplementedException();
        }
    }
}
