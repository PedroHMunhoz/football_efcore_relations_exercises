using System.Collections.Generic;

namespace NETCoreEFCoreRelationships.Model
{
    public class Federation
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Championship> LstChampionship { get; set; }
    }
}
