using BotEx_Api.Model;

namespace BotEx_Api.ModelDTO
{
    public class UserGetRequest
    {
        public int UsersId { get; set; }
        public string Loggin { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string AdresDefalt { get; set; } = null!;
        public string CardDefalt { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int IdRole { get; set; }


        public static User ConvertGetToUser(UserGetRequest users)
        {
            User user = new User();
            user.UsersId = users.UsersId;
            user.Loggin = users.Loggin;
            user.Password = users.Password;
            user.Name = users.Name;
            user.AdresDefalt = users.AdresDefalt;
            user.CardDefalt = users.CardDefalt;
            user.Phone = users.Phone;
            user.IdRole = users.IdRole;
            return user;
        }

        public static UserGetRequest ConvertGetToUsers(User Users)
        {
            UserGetRequest User = new UserGetRequest();
            User.UsersId = Users.UsersId;
            User.Loggin = Users.Loggin;
            User.Password = Users.Password;
            User.Name = Users.Name;
            User.AdresDefalt = Users.AdresDefalt;
            User.CardDefalt = Users.CardDefalt;
            User.Phone = Users.Phone;
            User.IdRole = Users.IdRole;
            return User;
        }

        public static List<UserGetRequest> ConvertToGet(List<User> user)
        {
            List<UserGetRequest> users = new List<UserGetRequest>();
            foreach(User user1 in user)
            {
                users.Add(new UserGetRequest
                {
                    UsersId = user1.UsersId,
                    Loggin = user1.Loggin,
                    Password = user1.Password,
                    Name = user1.Name,
                    AdresDefalt = user1.AdresDefalt,
                    CardDefalt = user1.CardDefalt,
                    Phone = user1.Phone,
                    IdRole = user1.IdRole,

                });
            }
            return users;
        }
    }
}
