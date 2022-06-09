using WebApi.Interface;
using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Implementation
{
    public class ImplUser : IUser
    {
        private readonly JapaneseDictionaryContext _entites;

        public ImplUser(JapaneseDictionaryContext japaneseDictionaryContext)
        {
            _entites = japaneseDictionaryContext;
        }

        public void Created(UserDto userDto)
        {
            try
            {
                if (userDto == null)
                {
                    return;
                }

                var user = new User();
                user.UserId = userDto.UserId;
                user.UserName = userDto.UserName;
                user.LastName = userDto.LastName;
                user.FirstName = userDto.FirstName;
                user.EMail = userDto.Email;
                user.PassWord = userDto.PassWord;
                user.CreatedDate = DateTime.Now;

                _entites.Users.Add(user);

                _entites.SaveChanges();
            }
            catch
            {
                throw;
            }
            
        }

        public void Delete(UserDto userdto)
        {
              try
              {
                  if (userdto != null)
                  {
                      User? userDB = _entites.Users.SingleOrDefault(c => c.EMail.Equals(userdto.Email));
                      if (userDB != null)
                      {
                          _entites.Users.Remove(userDB);
                          _entites.SaveChanges();
                      }
                  }
              }
              catch
              {
                  throw;
              }
        }

        public UserDto? GetUser(string email)
        {
            try
             {
                 User? user =  _entites.Users.SingleOrDefault(c => c.EMail == email);
                if(user != null)
                {
                    return new UserDto(user.UserId, user.UserName, user.FirstName, user.LastName, user.EMail, user.PassWord, user.CreatedDate);
                }
                return null;
                
             }
             catch
             {
                 throw;
             }
        }

        public void Update(UserDto userdto)
        {
               try
               {
                   if(userdto != null)
                   {
                       User? userDB = _entites.Users.SingleOrDefault(c => c.EMail.Equals(userdto.Email));
                       if(userDB != null)
                       {
                            userDB.UserName = userdto.UserName;
                            userDB.LastName = userdto.LastName;
                            userDB.FirstName = userdto.FirstName;
                            userDB.PassWord = userdto.PassWord;

                           _entites.Users.Update(userDB);
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
