using Microsoft.EntityFrameworkCore;
using studentinfoportal.API.DataModels;
using System;
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

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await Context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Gender>> GetAllGendersAsync()
        {
            return await Context.Gender.ToListAsync();
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await Context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student studentRequest)
        {
            var existingStudent = await GetStudentAsync(studentId);

            if (existingStudent != null)
            {
                existingStudent.FirstName = studentRequest.FirstName;
                existingStudent.LastName = studentRequest.LastName;
                existingStudent.Email = studentRequest.Email;
                existingStudent.Mobile = studentRequest.Mobile;
                existingStudent.GenderId = studentRequest.GenderId;
                existingStudent.DateOfBirth = studentRequest.DateOfBirth;
                existingStudent.Address.PhysicalAddress = studentRequest.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = studentRequest.Address.PostalAddress;

                await Context.SaveChangesAsync();
                return existingStudent;
            }

            return null;
        }
    }
}
