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
    public class SysMenu
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [MaxLength (100)]
        public string Name { get; set; }
        [DataMember]
        [MaxLength(25)]
        public string Action { get; set; }
        [DataMember]
        [MaxLength(25)]
        public string Controller { get; set; }
        [DataMember]
        [MaxLength(300)]
        public string Url { get; set; }
        [DataMember]
        public int IdIcon { get; set; }
        [DataMember]        
        public int IdTop { get; set; }
        [DataMember]
        public bool Status { get; set; }
    }
}

