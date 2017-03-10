using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Entities
{
    public class PersonIdentity
    {
        [Key, Required]
        public Guid Id{ get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Surname { get; set; }

        [Required, MaxLength(50)]
        public string Lastname { get; set; }

        public double Height { get; set; }
        public HairColor Hair { get; set; }
        public EyeColor Eye { get; set; }
    }
}
