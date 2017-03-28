using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenStateApi.DAL;

namespace ScreenStateApi.BLL
{
    public class HARDWARE_STATE_BLL
    {
        HARDWARE_STATE_DAL dal = new HARDWARE_STATE_DAL();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public int Add(string jsonStr)
        {
            return dal.Add(jsonStr);
        }
    }
}
