namespace WebApi.DTO
{
    public class WordsFrDto
    {
        public WordsFrDto(string french, string frExplication, string frDefinition, string blueWord)
        {
            French = french;
            FrExplication = frExplication;
            FrDefinition = frDefinition;
            BlueWord = blueWord;
        }

        public string French { get; set; }
        public string FrExplication { get; set; }
        public string FrDefinition { get; set; }
        public string BlueWord { get; set; }
    }
}
