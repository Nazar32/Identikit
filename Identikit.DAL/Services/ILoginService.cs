using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.DAL.Services
{
    public interface ILoginService
    {
        bool CheckIsUserValid(string login, string password);
    }
}
