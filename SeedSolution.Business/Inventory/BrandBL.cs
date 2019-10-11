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
    public class BrandBL: IBrandBL
    {
        #region Private Variables

        private readonly IBrandRepository _brandRepository;

        #endregion

        #region Constructor

        public BrandBL()
        {
            this._brandRepository = StructureMap.ObjectFactory.GetInstance<IBrandRepository>();
        }

        #endregion

        #region Public Methods

        public List<Marca> GetBrand(int? id = null)
        {
            try
            {
                return this._brandRepository.GetBrand(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveBrand(Marca brand)
        {
            try
            {
                this._brandRepository.SaveBrand(brand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
