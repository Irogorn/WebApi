namespace WebApi.DTO
{
    public class KanjisDto
    {
        public KanjisDto(int jlpt, string kanji1, int nbStrikes, string on, string onKa, string onRo, string kun, string kunRo, string sKun, string sKunRo, 
                        string sOn, string sOnKa, string sOnRo, string sKun2, string sKunRo2, string sOn2, string sOnKa2, string sOnRo2, string sKun3, string sKunRo3)
        {
            Jlpt = jlpt;
            Kanji1 = kanji1;
            NbStrikes = nbStrikes;
            On = on;
            OnKa = onKa;
            OnRo = onRo;
            Kun = kun;
            KunRo = kunRo;
            SKun = sKun;
            SKunRo = sKunRo;
            SOn = sOn;
            SOnKa = sOnKa;
            SOnRo = sOnRo;
            SKun2 = sKun2;
            SKunRo2 = sKunRo2;
            SOn2 = sOn2;
            SOnKa2 = sOnKa2;
            SOnRo2 = sOnRo2;
            SKun3 = sKun3;
            SKunRo3 = sKunRo3;
        }

        public int Jlpt { get; set; }
        public string Kanji1 { get; set; }
        public int NbStrikes { get; set; }
        public string On { get; set; }
        public string OnKa { get; set; }
        public string OnRo { get; set; }
        public string Kun { get; set; }
        public string KunRo { get; set; }
        public string SKun { get; set; }
        public string SKunRo { get; set; }
        public string SOn { get; set; }
        public string SOnKa { get; set; }
        public string SOnRo { get; set; }
        public string SKun2 { get; set; }
        public string SKunRo2 { get; set; }
        public string SOn2 { get; set; }
        public string SOnKa2 { get; set; }
        public string SOnRo2 { get; set; }
        public string SKun3 { get; set; }
        public string SKunRo3 { get; set; }
    }
}
