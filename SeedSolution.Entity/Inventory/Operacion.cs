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
    public class Operacion
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool Credito { get; set; }

        [DataMember]
        public bool Debito { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}
