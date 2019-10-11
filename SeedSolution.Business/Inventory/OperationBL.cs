using SeedSolution.Business.Interfaces.Inventory;
using SeedSolution.Data.Interfaces.Inventory;
using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Business.Inventory
{
    public class OperationBL : IOperationBL
    {
        #region Private Variables

        private readonly IOperationRepository _operationRepository;

        #endregion

        #region Constructor

        public OperationBL()
        {
            this._operationRepository = StructureMap.ObjectFactory.GetInstance<IOperationRepository>();
        }

        #endregion

        #region Public Methods
        public List<Operacion> GetOperation(int? id = null)
        {
            try
            {
                return this._operationRepository.GetOperation(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveOperation(Operacion operation)
        {
            try
            {
                this._operationRepository.SaveOperation(operation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
