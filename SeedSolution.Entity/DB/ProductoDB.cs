using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Entity.DB
{
    [Serializable]
    [DataContract]
    public class ProductoDB
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public int CodMarca { get; set; }

        [DataMember]
        public string NombreMarca { get; set; }

        [DataMember]
        public Int16 CodColor { get; set; }

        [DataMember]
        public string NombreColor { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int Tamano { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}
