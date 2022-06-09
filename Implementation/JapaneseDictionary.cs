using WebApi.DAL;
using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Implementation
{
    public class JapaneseDictionary : IJapaneseDictionary
    {
        private readonly JapaneseDictionaryContext _entites;

        public JapaneseDictionary(JapaneseDictionaryContext japaneseDictionaryContext)
        {
            _entites = japaneseDictionaryContext;
        }
      
        public List<DefinitionDto> GetDefinition(string searchedWord)
        {
            try
            {
                List<DefinitionDto> definitionDtos = new List<DefinitionDto> { };
                List<KanjisDto> kanjisDtos = new List<KanjisDto> { };
                List<CommentaryDto> commentaryDtos = new List<CommentaryDto>();
                var formAdj = new FormAdj();
                var formVerb = new FormVerb();



                if (!String.IsNullOrEmpty(searchedWord))
                {
                    if ((0x3040 <= searchedWord[0]) && (searchedWord[0] <= 0x309F))
                    {
                        var foundWord = _entites.Words.Where(w => w.JpHiragana.Contains(searchedWord)).ToList();
                  
                        foreach(Word word in foundWord)
                        {
                            _entites.Entry(word).Reference(w => w.WordsFr).Load();

                            var arrayKanji = word.JpKanji.ToCharArray();

                           foreach(var k in arrayKanji)
                            {
                                var kanji = _entites.Kanjis.SingleOrDefault(k => k.Kanji1.Equals(k.ToString()));
                                if(kanji != null)
                                {
                                    kanjisDtos.Add(GetKanjiToKankisDto(_entites, kanji));
                                }

                            }

                           if(word.Type == "" && word.Verb == 0)
                            {
                               formAdj = _entites.FormAdjs.SingleOrDefault(f => f.Type.Equals(word.Adj));
                               formVerb = null;
                            }
                           else if(word.Type != "" && word.Verb == 5)
                            {
                                formVerb = _entites.FormVerbs.SingleOrDefault(f => f.Dan.Equals(word.Verb) && f.Stem.Equals(word.Stem));
                                formAdj = null;
                            }
                           else if (word.Type != "" && word.Verb == 1)
                            {
                                formVerb = _entites.FormVerbs.SingleOrDefault(f => f.Dan.Equals(word.Verb) && f.Stem.Equals(word.Stem));
                                formAdj = null;
                            }

                            _entites.Entry(word).Collection(w => w.Commentaries).Load();

                            definitionDtos.Add(GetDefinitionDto(word, kanjisDtos, formAdj, formVerb));
                        }
                        
                        return definitionDtos;
                    }
                    else if ((searchedWord[0] >= 0x30a0) && (searchedWord[0] <= 0x30ff))
                    {
                        var foundWord = _entites.Words.Where(w => w.JpKatakana.Contains(searchedWord)).ToList();
                        
                        foreach (Word word in foundWord)
                        {
                            _entites.Entry(word).Reference(w => w.WordsFr).Load();

                            var arrayKanji = word.JpKanji.ToCharArray();

                            foreach (var k in arrayKanji)
                            {
                                var kanji = _entites.Kanjis.SingleOrDefault(k => k.Kanji1.Equals(k.ToString()));
                                if (kanji != null)
                                {
                                    kanjisDtos.Add(GetKanjiToKankisDto(_entites, kanji));
                                }
                            }

                            if (word.Type == "" && word.Verb == 0)
                            {
                                formAdj = _entites.FormAdjs.SingleOrDefault(f => f.Type.Equals(word.Adj));
                                formVerb = null;
                            }
                            else if (word.Type != "" && word.Verb == 5)
                            {
                                formVerb = _entites.FormVerbs.SingleOrDefault(f => f.Dan.Equals(word.Verb) && f.Stem.Equals(word.Stem));
                                formAdj = null;
                            }
                            else if (word.Type != "" && word.Verb == 1)
                            {
                                formVerb = _entites.FormVerbs.SingleOrDefault(f => f.Dan.Equals(word.Verb) && f.Stem.Equals(word.Stem));
                                formAdj = null;
                            }

                            _entites.Entry(word).Collection(w => w.Commentaries).Load();

                            definitionDtos.Add(GetDefinitionDto(word, kanjisDtos, formAdj,  formVerb));
                        }

                        return definitionDtos;
                    }
                    else if ((searchedWord[0] >= 0x4e00) && (searchedWord[0] <= 0x9faf))
                    {
                        var foundWord = _entites.Words.Where(w => w.JpKanji.Contains(searchedWord)).ToList();
                        
                        foreach (Word word in foundWord)
                        {
                            _entites.Entry(word).Reference(w => w.WordsFr).Load();

                            var arrayKanji = word.JpKanji.ToCharArray();

                            foreach (var k in arrayKanji)
                            {
                                var kanji = _entites.Kanjis.SingleOrDefault(r => r.Kanji1.Equals(k.ToString()));
                                if (kanji != null)
                                {
                                    kanjisDtos.Add(GetKanjiToKankisDto(_entites, kanji));
                                }
                            }

                            if (word.Type == "" && word.Verb == 0)
                            {
                                formAdj = _entites.FormAdjs.SingleOrDefault(f => f.Type.Equals(word.Adj));
                                formVerb = null;
                            }
                            else if (word.Type != "" && word.Verb == 5)
                            {
                                formVerb = _entites.FormVerbs.SingleOrDefault(f => f.Dan.Equals(word.Verb) && f.Stem.Equals(word.Stem));
                                formAdj = null;
                            }
                            else if (word.Type != "" && word.Verb == 1)
                            {
                                formVerb = _entites.FormVerbs.SingleOrDefault(f => f.Dan.Equals(word.Verb) && f.Stem.Equals(word.Stem));
                                formAdj = null;
                            }

                            _entites.Entry(word).Collection(w => w.Commentaries).Load();

                            definitionDtos.Add(GetDefinitionDto(word, kanjisDtos, formAdj, formVerb));
                        }

                        return definitionDtos;
                    }
                    else
                    {
                        var foundWord = _entites.Words.Where(w => w.WordsFr.French.Contains(searchedWord)).ToList();
                        if (foundWord.Count == 0)
                        {
                            foundWord = _entites.Words.Where(w => w.JpRomanji.Contains(searchedWord)).ToList();
                        }

                        foreach (Word word in foundWord)
                        {
                            _entites.Entry(word).Reference(w => w.WordsFr).Load();

                            var arrayKanji = word.JpKanji.ToCharArray();

                            foreach (var k in arrayKanji)
                            {
                                var kanji = _entites.Kanjis.SingleOrDefault(r => r.Kanji1.Equals(k.ToString()));
                                if (kanji != null)
                                {
                                    kanjisDtos.Add(GetKanjiToKankisDto(_entites, kanji));
                                }  
                            }

                            if (word.Type == "" && word.Verb == 0)
                            {
                                formAdj = _entites.FormAdjs.SingleOrDefault(f => f.Type.Equals(word.Adj));
                                formVerb = null;
                            }
                            else if (word.Type != "" && word.Verb == 5)
                            {
                                formVerb = _entites.FormVerbs.SingleOrDefault(f => f.Dan == word.Verb && (f.Stem.Equals(word.Stem)));
                                formAdj = null;
                            }
                            else if (word.Type != "" && word.Verb == 1)
                            {
                                formVerb = _entites.FormVerbs.SingleOrDefault(f => f.Dan.Equals(word.Verb) && f.Stem.Equals(word.Stem));
                                formAdj = null;
                            }

                            _entites.Entry(word).Collection(w => w.Commentaries).Load();

                            definitionDtos.Add(GetDefinitionDto(word, kanjisDtos, formAdj, formVerb));
                        }

                        return definitionDtos;
                    }
                }

                return definitionDtos;
            }
            catch
            {
                throw;
            }
        }

        private KanjisDto GetKanjiToKankisDto(JapaneseDictionaryContext entites, Kanji kanji)
        {
            entites.Entry(kanji).Reference(b => b.KanjisFr).Load();
            KanjisDto kanjiDto = new KanjisDto(kanji.Jlpt, kanji.Kanji1, kanji.NbStrikes, kanji.On, kanji.OnKa, kanji.OnRo, kanji.Kun, kanji.KunRo,
            kanji.SKun, kanji.SKunRo, kanji.SOn, kanji.SOnKa, kanji.SOnRo, kanji.SKun2, kanji.SKunRo2, kanji.SOn2,
            kanji.SOnKa2, kanji.SOnRo2, kanji.SKun3, kanji.SKunRo3);
            return kanjiDto;
        }

        private DefinitionDto GetDefinitionDto(Word word, List<KanjisDto> kanjisDto, FormAdj? formAdj, FormVerb? formVerb)
        {
            DefinitionDto definitionDto = new DefinitionDto();

            WordDto wordDto = new WordDto(word.JpRomanji, word.JpHiragana, word.JpKatakana, word.JpKanji, word.NbRo, word.NbHi, word.Type, word.Verb, word.Stem,
                                            word.Adj, word.Filters, word.JpDefinition, word.JpDefinitionRo, word.Tense, word.Commentaries.ToList<Commentary>());
            WordsFrDto wordsFrDto = new WordsFrDto(word.WordsFr.French, word.WordsFr.FrExplication, word.WordsFr.FrDefinition, word.WordsFr.BlueWord);
            definitionDto.wordDto = wordDto;
            definitionDto.wordsFrDto = wordsFrDto;
            definitionDto.kanjiDto = kanjisDto;
            definitionDto.formVerb = formVerb;
            definitionDto.formAdj = formAdj;

            return definitionDto;
        }
    }
}
