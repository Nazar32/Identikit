using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Entities
{
    public interface Idenfiable
    {
        Guid Id{ get; set; }
    }
}
