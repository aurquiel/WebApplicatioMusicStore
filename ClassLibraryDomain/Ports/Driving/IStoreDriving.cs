using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IStoreDriving
    {
        Task<List<Store>> GetAllAsync();
        Task InsertAsync(Store store);
        Task UpdateAsync(Store store);
        Task DeleteAsync(int storeId);
    }
}
