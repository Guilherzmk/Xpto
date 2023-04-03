using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Results
{
    public interface IResultService
    {
        IList<string> Messages { get; set; }
        void ClearMessages();
    }
}
