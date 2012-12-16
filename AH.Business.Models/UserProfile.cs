using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AH.Business.Models
{
    public class UserProfile : Entity
    {
        public virtual User User { get; set; }

        public virtual string profileKey { get; set; }

        public virtual string profileValue { get; set; }
    }
}
