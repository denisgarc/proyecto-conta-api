using SeedSolution.Entity.SecurityAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeedSolution.Business.Interfaces
{
    public interface ISecurityAccesBL
    {
        SysUser GetUserByUser(string pUser);
        SysUser GetUserById(int pId);
        SysUser GetUserByCredentials(string pUser, string pPass);
        bool PassRenewalRequired(int pIdUser);
        bool Status();
        string Message();
    }
}
