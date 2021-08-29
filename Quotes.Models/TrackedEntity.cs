using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes.Models
{
    public class TrackedEntity : BaseEntity
    {
        public DateTime CreateOn { get; set; }

        public bool Deleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public bool Modified { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
