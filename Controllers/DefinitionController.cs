using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL;
using WebApi.DTO;


namespace WebApi.Controllers
{
    [Route("api/definition")]
    [ApiController]
    public class DefinitionController : ControllerBase
    {
        private readonly IJapaneseDictionary _IJapanseDictionary;

        public DefinitionController(IJapaneseDictionary IJapaneseDictionary)
        {
            _IJapanseDictionary = IJapaneseDictionary;
        }

        [HttpGet("search/{word}")]
        public ActionResult<List<DefinitionDto>> GetFrWordToJpWord(string word)
        {
            List<DefinitionDto> definitions = _IJapanseDictionary.GetDefinition(word);
            return Ok(definitions);
        }
    }
}
