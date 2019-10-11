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
    public class BranchBL : IBranchBL
    {
        #region Private Variables

        private readonly IBranchRepository _branchRepository;

        #endregion

        #region Constructor

        public BranchBL()
        {
            this._branchRepository = StructureMap.ObjectFactory.GetInstance<IBranchRepository>();
        }

        #endregion

        #region Public Methods
        public List<Sucursal> GetBranch(int? id = null)
        {
            try
            {
                return this._branchRepository.GetBranch(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveBranch(Sucursal branch)
        {
            try
            {
                this._branchRepository.SaveBranch(branch);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
