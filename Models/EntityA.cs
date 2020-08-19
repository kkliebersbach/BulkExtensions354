using System.Collections.ObjectModel;

namespace BulkExtensionsIssue354.Models
{
    public class EntityA
    {
        public EntityA() {}
        
        public EntityA(string name)
        {
            Name = name;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Collection<EntityB> EntityBs { get; set; }
    }
}