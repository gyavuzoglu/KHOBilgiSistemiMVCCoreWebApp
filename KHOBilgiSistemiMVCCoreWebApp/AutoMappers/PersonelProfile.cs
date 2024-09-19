using AutoMapper;
using EntityLayer.Concrete;
using KHOBilgiSistemiMVCCoreWebApp.Areas.YonetimArea.Models.ViewModels.PersonelVM;

namespace KHOBilgiSistemiMVCCoreWebApp.AutoMappers
{
    public class PersonelProfile : Profile
    {
        public PersonelProfile() 
        { 
            CreateMap<PersonelTbl,PersonelCreateVM> ();
            CreateMap<PersonelCreateVM,PersonelTbl> ();
        }
    }
}
