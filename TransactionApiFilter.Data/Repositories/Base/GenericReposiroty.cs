using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransactionApiFilter.Data.DBContext;
using TransactionFilter.Base.ModelBase;

namespace TransactionApiFilter.Data.Repositories.Base
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : ModelBase
    {
        private readonly TransactionFilterApiDbContext _context;

        public GenericRepository(TransactionFilterApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression)
        {
            return _context.Set<Entity>().Where(expression).ToList();
        }
    }
}