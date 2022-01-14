using AutoMapper;

namespace MovieListApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieEntity, MovieModel>();
            CreateMap<MovieModel, MovieEntity>()
                .ForMember(m => m.MetaScore, opt =>
                {
                    int value;
                    opt.MapFrom(o => int.TryParse(o.MetaScore, out value) ? value : -1);
                });
            CreateMap<ListEntity, ListModel>();
            CreateMap<ListModel, ListEntity>()
                .ForMember(l => l.Movies, opt => opt.Ignore());
            CreateMap<ListEntryEntity, ListEntryModel>();
            CreateMap<ListEntryModel, ListEntryEntity>();
        }
    }
}