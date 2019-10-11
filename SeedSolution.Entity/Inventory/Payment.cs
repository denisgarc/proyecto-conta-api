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
    public class Payment
    {
        [DataMember]
        public int transaction_id { get; set; }

        [DataMember]
        public int client_id { get; set; }

        [DataMember]
        public DateTime transaction_date { get; set; }

        [DataMember]
        public decimal transaction_amount { get; set; }

    }
}
