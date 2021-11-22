using ListListApi.Services.Interfaces;

namespace MovieListApi.Services
{
    public class ListService : IListService
    {
        public async Task<ListModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ListModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ListModel> Insert(ListModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ListModel> Update(ListModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}