using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Interface;

namespace WebApi.Controllers
{
    [Route("api/commentary")]
    [ApiController]
    public class CommentaryController : ControllerBase
    {
        private readonly ICommentary _ICommentary;

        public CommentaryController(ICommentary iCommentary)
        {
            _ICommentary = iCommentary;
        }
       

        [HttpGet]
        public ActionResult<List<CommentaryDto>> GetCommentary(int wordId, int userId)
        {
            List<CommentaryDto> Commentaries = _ICommentary.GetCommentary(wordId, userId);
            return Ok(Commentaries);
        }

        [Authorize]
        [HttpPost]
        public void CreateCommentary(CommentaryDto commentaryDto)
        {
            if(commentaryDto == null)
            {
                return;
            }

            _ICommentary.Created(commentaryDto);
        }

        [Authorize]
        [HttpPatch]
        public void UpdateCommentary(CommentaryDto commentaryDto)
        {
            if (commentaryDto == null)
            {
                return;
            }

            _ICommentary.Update(commentaryDto);
        }

        [Authorize]
        [HttpDelete]
        public void DeleteCommentary(CommentaryDto commentaryDto)
        {
            if (commentaryDto == null)
            {
                return;
            }

            _ICommentary.Delete(commentaryDto);
        }



    }
}
