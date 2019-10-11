using SeedSolution.Data.Interfaces.SecurityAcces;
using SeedSolution.Entity.SecurityAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeedSolution.Business.Interfaces;

namespace SeedSolution.Business.SecurityAccess
{
    public class SecurtiyAccesBL : ISecurityAccesBL
    {
        private bool ResponseStatus { get; set; }
        private string ResponseMessage { get; set; }
        public SysUser GetUserByUser(string pUser)
        {
            SysUser user = new SysUser();
            ISysUser userDA;
            try
            {                
                userDA = StructureMap.ObjectFactory.GetInstance<ISysUser>();
                user = userDA.GetUserByUser(pUser);
                this.ResponseStatus = userDA.Status();
                this.ResponseMessage = userDA.Message();
            }
            catch (Exception ex)
            {
                this.ResponseStatus = false;
                this.ResponseMessage = "SecurityAccesBL - GetUserByUser + " + ex.Message;
            }
            return user;
        }
        public SysUser GetUserById(int pId)
        {
            SysUser user = new SysUser();
            ISysUser userDB;
            try
            {
                userDB = StructureMap.ObjectFactory.GetInstance<ISysUser>();
                user = userDB.GetUserById(pId);
                this.ResponseMessage = userDB.Message();
                this.ResponseStatus = userDB.Status();
            }
            catch (Exception ex)
            {
                this.ResponseStatus = false;
                this.ResponseMessage = "SecurityAccesBL - GetUserById + " + ex.Message;
            }
            return user;           
        }
        public SysUser GetUserByCredentials(string pUser, string pPass)
        {
            SysUser user = new SysUser();
            try
            {
                user = GetUserByUser(pUser);
                if (this.ResponseStatus)
                {
                    if (user.Password != pPass)
                    {
                        user = null;
                        this.ResponseStatus = false;
                        this.ResponseMessage = "Credenciales Incorrectas";
                    }
                    else
                    {
                        this.ResponseStatus = true;
                        this.ResponseMessage = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ResponseStatus = false;
                this.ResponseMessage = "SecurityAccesBL - GetUserByCredentials - " + ex.Message;
            }
            return user;
        }
        public bool PassRenewalRequired(int pIdUser)
        {
            bool required = false;
            SysUser user;
            try
            {
                user = GetUserById(pIdUser);
                if (this.ResponseStatus)
                {
                    if (user.RenewalPassDate != null)
                    {
                        if (user.RenewalPassDate <= DateTime.Today)
                        {
                            required = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ResponseStatus = false;
                this.ResponseMessage = "SecurityAccesBL - PassRenewalRequired - " + ex.Message;
            }
            return required;
        }
        public bool Status()
        {
            return ResponseStatus;
        }
        public string Message()
        {
            return ResponseMessage;
        }
    }
}
