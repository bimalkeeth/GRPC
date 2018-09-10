using AutoMapper;
using OBSalaries.SalaryService;
using WebApp.Models;


namespace WebApp.AutoMapperConfig
{
    public static  class MapperConfig
    {
        internal class MapProfile : Profile
        {
            public MapProfile()
            {
                CreateMap<SalarySlipResponse, PaySlipVM>()
                    .ForMember(m => m.Id, m => m.MapFrom(map => map.Id))
                    .ForMember(m => m.Name, m => m.MapFrom(map => map.Name))
                    .ForMember(m => m.Super, m => m.MapFrom(map => map.Super))
                    .ForMember(m => m.GrossIncome, m => m.MapFrom(map => map.GrossIncome))
                    .ForMember(m => m.IncomeTax, m => m.MapFrom(map => map.IncomeTax))
                    .ForMember(m => m.NetIncome, m => m.MapFrom(map => map.NetIncome))
                    .ForMember(m => m.PayPeriod, m => m.MapFrom(map => map.PayPeriod))
                    .IgnoreAllPropertiesWithAnInaccessibleSetter();
            }
            
        }
    }
}