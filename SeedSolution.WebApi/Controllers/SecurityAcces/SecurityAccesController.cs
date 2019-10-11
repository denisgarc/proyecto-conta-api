using SeedSolution.Business.Interfaces;
using SeedSolution.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace SeedSolution.WebApi.Controllers.SecurityAccess
{
    [Authorize]
    public class SecurityAccessController : ApiController
    {   
        // api/SecurityAccessController/RenewalRequiered/1
        //[HttpGet]        
        //public ResponseService RenewalRequired(int id)
        //{
        //    ResponseService response = new ResponseService();
        //    ISecurityAccesBL userBL;
        //    try
        //    {
        //        userBL = StructureMap.ObjectFactory.GetInstance<ISecurityAccesBL>();
        //        var identity = (ClaimsIdentity)RequestContext.Principal.Identity;
        //        var claims = identity.Claims.ToList();
        //        int UserId = int.Parse(claims[1].Value.ToString());                
        //        response.Result = userBL.PassRenewalRequired(id);
        //        if (userBL.Status())
        //        {
        //            response.ResponseStatus = 200;
        //            response.ResponseMessage = string.Empty;
        //        }
        //        else
        //        {
        //            response.ResponseStatus = 400;
        //            response.ResponseMessage = userBL.Message();
        //        }
        //    }
        //    catch (Exception EX)
        //    {
        //        response.ResponseStatus = 400;
        //        response.ResponseMessage = EX.Message;
        //    }
        //    return response;
        //}
    }
}
