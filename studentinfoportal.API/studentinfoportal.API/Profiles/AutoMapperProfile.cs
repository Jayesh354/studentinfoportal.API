using AutoMapper;
using DataModels = studentinfoportal.API.DataModels;
using studentinfoportal.API.DomainModels;
using studentinfoportal.API.Profiles.AfterMap;

namespace studentinfoportal.API.Profiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataModels.Student, Student>().ReverseMap();
            CreateMap<DataModels.Address, Address>().ReverseMap();
            CreateMap<DataModels.Gender, Gender>().ReverseMap();
            CreateMap<UpdateStudnetRequest, DataModels.Student>
                ().AfterMap<UpdateStudentRequestAfterMap>();
        }

    }
}
