using AutoMapper;

namespace MovieListApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieEntity, MovieModel>();
            CreateMap<MovieModel, MovieEntity>();
            CreateMap<ListEntity, ListModel>();
            CreateMap<ListModel, ListEntity>();
            CreateMap<ListEntryEntity, ListEntryModel>();
            CreateMap<ListEntryModel, ListEntryEntity>();
        }
    }
}