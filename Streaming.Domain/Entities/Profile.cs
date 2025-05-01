namespace Streaming.Domain.Entities
{
    public class Profile
    {
        public Profile(int idUser)
        {
            Name = "username";
            Avatar = "default";
            KidsContent = false;
            IdUser = idUser;
        }

        public Profile(string name, string avatar, bool kidsContent, int idUser)
        {
            Name = name;
            Avatar = avatar;
            KidsContent = kidsContent;
            IdUser = idUser;
        }

        public Profile(int idProfile, string name, string avatar, bool kidsContent, int idUser = 0)
        {
            IdProfile = idProfile;
            Name = name;
            Avatar = avatar;
            KidsContent = kidsContent;
            IdUser = idUser;
        }

        public int IdProfile { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public bool KidsContent { get; set; }
        public int IdUser { get; set; }
    }
}
