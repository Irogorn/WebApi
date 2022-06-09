using WebApi.DTO;

namespace WebApi.DAL
{
    public interface IJapaneseDictionary
    {
        public List<DefinitionDto> GetDefinition(string searchedWord);

    }
}
