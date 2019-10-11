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
    public class ColorBL : IColorBL
    {
        #region Private Variables

        private readonly IColorRepository _colorRepository;

        #endregion

        #region Constructor

        public ColorBL()
        {
            this._colorRepository = StructureMap.ObjectFactory.GetInstance<IColorRepository>();
        }

        #endregion

        #region Public Methods
        public List<Color> GetColor(int? id = null)
        {
            try
            {
                return this._colorRepository.GetColor(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveColor(Color color)
        {
            try
            {
                this._colorRepository.SaveColor(color);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
