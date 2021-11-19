using AutoMapper;
using studentinfoportal.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentinfoportal.API.Profiles.AfterMap
{
    public class AddNewStudentAfterMap : IMappingAction<AddNewStudent, DataModels.Student>
    {
        public void Process(AddNewStudent source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new DataModels.Address()
            {
                Id = Guid.NewGuid(),
                PostalAddress = source.PostalAddress,
                PhysicalAddress = source.PhysicalAddress
            };
        }
    }
}
