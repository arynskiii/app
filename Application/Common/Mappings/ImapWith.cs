using AutoMapper;

namespace Roadmap.Application.Common.Mappings;

public interface ImapWith<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}