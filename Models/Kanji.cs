using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Kanji
    {
        public int Id { get; set; }
        public int Jlpt { get; set; }
        public string Kanji1 { get; set; } = null!;
        public int NbStrikes { get; set; }
        public string On { get; set; } = null!;
        public string OnKa { get; set; } = null!;
        public string OnRo { get; set; } = null!;
        public string Kun { get; set; } = null!;
        public string KunRo { get; set; } = null!;
        public string SKun { get; set; } = null!;
        public string SKunRo { get; set; } = null!;
        public string SOn { get; set; } = null!;
        public string SOnKa { get; set; } = null!;
        public string SOnRo { get; set; } = null!;
        public string SKun2 { get; set; } = null!;
        public string SKunRo2 { get; set; } = null!;
        public string SOn2 { get; set; } = null!;
        public string SOnKa2 { get; set; } = null!;
        public string SOnRo2 { get; set; } = null!;
        public string SKun3 { get; set; } = null!;
        public string SKunRo3 { get; set; } = null!;

        public virtual KanjisFr KanjisFr { get; set; } = null!;
    }
}
