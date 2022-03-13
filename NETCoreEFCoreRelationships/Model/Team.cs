namespace NETCoreEFCoreRelationships.Model
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Division Division { get; set; }
        public int DivisionID { get; set; }
    }
}
