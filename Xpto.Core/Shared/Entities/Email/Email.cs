using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Params;

namespace Xpto.Core.Shared.Entities.Email
{
    public class Email
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public int CustomerCode { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        public Email()
        {
            Id = Guid.NewGuid();
        }

        public Email(EmailParams emailParams)
        {
            this.Id = Guid.NewGuid();

            if (emailParams.Id != null)
                this.Id = (Guid)emailParams.Id;

            this.Type = emailParams.Type;
            this.Address = emailParams.Address;
            this.Note = emailParams.Note;
        }

        public EmailParams ToParams()
        {
            var email = new EmailParams
            {
                Id = this.Id,
                Type = this.Type,
                Address = this.Address,
                Note = this.Note
            };

            return email;
        }

        public override string ToString()
        {
            return Address;
        }
    }
}
