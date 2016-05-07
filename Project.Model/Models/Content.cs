using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Project.Model.Models
{
    
    public class Content : BaseEntity
    {
        [Key]    
        public int Id { get; set; }
        public string Title { get; set; }
        public string HTML { get; set; }
        public string Summary { get; set; }
        public int XmlConfigId { get; set; }
        public int FolderId { get; set; }
        public virtual Folder Folder { get; set; }
    }
}
