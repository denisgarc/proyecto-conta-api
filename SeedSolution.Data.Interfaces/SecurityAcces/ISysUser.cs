using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeedSolution.Entity.SecurityAccess;

namespace SeedSolution.Data.Interfaces.SecurityAcces
{
    public interface ISysUser
    {
        SysUser GetUserByUser(string pUser);
        SysUser GetUserById(int pIdUser);
        string Message();
        bool Status();
    }
}
