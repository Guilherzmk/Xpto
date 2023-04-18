using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Core.Shared.Params;

namespace Xpto.Core.Customers
{
    public class CustomerCreateParams
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PersonType { get; set; }
        public string Identity { get; set; }
        public IList<AddressParams> Addresses { get; set; }
        public IList<PhoneParams> Phones { get; set; }
        public IList<EmailParams> Emails { get; set; }
        public string Note { get; set; }

        public CustomerCreateParams(string name)
        {
            this.Name = name;
        }
    }
}
