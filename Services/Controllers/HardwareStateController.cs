using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ScreenStateApi.BLL;
using Untility;


namespace Services.Controllers
{

    public class HardwareStateController : ApiController
    {
        HARDWARE_STATE_BLL bll = new HARDWARE_STATE_BLL();

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public IHttpActionResult PostData([FromBody]string jsonStr)
        {
            try
            {
                return Ok(bll.Add(jsonStr));
            }
            catch (Exception ex)
            {
                WriteLog.WriteToFile(string.Format("接口异常-异常信息：{0},{1}",
                                                          ex.Message.ToString(),
                                                          DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                throw ex;
            }
        }
    }
}