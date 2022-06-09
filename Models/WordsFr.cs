using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class WordsFr
    {
        public int Id { get; set; }
        public string French { get; set; } = null!;
        public string FrExplication { get; set; } = null!;
        public string FrDefinition { get; set; } = null!;
        public string BlueWord { get; set; } = null!;

        public virtual Word IdNavigation { get; set; } = null!;
    }
}
