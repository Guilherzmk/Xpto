using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Customers;

namespace Xpto.UI.Delegates
{
    public delegate void CustomerChangeDelegate(Customer customer);
    public delegate void CustomerMensageDelegate(String message);
}
