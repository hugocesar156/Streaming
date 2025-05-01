namespace Streaming.Application.Models.Responses.Profile
{
    public class ProfileResponse
    {
        public ProfileResponse(int idProfile, string name, string avatar, bool kidsContent)
        {
            IdProfile = idProfile;
            Name = name;
            Avatar = avatar;
            KidsContent = kidsContent;
        }

        public int IdProfile { get; private set; }
        public string Name { get; private set; }
        public string Avatar { get; private set; }
        public bool KidsContent { get; private set; }
    }
}
