using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IRegisterDriving
    {
        Task<List<Register>> GetByIdAndRangeDateAsync(int storeId, DateTime dateInit, DateTime dateEnd);
        Task<List<Register>> GetByIdAndMonthAsync(int storeId, DateTime date);
        Task InsertAsync(List<Register> registers);
        Task DeleteAllByStoreIdAsync(int storeId);
    }
}
