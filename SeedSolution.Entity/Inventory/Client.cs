using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Entity.Inventory
{
    [Serializable]
    [DataContract]
    public class Client
    {
        [DataMember]
        public int client_id { get; set; }

        [DataMember]
        public string client_name { get; set; }

        [DataMember]
        public string client_document { get; set; }

        [DataMember]
        public DateTime client_birthday { get; set; }

        [DataMember]
        public bool state { get; set; }
    }
}
