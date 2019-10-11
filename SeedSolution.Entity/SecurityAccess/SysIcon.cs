using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SeedSolution.Entity.SecurityAccess
{
    [Serializable]
    [DataContract]
    public class SysIcon
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [MaxLength(50)]
        public string Name { get; set; }
        [DataMember]
        [MaxLength(50)]
        public string Class { get; set; }
        [DataMember]
        public bool Status { get; set; }
    }
}
