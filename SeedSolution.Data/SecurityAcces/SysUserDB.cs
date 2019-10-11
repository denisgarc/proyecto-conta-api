using SeedSolution.Data.Interfaces.SecurityAcces;
using SeedSolution.Data.Connection.Interfaces;
using SeedSolution.Data.Tools;
using SeedSolution.Entity.SecurityAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.SecurityAcces
{
    public class SysUserDB : ISysUser
    {
        private IConnectionTools tools;
        private string strMessage { get; set; }
        private bool bStatus { get; set; }
        public SysUserDB()
        {
            tools = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
            bStatus = false;
            strMessage = string.Empty;
        }
        public SysUser GetUserByUser(string pUser)
        {
            SysUser sysUser = new SysUser();
            try
            {
                SqlCommand cmd = new SqlCommand() {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Sys_GetUserByUser"
                };                
                cmd.Parameters.Add("@pUser", SqlDbType.VarChar).Value = pUser;
                sysUser = tools.Getds(cmd).Tables[0].ToList<SysUser>().First();
                bStatus = tools.Status();
                strMessage = string.IsNullOrEmpty(tools.Error())?string.Empty:tools.Error();
            }
            catch (Exception ex)
            {
                bStatus = false;
                strMessage = "SysUserDB - GetUserByUser - "+ ex.Message;
                sysUser = null;
            }
            return sysUser;
        }
        public SysUser GetUserById(int pIdUser)
        {
            SysUser user = new SysUser();
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Sys_GetUserById"
                };
                cmd.Parameters.Add("@pIdUser", SqlDbType.Int).Value = pIdUser;
                user = tools.Getds(cmd).Tables[0].ToList<SysUser>().First();
                bStatus = tools.Status();
                strMessage = string.IsNullOrEmpty(tools.Error()) ? string.Empty : tools.Error();
            }
            catch (Exception ex)
            {
                bStatus = false;
                strMessage = "SysUserDB - GetUserById - " + ex.Message;
                user = null;
            }
            return user;
        }
        public string Message()
        {
            return strMessage;
        }
        public bool Status()
        {
            return bStatus;
        }        
    }
}
