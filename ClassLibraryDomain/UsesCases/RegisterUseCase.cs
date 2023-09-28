using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;

namespace ClassLibraryDomain.UsesCases
{
    public class RegisterUseCase : IRegisterDriving
    {
        private readonly IRegisterPersistencePort _registerPersistencePort;

        public RegisterUseCase(IRegisterPersistencePort registerPersistencePort)
        {
            _registerPersistencePort = registerPersistencePort;
        }

        public async Task<List<Register>> GetByIdAndRangeDateAsync(int storeId, DateTime dateInit, DateTime dateEnd)
        {
            return await _registerPersistencePort.GetByIdAndRangeDateAsync(storeId, dateInit, dateEnd);
        }

        public async Task<List<Register>> GetByIdAndMonthAsync(int storeId, DateTime date)
        {
            return await _registerPersistencePort.GetByIdAndMonthAsync(storeId, date);
        }

        public async Task InsertAsync(List<Register> registers)
        {
            await _registerPersistencePort.InsertAsync(registers);
        }

        public async Task DeleteAllByStoreIdAsync(int storeId)
        {
            await _registerPersistencePort.DeleteAllByStoreIdAsync(storeId);
        }

    }
}
