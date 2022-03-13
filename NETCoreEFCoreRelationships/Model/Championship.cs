using System.Collections.Generic;

namespace NETCoreEFCoreRelationships.Model
{
    public  class Championship
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Federation Federation { get; set; }
        public int FederationID { get; set; }
        public virtual List<Division> DivisionList { get; set; }
    }
}
