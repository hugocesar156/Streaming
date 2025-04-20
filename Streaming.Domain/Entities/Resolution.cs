namespace Streaming.Domain.Entities
{
    public class Resolution
    {
        public Resolution(int idResolution)
        {
            IdResolution = idResolution;
        }

        public Resolution(int idResolution, string description, string pixels)
        {
            IdResolution = idResolution;
            Description = description;
            Pixels = pixels;
        }

        public int IdResolution { get; private set; }
        public string Description { get; private set; }
        public string Pixels { get; private set; }
    }
}
