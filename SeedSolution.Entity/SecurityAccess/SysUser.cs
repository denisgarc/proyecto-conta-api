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
    public class SysUser
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public DateTime CreationDate { get; set; }
        [DataMember]
        public DateTime RemovalDate { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public DateTime RenewalPassDate { get; set; }
        [DataMember]
        public int LoginAttemps { get; set; }
        [DataMember]
        public int IdPerson { get; set; }
    }
}
