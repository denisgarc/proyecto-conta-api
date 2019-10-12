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
    public class CardexDB
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CodSucursal { get; set; }

        [DataMember]
        public int CodOperacion { get; set; }

        [DataMember]
        public int CodProducto { get; set; }

        [DataMember]
        public DateTime FechaOperacion { get; set; }

        [DataMember]
        public Int16 Cantidad { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
    }
}
