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
    public class ColorController : ApiController
    {
        #region Private Variables

        private readonly IColorBL _colorBL;

        #endregion

        #region Constructor

        public ColorController()
        {
            this._colorBL = StructureMap.ObjectFactory.GetInstance<IColorBL>();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("api/color")]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return this._colorBL.GetColor(id);
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/color")]
        public async Task<IHttpActionResult> Save(Color color)
        {
            try
            {
                await Task.Run(() =>
                {
                    this._colorBL.SaveColor(color);
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
