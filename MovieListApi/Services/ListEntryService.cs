using ListListApi.Services.Interfaces;

namespace MovieListApi.Services
{
    public class ListEntryService : IListEntryService
    {
        public async Task<ListEntryModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ListEntryModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ListEntryModel> Insert(ListEntryModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ListEntryModel> Update(ListEntryModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}