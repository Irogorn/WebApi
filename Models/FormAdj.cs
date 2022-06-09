using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class FormAdj
    {
        public int Id { get; set; }
        public string ForPr { get; set; } = null!;
        public string ForPrHi { get; set; } = null!;
        public string ForPa { get; set; } = null!;
        public string ForPaHi { get; set; } = null!;
        public string ForNPr { get; set; } = null!;
        public string ForNPrHi { get; set; } = null!;
        public string ForNPa { get; set; } = null!;
        public string ForNPaHi { get; set; } = null!;
        public string Pa { get; set; } = null!;
        public string PaHi { get; set; } = null!;
        public string NPr { get; set; } = null!;
        public string NPrHi { get; set; } = null!;
        public string NPa { get; set; } = null!;
        public string NPaHi { get; set; } = null!;
        public string Te { get; set; } = null!;
        public string TeHi { get; set; } = null!;
        public string NTe { get; set; } = null!;
        public string NTeHi { get; set; } = null!;
        public string Intentionnelle { get; set; } = null!;
        public string IntentionnelleHi { get; set; } = null!;
        public string Conditionnel { get; set; } = null!;
        public string ConditionnelPa { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
