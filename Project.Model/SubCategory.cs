using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Model
{
    public class SubCategory : BaseEntity
    {
        [Key]
        public int Id{ get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Category> Category { get; set; } 

    }
}
