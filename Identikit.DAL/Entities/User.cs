using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Entities
{
    public class User : Idenfiable
    {
        [Key, Required]
        public Guid Id{ get; set; }

        [Required, MaxLength(50)]
        public string Login { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
