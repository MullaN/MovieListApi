using AutoMapper;
using ListListApi.Services.Interfaces;

namespace MovieListApi.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IMapper _mapper;
        
        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _mapper = mapper;
        }
        
        public async Task<ListModel> Get(Guid id)
        {
            var entity = await _listRepository.Get(id);
            return _mapper.Map<ListModel>(entity);
        }

        public async Task<IList<ListModel>> GetAll()
        {
            var listEntities = await _listRepository.GetAll();
            return _mapper.Map<List<ListModel>>(listEntities);
        }

        public async Task<ListModel> Insert(ListModel model)
        {
            var entity = _mapper.Map<ListEntity>(model);
            entity.ListId = Guid.NewGuid();
            var result = await _listRepository.Insert(entity);
            return result ? _mapper.Map<ListModel>(entity) : null;
        }

        public async Task<ListModel> Update(Guid id, ListModel model)
        {
            var currentModel = await Get(id);
            if (currentModel == null)
            {
                return null;
            }

            model.ListId = id;
            var newEntity = _mapper.Map<ListEntity>(model);
            return await _listRepository.Update(newEntity) ? _mapper.Map<ListModel>(newEntity) : null;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _listRepository.Get(id);
            return await _listRepository.Delete(entity);
        }
    }
}