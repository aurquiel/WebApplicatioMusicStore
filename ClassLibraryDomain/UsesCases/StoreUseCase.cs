using ClassLibraryDomain.Exceptions;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;

namespace ClassLibraryDomain.UsesCases
{
    public class StoreUseCase : IStoreDriving
    {
        private readonly IStorePersistencePort _storePersistencePort;
        private readonly IAudioListPersistencePort _audioListPersistencePort;

        public StoreUseCase(IStorePersistencePort storePersistencePort, IAudioListPersistencePort audioListPersistencePort)
        {
            _storePersistencePort = storePersistencePort;
            _audioListPersistencePort = audioListPersistencePort;
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await _storePersistencePort.GetAllAsync();
        }

        public async Task InsertAsync(Store store)
        {
            Store storeWithCode = await _storePersistencePort.GetAsync(store.Code);

            if (storeWithCode is not null)
            {
                throw new StoreDuplicateCodeException(store.Code);
            }

            await _storePersistencePort.InsertAsync(store);
        }

        public async Task UpdateAsync(Store store)
        {
            Store storeBeforeUpdate = await _storePersistencePort.GetAsync(store.Id);

            if (storeBeforeUpdate is null)
            {
                throw new StoreNotFoundException(storeBeforeUpdate.Id);
            }

            Store storeWithCode = await _storePersistencePort.GetAsync(store.Code);

            if (storeWithCode is not null && storeWithCode.Id != storeBeforeUpdate.Id)
            {
                throw new StoreDuplicateCodeException(store.Code);
            }

            await _storePersistencePort.UpdateAsync(store);
        }

        public async Task DeleteAsync(int storeId)
        {
            Store store = await _storePersistencePort.GetAsync(storeId);

            if(store is null)
            {
                throw new StoreNotFoundException(storeId);
            }

            await _audioListPersistencePort.DeleteAudioListStoreAsync(store.Id);
            await _storePersistencePort.DeleteAsync(store);
        }
    }
}
