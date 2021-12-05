using AutoMapper;
using ListListApi.Services.Interfaces;

namespace MovieListApi.Services
{
    public class ListEntryService : IListEntryService
    {
        private readonly IListEntryRepository _listEntryRepository;
        private readonly IListService _listService;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public ListEntryService(IListEntryRepository listEntryRepository, IMapper mapper, IMovieService movieService, IListService listService)
        {
            _listEntryRepository = listEntryRepository;
            _mapper = mapper;
            _movieService = movieService;
            _listService = listService;
        }

        public async Task<ListEntryModel> Get(Guid id)
        {
            var entity = await _listEntryRepository.Get(id);
            return _mapper.Map<ListEntryModel>(entity);
        }

        public async Task<IList<ListEntryModel>> GetAll()
        {
            var listEntryEntities = await _listEntryRepository.GetAll();
            return _mapper.Map<List<ListEntryModel>>(listEntryEntities);
        }

        public async Task<ListEntryModel> Insert(ListEntryModel model)
        {
            var movie = _movieService.Get(model.MovieId);
            var list = _listService.Get(model.ListId);

            if (movie == null || list == null)
            {
                return null;
            }

            var entity = _mapper.Map<ListEntryEntity>(model);
            entity.ListEntryId = Guid.NewGuid();
            var result = await _listEntryRepository.Insert(entity);
            return result ? _mapper.Map<ListEntryModel>(entity) : null;
        }

        public async Task<ListEntryModel> Update(Guid id, ListEntryModel model)
        {
            var currentModel = await Get(id);
            if (currentModel == null)
            {
                return null;
            }

            model.ListId = id;
            var newEntity = _mapper.Map<ListEntryEntity>(model);
            return await _listEntryRepository.Update(newEntity) ? _mapper.Map<ListEntryModel>(newEntity) : null;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _listEntryRepository.Get(id);
            return await _listEntryRepository.Delete(entity);
        }
    }
}