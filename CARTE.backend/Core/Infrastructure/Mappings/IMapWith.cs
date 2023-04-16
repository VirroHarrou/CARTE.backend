using AutoMapper;

namespace CARTE.backend.Core.Infrastructure.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
