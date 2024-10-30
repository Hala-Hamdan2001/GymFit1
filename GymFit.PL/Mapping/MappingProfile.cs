using AutoMapper;
using GymFit.DAL.Data.Models;
using GymFit.PL.Areas.Dashboard.ViewModels;

namespace GymFit.PL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceFormVM, Service>().ReverseMap();
            CreateMap<Service, ServicesVm>();
            CreateMap<Service, ServiceDetailsVM>();
        }
    }
}
