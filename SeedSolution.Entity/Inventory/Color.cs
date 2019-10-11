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
    public class Color
    {
        [DataMember]
        public Int16 Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}
