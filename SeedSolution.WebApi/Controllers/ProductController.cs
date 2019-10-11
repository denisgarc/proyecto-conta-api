using SeedSolution.Business.Interfaces.Inventory;
using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SeedSolution.WebApi.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        #region Private Variables

        private readonly IProductBL _productBL;

        #endregion

        #region Constructor

        public ProductController()
        {
            this._productBL = StructureMap.ObjectFactory.GetInstance<IProductBL>();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("api/product")]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return this._productBL.GetProduct(id);
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/product")]
        public async Task<IHttpActionResult> Save(Producto product)
        {
            try
            {
                await Task.Run(() =>
                {
                    this._productBL.SaveProduct(product);
                });

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}
