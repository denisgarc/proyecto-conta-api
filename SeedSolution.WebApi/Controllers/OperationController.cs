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
    public class OperationController : ApiController
    {
        #region Private Variables

        private readonly IOperationBL _operationBL;

        #endregion

        #region Constructor

        public OperationController()
        {
            this._operationBL = StructureMap.ObjectFactory.GetInstance<IOperationBL>();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("api/operation")]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return this._operationBL.GetOperation(id);
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/operation")]
        public async Task<IHttpActionResult> Save(Operacion operation)
        {
            try
            {
                await Task.Run(() =>
                {
                    this._operationBL.SaveOperation(operation);
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
