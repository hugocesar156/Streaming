namespace Streaming.Domain.Entities
{
    public class User
    {
        public User(string email, string password, string salt)
        {
            Email = email;
            Password = password;
            Salt = salt;
            Profiles = [];
        }

        public User(int idUser, string email, string password, string salt, DateTime signUpDate, DateTime? signInDate, List<Profile> profiles)
        {
            IdUser = idUser;
            Email = email;
            Password = password;
            Salt = salt;
            SignUpDate = signUpDate;
            Profiles = profiles;
        }

        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime SignUpDate { get; set; }
        public DateTime? SignInDate { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}
