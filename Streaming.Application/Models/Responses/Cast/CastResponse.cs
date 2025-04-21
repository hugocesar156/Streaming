namespace Streaming.Application.Models.Responses.Cast
{
    public partial class CastResponse
    {
        public CastResponse(int idCast, string name, string character)
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
