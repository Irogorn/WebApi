using WebApi.DTO;

namespace WebApi.Interface
{
    public interface ICommentary
    {
        public List<CommentaryDto> GetCommentary(int? wordId,  int? userId);
        public void Created(CommentaryDto commentaryDto);
        public void Update(CommentaryDto commentaryDto);
        public void Delete(CommentaryDto commentaryDto);
    }
}
