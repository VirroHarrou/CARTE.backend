using AutoMapper;
using CARTE.backend.Core.Domain.Models;
using CARTE.backend.Core.Infrastructure.Mappings;

namespace CARTE.backend.Core.Infrastructure.Card.Queries.GetListCards
{
    public class CardLookupDto : IMapWith<BusinessCard>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BusinessCard, CardLookupDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Surname,
                opt => opt.MapFrom(x => x.Surname))
                .ForMember(x => x.ImageUrl,
                opt => opt.MapFrom(x => x.ImageUrls.FirstOrDefault()));
        }
    }
}
