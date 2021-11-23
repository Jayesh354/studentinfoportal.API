using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentinfoportal.API.DomainModels;
using studentinfoportal.API.Repositores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace studentinfoportal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IImageUploadRepository imageUploadRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IImageUploadRepository imageUploadRepository,IMapper mapper)
        {
            StudentRepository = studentRepository;
            this.imageUploadRepository = imageUploadRepository;
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

        [HttpGet]
        [Route("[controller]/{studentId:guid}"),ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await StudentRepository.GetStudentAsync(studentId);

            if (student == null)
            {
                NotFound();
            }

            return Ok(mapper.Map<Student>(student));

        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId,[FromBody] UpdateStudnetRequest request)
        {
            if (await StudentRepository.Exists(studentId))
            {
                var updatedStudent = await StudentRepository.UpdateStudent(studentId,mapper.Map<DataModels.Student>(request));
                if (updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await StudentRepository.Exists(studentId))
            {
                // Call Delete Method

                var student = await StudentRepository.DeleteStudent(studentId);

                if (student != null)
                {

                    return Ok(mapper.Map<Student>(student));
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddNewStudent([FromBody] AddNewStudent request)
        {
            var student = await StudentRepository.AddNewStudent(mapper.Map<DataModels.Student>(request));

            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = student.Id }, mapper.Map<Student>(student));

        }

        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId,IFormFile profileImage)
        {
            if(await StudentRepository.Exists(studentId))
            {
                // Save in local resource
                var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
                var fileImagePath = await imageUploadRepository.Upload(profileImage, fileName);

                // update in database
                if(await StudentRepository.UpdateProfileImageURL(studentId, fileImagePath))
                {
                    return Ok(fileImagePath);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image.");
            }
            return NotFound();
        }
    }
}
