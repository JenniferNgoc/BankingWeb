using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Models;

namespace Banking.DAL.Interfaces
{
    public interface ITransactionRepository : IBaseReponsitory<Models.UserTransaction>
    {
        
    }
}
