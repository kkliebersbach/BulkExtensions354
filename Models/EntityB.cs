using System.Collections.ObjectModel;

namespace BulkExtensionsIssue354.Models
{
    public class EntityB
    {
        public EntityB() {}
        
        public EntityB(string type)
        {
            Type = type;
        }
        
        public int EntityAId { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        
        public EntityA EntityA { get; set; }
        public Collection<EntityC> EntityCs { get; set; }
    }
}