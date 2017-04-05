using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.EntityModels
{
    public class Mark
    {
        public int Id { get; set; }

        [Required]
        [Range(2, 6)]
        public int Value { get; set; }

        [Required]
        public virtual Subject Subject { get; set; }

        [Required]
        public virtual Student Student { get; set; }
    }
}
