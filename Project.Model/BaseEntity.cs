using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class BaseEntity
    {   
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
