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
    public class BranchController : ApiController
    {
        #region Private Variables

        private readonly IBranchBL _branchBL;

        #endregion

        #region Constructor

        public BranchController()
        {
            this._branchBL = StructureMap.ObjectFactory.GetInstance<IBranchBL>();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("api/branch")]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return this._branchBL.GetBranch(id);
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/branch")]
        public async Task<IHttpActionResult> Save(Sucursal branch)
        {
            try
            {
                await Task.Run(() =>
                {
                    this._branchBL.SaveBranch(branch);
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
