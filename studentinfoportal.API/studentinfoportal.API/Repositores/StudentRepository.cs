using Microsoft.EntityFrameworkCore;
using studentinfoportal.API.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace studentinfoportal.API.Repositores
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository(StudentContext context)
        {
            Context = context;
        }

        public StudentContext Context { get; }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await Context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
