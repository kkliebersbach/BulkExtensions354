namespace BulkExtensionsIssue354.Models
{
    public class EntityC
    {
        public EntityC() {}
        
        public EntityC(int value)
        {
            Value = value;
        }
        
        public int EntityAId { get; set; }
        public int EntityBId { get; set; }
        public int Id { get; set; }
        public int Value { get; set; }
        
        public EntityA EntityA { get; set; }
        public EntityB EntityB { get; set; }
        public IdC IdC { get; set; }
    }
}