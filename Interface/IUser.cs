using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Interface
{
    public interface IUser
    {
        public UserDto? GetUser(string email);
        public void Created(UserDto userDto);
        public void Update(UserDto userdto);
        public void Delete(UserDto userdto);
    }

}
