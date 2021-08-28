using System;
using System.Collections.Generic;
using System.Text;

namespace Quotes.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
