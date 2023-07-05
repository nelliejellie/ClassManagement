using Classmanagement.Repository.Interfaces;
using ClassManagement.Api.AppContext;
using ClassManagement.Api.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classmanagement.Repository.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context): base(context)
        {
            _context = context;
        }
    }
}
