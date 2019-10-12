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
    public class CardexController : ApiController
    {
        #region Private Variables

        private readonly ICardexBL _cardexBL;

        #endregion

        #region Constructor

        public CardexController()
        {
            this._cardexBL = StructureMap.ObjectFactory.GetInstance<ICardexBL>();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("api/cardex")]
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return this._cardexBL.GetCardex(id);
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/cardex/filter")]
        public async Task<IHttpActionResult> GetFiltered(DateTime startDate, DateTime finishDate, int? branch = null, int? product = null)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    return this._cardexBL.GetCardexFiltered(startDate, finishDate, branch, product);
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/cardex")]
        public async Task<IHttpActionResult> Save(Cardex cardex)
        {
            try
            {
                await Task.Run(() =>
                {
                    this._cardexBL.SaveCardex(cardex);
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
