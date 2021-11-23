using studentinfoportal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace studentinfoportal.API.Repositores
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentAsync(Guid studentId);
        public Task<List<Gender>> GetAllGendersAsync();

        public Task<bool> Exists(Guid studentId);

        public Task<Student> UpdateStudent(Guid studentId, Student studentRequest);

        public Task<Student> DeleteStudent(Guid studentId);

        public Task<Student> AddNewStudent(Student student);

        public Task<bool> UpdateProfileImageURL(Guid studentId, string profileImageURL);

    }
}
