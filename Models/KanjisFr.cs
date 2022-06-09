using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class KanjisFr
    {
        public int Id { get; set; }
        public string OnFr { get; set; } = null!;
        public string KunFr { get; set; } = null!;
        public string SKunFr { get; set; } = null!;
        public string SOnFr { get; set; } = null!;
        public string SKunFr2 { get; set; } = null!;
        public string SOnFr2 { get; set; } = null!;
        public string SKunFr3 { get; set; } = null!;

        public virtual Kanji IdNavigation { get; set; } = null!;
    }
}
