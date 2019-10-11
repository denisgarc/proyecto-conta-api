using SeedSolution.Entity.SecurityAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Entity.DTO
{
    [DataContract]
    [Serializable]
    public class UserClaims : ResponseService
    {
        [DataMember]
        public SysUser User { get; set; }
        [DataMember]
        List<SysRol> Rols { get; set; }
        [DataMember]
        List<SysRolAccess> Access { get; set; }
    }
}
