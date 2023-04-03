using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Customers
{
    public class CustomerResult<T>
    {
        public T Result { get; set; }
        public IList<T> Messages { get; set; }

    }
}
