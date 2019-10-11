using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Entity.SecurityAccess
{
    [Serializable]
    [DataContract]
    public class SysRolAccess
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public int IdMenu { get; set; }
        [DataMember]
        public bool AllowCreate { get; set; }
        [DataMember]
        public bool AllowModify { get; set; }
        [DataMember]
        public bool AllowDelete { get; set; }
        [DataMember]
        public bool AllowView { get; set; }
    }
}
