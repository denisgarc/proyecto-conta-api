using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StructureMap;
using SeedSolution.Business.Interfaces.Inventory;
using SeedSolution.Entity.Inventory;
using System.Web.Http.Cors;

namespace SeedSolution.WebApi.Controllers
{
    [Authorize]
    public class InventoryController2 : ApiController
    {
        #region Private Variables

        private IUserMaintBL _UserMaint;
        private IUserPaymentBL _UserPayment;

        #endregion

        #region constructor
        public InventoryController2()
        {
            this._UserMaint = ObjectFactory.GetInstance<IUserMaintBL>();
            this._UserPayment = ObjectFactory.GetInstance<IUserPaymentBL>();
        }
        #endregion

        [HttpPost]
        [Route ("dummy/add_client")]
        public async Task<IHttpActionResult> AddClient(Client client)
        {
            try
            {
                await Task.Run(() => this._UserMaint.SaveClient(client));
                if (this._UserMaint.Status())
                    return Ok();
                else
                    return BadRequest(this._UserMaint.Message());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("dummy/add_payment")]
        public async Task<IHttpActionResult> AddPayment(Payment payment)
        {
            try
            {
                await Task.Run(() => this._UserPayment.SavePayment(payment));
                return Ok();
            }       
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ResponseType(typeof(Client))]
        [Route("dummy/search_client")]
        public async Task<IHttpActionResult> SearchClient(string document_number)
        {
            try
            {
                var vResult = await Task.Run(() => this._UserMaint.SearchClient(document_number));
                return Ok(vResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ResponseType(typeof(Payment))]
        [Route("dummy/search_payment")]
        public async Task<IHttpActionResult> GetAssignment(int client_id)
        {
            try
            {
                var vResult = await Task.Run(() => this ._UserPayment.SearchPayment(client_id));
                return Ok(vResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
