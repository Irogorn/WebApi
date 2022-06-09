using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class User
    {
        public User()
        {
            Commentaries = new HashSet<Commentary>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EMail { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Commentary> Commentaries { get; set; }
    }
}
