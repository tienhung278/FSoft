using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weather.Contracts;

namespace Weather.Repositories
{
    abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<T> FindByCondition(string param)
        {
            return _context.GetData<T>(param);
        }
    }
}
