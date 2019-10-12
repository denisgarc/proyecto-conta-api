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
    public class ProductBL : IProductBL
    {
        #region Private Variables

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductBL()
        {
            this._productRepository = StructureMap.ObjectFactory.GetInstance<IProductRepository>();
        }

        #endregion

        #region Public Methods
        public List<Producto> GetProduct(int? id = null)
        {
            try
            {
                // Obtenemos cubo de datos
                var data = this._productRepository.GetProduct(id);

                // Convertimos a modelo de producto
                var response = (from prod in data
                                select new Producto()
                                {
                                    Codigo = prod.Codigo,
                                    Marca = new Marca()
                                    {
                                        Codigo = prod.CodMarca,
                                        Nombre = prod.NombreMarca,
                                        Estado = true
                                    },
                                    Color = new Color()
                                    {
                                        Codigo = prod.CodColor,
                                        Nombre = prod.NombreColor,
                                        Estado = true
                                    },
                                    Descripcion = prod.Descripcion,
                                    Tamano = prod.Tamano,
                                    Estado = prod.Estado
                                }).ToList();

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveProduct(Producto product)
        {
            try
            {
                this._productRepository.SaveProduct(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
