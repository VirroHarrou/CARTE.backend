using AutoMapper;
using Domain.Models;
using Infrastructure.Mappings;

namespace Infrastructure.Users.Queries.GetUserDetail
{
    public class UserVm : IMapWith<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<BusinessCard> Cards { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserVm>()
                .ForMember(x => x.Name,
                opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Surname,
                opt => opt.MapFrom(x => x.Surname))
                .ForMember(x => x.Email,
                opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Password,
                opt => opt.MapFrom(x => x.Password))
                .ForMember(x => x.Cards,
                opt => opt.MapFrom(x => x.Cards))
                .ForMember(x => x.Longitude,
                opt => opt.MapFrom(x => x.Longitude))
                .ForMember(x => x.Latitude,
                opt => opt.MapFrom(x => x.Latitude));
        }
    }
}
