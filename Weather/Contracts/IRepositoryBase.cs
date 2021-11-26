using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Contracts
{
    interface IRepositoryBase<T>
    {
        IEnumerable<T> FindByCondition(string param);
    }
}
