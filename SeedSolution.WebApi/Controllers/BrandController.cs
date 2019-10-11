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
    public class BrandController : ApiController
    {
        #region Private Variables

        private readonly IBrandBL _brandBL;

        #endregion

        #region Constructor

        public BrandController()
        {
            this._brandBL = StructureMap.ObjectFactory.GetInstance<IBrandBL>();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("api/brand")]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return this._brandBL.GetBrand(id);
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/brand")]
        public async Task<IHttpActionResult> Save(Marca brand)
        {
            try
            {
                await Task.Run(() =>
                {
                    this._brandBL.SaveBrand(brand);
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
