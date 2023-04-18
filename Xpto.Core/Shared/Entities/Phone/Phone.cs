using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using Xpto.Core.Shared.Params;

namespace Xpto.Core.Shared.Entities.Phone
{
    public class Phone
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public int CustomerCode { get; set; }
        public string Type { get; set; }
        public int Ddd { get; set; }
        public long Number { get; set; }
        public string Note { get; set; }

        public Phone()
        {
            Id = Guid.NewGuid();
        }

        public Phone(PhoneParams phoneParams)
        {
            this.Id = Guid.NewGuid();

            if (phoneParams.Id != null)
                this.Id = (Guid)phoneParams.Id;

            this.Type = phoneParams.Type;
            this.Ddd = phoneParams.Ddd;
            this.Number = phoneParams.Number;
            this.Note = phoneParams.Note;
        }

        public PhoneParams ToParams()
        {
            var phone = new PhoneParams()
            {
                Id = this.Id,
                Type = this.Type,
                Ddd = this.Ddd,
                Number = this.Number,
                Note = this.Note
            };

            return phone;
        }


        public override string ToString()
        {
            return $"({Ddd}) {Number}";
        }
    }
}
