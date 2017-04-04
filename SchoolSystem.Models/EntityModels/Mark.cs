using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.EntityModels
{
    public class Mark
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Student Student { get; set; }
    }
}
