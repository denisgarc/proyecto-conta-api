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
    public class CardexBL : ICardexBL
    {
        #region Private Variables

        private readonly ICardexRepository _cardexRepository;

        #endregion

        #region Constructor

        public CardexBL()
        {
            this._cardexRepository = StructureMap.ObjectFactory.GetInstance<ICardexRepository>();
        }

        #endregion

        #region Public Methods
        public List<Cardex> GetCardex(int? id = null)
        {
            try
            {
                return this._cardexRepository.GetCardex(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveCardex(Cardex cardex)
        {
            try
            {
                this._cardexRepository.SaveCardex(cardex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
