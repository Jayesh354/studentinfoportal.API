using AutoMapper;
using studentinfoportal.API.DomainModels;
using DataModels = studentinfoportal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentinfoportal.API.Profiles.AfterMap
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudnetRequest, DataModels.Student>
    {
        public void Process(UpdateStudnetRequest source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Address = new DataModels.Address
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress

            };
        }
    }
}
