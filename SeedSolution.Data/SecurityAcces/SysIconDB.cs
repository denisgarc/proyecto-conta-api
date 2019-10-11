using SeedSolution.Data.Interfaces.SecurityAcces;
using SeedSolution.Data.Connection.Interfaces;
using SeedSolution.Entity.SecurityAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.SecurityAcces
{
    public class SysIconDB
    {
        private IConnectionTools tools;
        public string Message { get; set; }
        public bool Status { get; set; }
        public SysIconDB()
        {
            tools = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
            Status = false;
            Message = string.Empty;
        }
        public List<SysIcon> GetAll()
        {
            List<SysIcon> icons = new List<SysIcon>();
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return icons;
        }
    }
}
