using System;

namespace Quotes.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}