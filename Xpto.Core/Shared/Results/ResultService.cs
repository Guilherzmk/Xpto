using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Results
{
    public class ResultService : IResultService
    {
        public IList<string> Messages { get; set; }

        public void ClearMessages()
        {
            this.Messages = new List<string>();
        }




    }
}
