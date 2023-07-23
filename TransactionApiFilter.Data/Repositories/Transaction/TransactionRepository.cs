using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransactionApiFilter.Data.DBContext;
using TransactionApiFilter.Data.Entities;
using TransactionApiFilter.Data.Repositories.Base;

namespace TransactionApiFilter.Data.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly TransactionFilterApiDbContext _context;

        public TransactionRepository(TransactionFilterApiDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetByParameter(TransactionFilterParameters filter)
        {
            Expression<Func<Transaction, bool>> expression = transaction =>
                (filter.AccountNumber == null || transaction.AccountNumber == filter.AccountNumber) && 
                (filter.ReferenceNumber == null || transaction.ReferenceNumber == filter.ReferenceNumber) &&
                (filter.MinAmountCredit == null || transaction.CreditAmount >= filter.MinAmountCredit) &&
                (filter.MaxAmountCredit == null || transaction.CreditAmount <= filter.MaxAmountCredit) && 
                (filter.MinAmountDebit == null || transaction.DebitAmount >= filter.MinAmountDebit) &&
                (filter.MaxAmountDebit == null || transaction.DebitAmount <= filter.MaxAmountDebit) && 
                (filter.Description == null || transaction.Description.Contains(filter.Description)) && 
                (filter.BeginDate == null || transaction.TransactionDate >= filter.BeginDate) &&
                (filter.EndDate == null || transaction.TransactionDate <= filter.EndDate); 


            return Where(expression);
        }
    }
}
