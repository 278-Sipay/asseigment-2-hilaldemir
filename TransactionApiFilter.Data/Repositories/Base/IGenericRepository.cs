using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TransactionApiFilter.Data.Repositories.Base
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression);
    }
}
