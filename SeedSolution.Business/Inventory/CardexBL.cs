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
        private readonly IBranchRepository _branchRepository;
        private readonly IOperationRepository _operationRepository;
        private readonly IProductBL _productRepository;

        #endregion

        #region Constructor

        public CardexBL()
        {
            this._cardexRepository = StructureMap.ObjectFactory.GetInstance<ICardexRepository>();
            this._branchRepository = StructureMap.ObjectFactory.GetInstance<IBranchRepository>();
            this._operationRepository = StructureMap.ObjectFactory.GetInstance<IOperationRepository>();
            this._productRepository = StructureMap.ObjectFactory.GetInstance<IProductBL>();
        }

        #endregion

        #region Public Methods
        public List<Cardex> GetCardex(int? id = null)
        {
            try
            {
                var cardex = this._cardexRepository.GetCardex(id);
                var branch = this._branchRepository.GetBranch();
                var operation = this._operationRepository.GetOperation();

                var response = (from t in cardex
                                select new Cardex()
                                {
                                    Id = t.Id,
                                    Sucursal = branch.Where(x => x.Codigo == t.CodSucursal).FirstOrDefault(),
                                    Operacion = operation.Where(x => x.Codigo == t.CodOperacion).FirstOrDefault(),
                                    Producto = this._productRepository.GetProduct(t.CodProducto).FirstOrDefault(),
                                    FechaOperacion = t.FechaOperacion,
                                    Cantidad = t.Cantidad,
                                    Descripcion = t.Descripcion
                                }).ToList();

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cardex> GetCardexFiltered(DateTime startDate, DateTime finishDate, int? branch = null, int? product = null)
        {
            try
            {
                var cardex = this._cardexRepository.GetCardexFiltered(startDate, finishDate, branch, product);
                var branchList = this._branchRepository.GetBranch();

                var response = (from t in cardex
                                select new Cardex()
                                {
                                    Id = t.Id,
                                    Sucursal = branchList.Where(x => x.Codigo == t.CodSucursal).FirstOrDefault(),
                                    Producto = this._productRepository.GetProduct(t.CodProducto).FirstOrDefault(),
                                    Cantidad = t.Cantidad,
                                    Descripcion = t.Descripcion
                                }).ToList();

                return response;
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
