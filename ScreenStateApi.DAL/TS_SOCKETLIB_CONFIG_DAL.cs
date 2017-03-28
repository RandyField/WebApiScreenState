using ScreenStateApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untility;

namespace ScreenStateApi.DAL
{
    public class TS_SOCKETLIB_CONFIG_DAL : BaseDAL
    {
        /// <summary>
        /// 根据pcname获取硬件编号 
        /// </summary>
        /// <param name="pcname"></param>
        /// <param name="cityName">out</param>
        /// <param name="position">out</param>
        /// <returns></returns>
        public string GetHardsn(string pcname, out string cityName, out string position)
        {
            try
            {
                string hardsn = "未获取到hardsn";
                cityName = "未获取城市名称";
                position = "未获取站点名称";
                TS_SOCKETLIB_CONFIG model = null;

                //linq
                var query = from u in dbcontext.TS_SOCKETLIB_CONFIG
                            select u;
                query = query.Where(p => p.computername == pcname);
                if (query.ToList() != null && query.ToList().Count > 0)
                {
                    model = query.First();
                    hardsn = model.hardsn;
                    cityName = model.cityname;
                    position = model.position;
                }
                return hardsn;
            }
            catch (Exception ex)
            {
                WriteLog.WriteToFile(string.Format("获取Hardsn异常-异常信息：{0},{1}", ex.Message.ToString(), DateTime.Now.ToString("yyyy-MM-DD HH:mm:ss")));
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcname"></param>
        /// <returns></returns>
        public StationInfoModel getStationInfo(string pcname)
        {
            try
            {
                StationInfoModel infoModel = new StationInfoModel();
                infoModel.hardsn = "未获取到hardsn";
                infoModel.cityName = "未获取到城市名称";
                infoModel.lineName = "未获取到线路";
                infoModel.pcName = pcname;
                infoModel.position = "未获取到点位";
                infoModel.station = "未获取到站点";
               
                TS_SOCKETLIB_CONFIG model = null;

                //linq
                var query = from u in dbcontext.TS_SOCKETLIB_CONFIG
                            select u;
                query = query.Where(p => p.computername == pcname);
                if (query.ToList() != null && query.ToList().Count > 0)
                {
                    model = query.First();
                    infoModel.hardsn = model.hardsn.Trim();
                    infoModel.cityName = model.cityname.Trim();
                    infoModel.position = model.position.Trim();
                    infoModel.station = model.stationname.Trim();
                    infoModel.lineName = model.linename.Trim(); 
                }
                return infoModel;
            }
            catch (Exception ex)
            {
                WriteLog.WriteToFile(string.Format("获取站点详细信息异常-异常信息：{0},{1}", ex.Message.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                throw ex;
            }
        }
    }
}
