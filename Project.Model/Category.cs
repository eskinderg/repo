using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Model
{
    public class Category : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        public IEnumerable<Category>SubCategory { get; private set; }

    }
}
