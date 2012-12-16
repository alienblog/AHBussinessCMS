using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AH.Business.Models
{
    public class User : Entity
    {
        public User()
        {
            CreateDate = DateTime.Now;
            Contents = new List<Content>();
            Profiles = new List<UserProfile>();
        }

        public virtual string Name { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual string Comment { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual bool IsAdministrator { get; set; }

        public virtual ICollection<Content> Contents { get; set; }

        public virtual ICollection<UserProfile> Profiles { get; set; }
    }
}
