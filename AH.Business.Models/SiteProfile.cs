using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AH.Business.Models
{
    public class SiteProfile : Entity
    {
        public virtual string ProfileKey { get; set; }

        public virtual string ProfileValue { get; set; }
    }
}
