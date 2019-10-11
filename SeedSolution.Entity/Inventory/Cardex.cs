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
    public class Cardex
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Sucursal Sucursal { get; set; }

        [DataMember]
        public Operacion Operacion  { get; set; }

        [DataMember]
        public Producto Producto { get; set; }

        [DataMember]
        public DateTime FechaOperacion { get; set; }

        [DataMember]
        public Int16 Cantidad { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
    }
}
