using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Entity.SecurityAccess
{
    [Serializable]    
    [DataContract]
    public class SysRol
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [MaxLength(150)]
        public string Name { get; set; }
        [DataMember]
        public bool Status { get; set; }
    }
}
