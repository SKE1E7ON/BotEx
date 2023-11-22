using BotEx_Api.Model;
using static BotEx_Api.ModelDTO.UserRequest;

namespace BotEx_Api.ModelDTO
{
    public class UserRequest
    {
        public class UsersDTO
        {
            public int Id { get; set; }
            public string Loggin { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string Name { get; set; } = null!;
            public string AdresDefalt { get; set; } = null!;
            public string CardDefalt { get; set; } = null!;
            public string Phone { get; set; } = null!;
            public int IdRole { get; set; }

        }

        public static User UserConverter(UsersDTO usersDTO)
        {
            User userdto = new User();

            userdto.Loggin = usersDTO.Loggin;
            userdto.Password = usersDTO.Password;
            userdto.Name = usersDTO.Name;
            userdto.UsersId = usersDTO.Id;
            userdto.Phone = usersDTO.Phone;
            userdto.CardDefalt = usersDTO.CardDefalt;
            userdto.AdresDefalt = usersDTO.AdresDefalt;
            userdto.IdRole = usersDTO.IdRole;
            return userdto;

        }

        public static UsersDTO UserConverter(User userdto)
        {
            UsersDTO usersdto = new UsersDTO();
            usersdto.Loggin = userdto.Loggin;
            usersdto.Password = userdto.Password;
            usersdto.Name = userdto.Name;
            usersdto.Id = userdto.UsersId;
            usersdto.Phone = userdto.Phone;
            usersdto.CardDefalt = userdto.CardDefalt;
            usersdto.AdresDefalt = userdto.AdresDefalt;
            usersdto.IdRole = userdto.IdRole;
            return usersdto;
        }
    }
}
