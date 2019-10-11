using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Entity.DTO
{
    [Serializable]
    [DataContract]
    public class ResponseService
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public HttpStatusCode StatusCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public object Result { get; set; }

        [DataMember]
        public DateTime DateStamp { get; set; }
    }
}
