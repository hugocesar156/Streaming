namespace Streaming.Application.Models.Responses.Film
{
    public partial class FilmCastResponse
    {
        public FilmCastResponse(int idCast, string name, string character)
        {
            IdCast = idCast;
            Name = name;
            Character = character;
        }

        public int IdCast { get; private set; }
        public string Name { get; private set; }
        public string Character { get; private set; } 
    }
}
