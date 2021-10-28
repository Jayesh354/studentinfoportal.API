using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using studentinfoportal.API.DomainModels;
using studentinfoportal.API.Repositores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace studentinfoportal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            StudentRepository = studentRepository;
            this.mapper = mapper;
        }

        public IStudentRepository StudentRepository { get; }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            var studnetDomanin = await StudentRepository.GetStudentsAsync();
            return Ok(mapper.Map<List<Student>>(studnetDomanin));

        }
    }
}
