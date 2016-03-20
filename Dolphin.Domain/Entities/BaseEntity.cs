using Dolphin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Domain.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDateUtc { get; set; }
    }
}
