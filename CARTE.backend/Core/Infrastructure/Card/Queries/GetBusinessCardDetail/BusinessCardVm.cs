using AutoMapper;
using Domain.Models;
using Infrastructure.Mappings;

namespace Infrastructure.Card.Queries.GetBusinessCardDetail
{
    public class BusinessCardVm : IMapWith<BusinessCard>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public List<string> Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Urls { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BusinessCard, BusinessCardVm>()
                .ForMember(x => x.Name,
                opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Surname,
                opt => opt.MapFrom(x => x.Surname))
                .ForMember(x => x.Patronymic,
                opt => opt.MapFrom(x => x.Patronymic))
                .ForMember(x => x.Description,
                opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.ImageUrls,
                opt => opt.MapFrom(x => x.ImageUrls))
                .ForMember(x => x.Urls,
                opt => opt.MapFrom(x => x.Urls));
        }
    }
}
