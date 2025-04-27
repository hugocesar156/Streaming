namespace Streaming.Domain.Entities
{
    public class Profile
    {
        public Profile(int idUser)
        {
            Name = "username";
            Avatar = "default";
            IdUser = idUser;
        }

        public Profile(string name, string avatar, int idUser)
        {
            Name = name;
            Avatar = avatar;
            IdUser = idUser;
        }

        public Profile(int idProfile, string name, string avatar, int idUser = 0)
        {
            IdProfile = idProfile;
            Name = name;
            Avatar = avatar;
            IdUser = idUser;
        }

        public int IdProfile { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int IdUser { get; set; }
    }
}
