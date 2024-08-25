using AutoMapper;
using DatabaseFirst.Models.Binding;
using DatabaseFirst.Models.Dbo;
using DatabaseFirst.Models.ViewModel;

namespace DatabaseFirst.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonBinding, Person>();
            CreateMap<PersonUpdateBinding, Person>();
            CreateMap<PersonViewModel, PersonUpdateBinding>();

            CreateMap<Address, AddressViewModel>();
            CreateMap<AddressBinding, Address>();
            CreateMap<AddressUpdateBinding, Address>();
            CreateMap<AddressViewModel, AddressUpdateBinding>();
        }
    }
}
