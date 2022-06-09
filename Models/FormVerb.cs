using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class FormVerb
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
        public string ForPotentiel { get; set; } = null!;
        public string ForPotentielHi { get; set; } = null!;
        public string Potentiel { get; set; } = null!;
        public string PotentielHi { get; set; } = null!;
        public string ConjecturalFor { get; set; } = null!;
        public string ConjecturalForHi { get; set; } = null!;
        public string Conjectural { get; set; } = null!;
        public string? ConjecturalHi { get; set; }
        public string Imperative { get; set; } = null!;
        public string ImperativeHi { get; set; } = null!;
        public string Causative { get; set; } = null!;
        public string Volutive { get; set; } = null!;
        public string Conditionnel { get; set; } = null!;
        public string ConditionnelPa { get; set; } = null!;
        public string Obligation { get; set; } = null!;
        public string ForToo { get; set; } = null!;
        public string ForTooHi { get; set; } = null!;
        public string ForTooPa { get; set; } = null!;
        public string ForTooPaHi { get; set; } = null!;
        public string Stem { get; set; } = null!;
        public string StemHi { get; set; } = null!;
        public int Dan { get; set; }
        public string ForPassif { get; set; } = null!;
        public string ForPassifHi { get; set; } = null!;
        public string Passif { get; set; } = null!;
        public string PassifHi { get; set; } = null!;
    }
}
