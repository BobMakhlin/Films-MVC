using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Films.BLL.Services.Common
{
    public interface IQueryService<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Func<T, bool> predicate);
    }
}
