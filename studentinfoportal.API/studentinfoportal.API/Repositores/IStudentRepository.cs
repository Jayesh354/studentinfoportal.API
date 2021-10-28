using studentinfoportal.API.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace studentinfoportal.API.Repositores
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetStudentsAsync();
    }
}
