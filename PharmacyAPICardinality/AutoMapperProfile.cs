using AutoMapper;

namespace PharmacyAPICardinality
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserResponseDTO>();
            
            CreateMap<Pharmacy, PharmacyResponseDTO>();
            CreateMap<Address, AddressRequestDTO>();
            CreateMap<Pharmacy, PharmacyResponseDTO>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(ps => ps.PharmacyAddress));

            CreateMap<PharmacyRequestDTO, Pharmacy>();
            CreateMap<AddressRequestDTO, Address>();
            CreateMap<PharmacyRequestDTO, Pharmacy>()
                .ForMember(dest => dest.PharmacyAddress, opt => opt.MapFrom(ps => ps.Address));


        }
    }
}
