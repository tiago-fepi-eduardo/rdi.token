using System;
using System.Collections.Generic;
using System.Text;

namespace Token.Domain.Entity
{
    public abstract class BaseEntity
    {
        public abstract DateTime Date { get; set; }
    }
}
