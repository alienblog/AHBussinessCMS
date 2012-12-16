using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AH.Business.Models
{
    public class Content : Entity
    {
        public Content()
        {
            ViewName = "Page";
            Contents = new List<Content>();
            Properties = new List<ContentProperty>();
        }

        public virtual User User { get; set; }

        public virtual string Title { get; set; }

        public virtual string ViewName { get; set; }

        public virtual Content Parent { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual ICollection<Content> Contents { get; set; }

        public virtual ICollection<ContentProperty> Properties { get; set; }
    }
}
