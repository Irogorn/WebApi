using WebApi.DTO;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Implementation
{
    public class ImplCommentary : ICommentary
    {
        private readonly JapaneseDictionaryContext _entites;

        public ImplCommentary(JapaneseDictionaryContext japaneseDictionaryContext)
        {
            _entites = japaneseDictionaryContext;
        }

        public void Created(CommentaryDto commentaryDto)
        {
            try
            {
                if (commentaryDto != null && !String.IsNullOrEmpty(commentaryDto.Commentary1))
                {
                    Commentary commentary = new Commentary();
                    commentary.WordId = commentaryDto.WordId;
                    commentary.UserId = commentaryDto.UserId;
                    commentary.Commentary1 = commentaryDto.Commentary1;
                    _entites.Commentaries.Add(commentary);
                    _entites.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
           
        }

        public void Delete(CommentaryDto commentaryDto)
        {
            try
            {
                if (commentaryDto != null)
                {
                    Commentary? commentaryDB = _entites.Commentaries.SingleOrDefault(c => c.CommentaryId.Equals(commentaryDto.CommentaryId));
                    if (commentaryDB != null)
                    {
                        _entites.Commentaries.Remove(commentaryDB);
                        _entites.SaveChanges();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public List<CommentaryDto> GetCommentary(int? wordId, int? userId)
        {
            List<CommentaryDto> commentaryDtos = new List<CommentaryDto>();
            List<Commentary> commentaries = new List<Commentary>();
            try
            {
                if (wordId == null)
                {
                    commentaries = _entites.Commentaries.Where(c => c.UserId == userId).ToList();
                }
                else if (userId == null)
                {
                    commentaries = _entites.Commentaries.Where(c => c.WordId == wordId).ToList();
                }
                else if (userId > 0 && wordId > 0)
                {
                    commentaries = _entites.Commentaries.Where(c => c.UserId == userId && c.WordId == wordId).ToList();
                }

                foreach (Commentary commentary in commentaries)
                {
                    CommentaryDto commentaryDto = new CommentaryDto();
                    commentaryDto.CommentaryId = commentary.CommentaryId;
                    commentaryDto.WordId = commentary.WordId;
                    commentaryDto.UserId = commentary.UserId;
                    commentaryDto.Commentary1 = commentary.Commentary1;
                    commentaryDtos.Add(commentaryDto);
                }
            }
            catch
            {
                throw;
            }
            

            return commentaryDtos;
            
        }

        public void Update(CommentaryDto commentaryDto)
        {
            try
            {
                if (commentaryDto != null)
                {
                    Commentary? commentaryDB = _entites.Commentaries.SingleOrDefault(c => c.CommentaryId.Equals(commentaryDto.CommentaryId));
                    if (commentaryDB != null)
                    {
                        commentaryDB.UserId= commentaryDto.UserId;
                        commentaryDB.Commentary1 = commentaryDto.Commentary1;
                        _entites.Commentaries.Update(commentaryDB);
                        _entites.SaveChanges();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
