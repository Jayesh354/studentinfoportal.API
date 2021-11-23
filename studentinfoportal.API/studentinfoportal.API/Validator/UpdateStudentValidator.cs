using FluentValidation;
using studentinfoportal.API.DomainModels;
using studentinfoportal.API.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentinfoportal.API.Validator
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudnetRequest>
    {
        public UpdateStudentValidator(IStudentRepository studentRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = studentRepository.GetAllGendersAsync().Result.ToList()
                .FirstOrDefault(x => x.Id == id);
                if (gender != null)
                {
                    return true;
                }
                return false;

            });
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x => x.PostalAddress).NotEmpty();
        }

    }
}
