using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionApiFilter.Data.Entities;
using TransactionApiFilter.Data.Repositories.Base;

namespace TransactionApiFilter.Data.Repositories
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        IEnumerable<Transaction> GetByParameter(TransactionFilterParameters filter);
    }
}
