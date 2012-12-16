using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AH.Business.Models
{
    public class ContentProperty : Entity
    {
        public virtual Content Content { get; set; }

        public virtual string PropertyKey { get; set; }

        public virtual string PropertyValue { get; set; }
    }
}
