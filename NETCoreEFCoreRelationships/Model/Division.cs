using System.Collections.Generic;

namespace NETCoreEFCoreRelationships.Model
{
    public class Division
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Championship Championship { get; set; }
        public int ChampionshipID { get; set; }


        public virtual List<Team> LstTeam { get; set; }
    }
}
