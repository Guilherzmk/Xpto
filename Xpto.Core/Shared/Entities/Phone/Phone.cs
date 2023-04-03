using System.IO;
using System.Reflection.Emit;

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

        public override string ToString()
        {
            return $"({Ddd}) {Number}";
        }
    }
}
