using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Commentary
    {
        public int CommentaryId { get; set; }
        public int WordId { get; set; }
        public int UserId { get; set; }
        public string Commentary1 { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual Word Word { get; set; } = null!;
    }
}
