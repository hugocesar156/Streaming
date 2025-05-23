﻿namespace Streaming.Domain.Entities
{
    public class Cast
    {
        public Cast(string name, string chacarter, int? idFilm, int? idSeries, short? season)
        {
            Name = name;    
            Character = chacarter;
            IdFilm = idFilm;
            IdSeries = idSeries;
            Season = season;
        }

        public Cast(int idCast, string name, string chacarter, int? idFilm, int? idSeries, short? season)
        {
            IdCast = idCast;
            Name = name;
            Character = chacarter;
            Season = season;
        }

        public int IdCast { get; private set; }
        public string Name { get; private set; }
        public string Character { get; private set; }
        public int? IdFilm { get; set; }
        public int? IdSeries { get; set; }
        public short? Season { get; private set; }
    }
}
