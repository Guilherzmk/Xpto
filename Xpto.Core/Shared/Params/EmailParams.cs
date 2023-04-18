using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Core.Shared.Params
{
    public class EmailParams
    {
        public Guid? Id { get; set; }
        public int Code { get; set; }
        public int CustomerCode { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
    }
}
