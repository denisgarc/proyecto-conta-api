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
    public class Producto
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public Marca Marca { get; set; }

        [DataMember]
        public Color Color { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int Tamano { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}
