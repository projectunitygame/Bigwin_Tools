using api_cms.common;
using api_cms.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_cms.Controllers
{
    [RoutePrefix("api/v1/Tracking")]
    public class TrackingController : ApiController
    {
        [Route("UpdateDevice")]
        [HttpPost]
        public HttpResponseMessage UpdateDevice(DeviceInfo p)
        {
            string ip = UtilClass.GetIPAddress();
            LogClass.SaveCustomerLog("UpdateDevice: " + JsonConvert.SerializeObject(p) + ",IP " + ip);
            ResultTracking result = new ResultTracking();
            result.msg = "success";
            result.status = 100;
            //try
            //{
            //    var publisherInfo = publisher.CheckPublickey(p, version);
            //    if (publisherInfo.status == (int)ERROR_CODDE.SUCCESS)
            //    {
            //        ManagerModel managerModel = new ManagerModel();
            //        var data = JsonConvert.DeserializeObject<AgencyEntity>(publisherInfo.data.ToString());
            //        string msg = "";
            //        result.status = managerModel.AgencyModel.CreateAgency_C2(data, ref msg);
            //        result.msg = msg;
            //    }
            //    else
            //        result = publisherInfo;
            //}
            //catch (Exception ex)
            //{
            //    LogClass.SaveError("ERROR CreateAgency_C2: " + ex.Message, ex, true);
            //    result.status = (int)ERROR_CODDE.ERROR_EX;
            //    result.msg = ex.Message;
            //}
            return Request.CreateResponse(result);
        }
    }
}
