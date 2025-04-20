namespace Streaming.Domain.Entities
{
    public class Cast
    {
        public Cast(string name, string chacarter)
        {
            Name = name;    
            Character = chacarter;
        }

        public Cast(int idCast, string name, string chacarter)
        {
            IdCast = idCast;
            Name = name;
            Character = chacarter;
        }

        public int IdCast { get; private set; }
        public string Name { get; private set; }
        public string Character { get; private set; }
    }
}
