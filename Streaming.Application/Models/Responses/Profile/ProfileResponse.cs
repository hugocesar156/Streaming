namespace Streaming.Application.Models.Responses.Profile
{
    public class ProfileResponse
    {
        public ProfileResponse(int idProfile, string name, string avatar)
        {
            IdProfile = idProfile;
            Name = name;
            Avatar = avatar;
        }

        public int IdProfile { get; private set; }
        public string Name { get; private set; }
        public string Avatar { get; private set; }
    }
}
