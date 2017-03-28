using ScreenStateApi.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using Untility;

namespace ScreenStateApi.DAL
{
    public class HARDWARE_STATE_DAL : BaseDAL
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public int Add(string jsonStr)
        {
            try
            {
                //反序列化
                TH_HARDWARE_STATE model = JsonHelper.DeserializeJson<TH_HARDWARE_STATE>(jsonStr);
                model.storetime = DateTime.Now;
                string cityName = "";
                string position = "";

                StationInfoModel infoModel = new TS_SOCKETLIB_CONFIG_DAL().getStationInfo(model.computername);
                model.hardsn = infoModel.hardsn;

                //发邮件
                string flag;
                string brokenInfo = ErrorCode.GetErrorInfo(infoModel.pcName,
                                                            infoModel.cityName,
                                                            infoModel.lineName,
                                                            infoModel.station,
                                                            infoModel.position, 
                                                            model.errornum, 
                                                            Convert.ToDateTime(model.producetime).ToString("yyyy-MM-dd HH:mm:ss"), 
                                                            out flag);
                if (flag=="1")
                {
                    EmailHelper.SendEmailToReportBroken(brokenInfo);
                }

                //新增
                dbcontext.TH_HARDWARE_STATE.Add(model);

                //保存
                int i = dbcontext.SaveChanges();
            
                return i;
            }
            catch (DbEntityValidationException ex)
            {
                string error;

                //获取EF错误
                foreach (var item in ex.EntityValidationErrors)
                {
                    foreach (var item2 in item.ValidationErrors)
                    {
                        error = string.Format("{0}:{1}\r\n", item2.PropertyName, item2.ErrorMessage);
                    }
                }
                throw ex;
            }
        }
    }
}
