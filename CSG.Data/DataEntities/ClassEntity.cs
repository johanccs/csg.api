namespace CSG.Data.DataEntities
{
    public class ClassEntity:BaseEntity
    {
        public string ClassName { get; set; }
        public string Description { get; set; }
        public ClassEntity(string id) : base(id)
        { }
    }
}
