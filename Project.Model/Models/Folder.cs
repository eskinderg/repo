using System.Collections.Generic;
using Newtonsoft.Json;

namespace Project.Model.Models
{
    public class Folder : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Folder Parent { get; set; }
        public virtual ICollection<Folder> Children { get; set; }
    }
}
