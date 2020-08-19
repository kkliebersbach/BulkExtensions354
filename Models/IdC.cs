using System.Collections.ObjectModel;

namespace BulkExtensionsIssue354.Models
{
    public class IdC
    {
        public IdC() {}
        
        public IdC(string name)
        {
            Name = name;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Collection<EntityC> EntityCs { get; set; }
    }
}