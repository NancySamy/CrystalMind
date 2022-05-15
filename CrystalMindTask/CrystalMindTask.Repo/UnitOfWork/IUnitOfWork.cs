using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Repo
{
    public interface IUnitOfWork:IDisposable
    {
        IAddressRepository Address
        {
            get;
        }
        ICustomerRepository Customer
        {
            get;
        }
        int Save();
    }

}
