using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SeedSolution.Entity.DTO;

namespace SeedSolution.WebApi.Handlers
{
    public class CustomResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            try
            {
                return GenerateResponse(request, response);
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        private HttpResponseMessage GenerateResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            string errorMessage = null;
            HttpStatusCode statusCode = response.StatusCode;
            ResponseService responseMetadata = new ResponseService();
            DateTime dt;
            if (!IsResponseValid(response))
            {
                responseMetadata.Version = "1.0";
                responseMetadata.StatusCode = response.StatusCode;
                responseMetadata.ErrorMessage = GetErrorMessage(response);
                //responseMetadata.ErrorMessage = response.ReasonPhrase;
                dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                responseMetadata.DateStamp = dt;
                return request.CreateResponse(response.StatusCode, responseMetadata);
            }

            object responseContent;
            if (response.TryGetContentValue(out responseContent))
            {
                HttpError httpError = responseContent as HttpError;
                if (httpError != null)
                {
                    errorMessage = httpError.Message;
                    statusCode = HttpStatusCode.InternalServerError;
                    responseContent = null;
                }
            }
            responseMetadata.Version = "1.0";
            responseMetadata.StatusCode = statusCode;
            responseMetadata.Result = responseContent;
            dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            responseMetadata.DateStamp = dt;
            responseMetadata.ErrorMessage = errorMessage;
            var result = request.CreateResponse(response.StatusCode, responseMetadata);
            return result;
        }
        private bool IsResponseValid(HttpResponseMessage response)
        {
            if ((response != null) && (response.StatusCode == HttpStatusCode.OK))
                return true;
            return false;
        }

        private string GetErrorMessage(HttpResponseMessage response)
        {
            string vMessage = response.ReasonPhrase;
            if (response.Content != null)
            {
                var httpError = response.Content.ReadAsAsync<HttpError>().Result;
                switch (response.StatusCode)
                {
                    case HttpStatusCode.InternalServerError:
                        vMessage = httpError["ExceptionMessage"].ToString();
                        break;
                    case HttpStatusCode.BadRequest:
                        vMessage = httpError["Message"].ToString();
                        break;
                    default:
                        vMessage = response.ReasonPhrase;
                        break;
                }
            }
            return vMessage;
        }
    }
}