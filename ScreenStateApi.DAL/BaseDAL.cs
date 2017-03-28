using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenStateApi.DAL
{
    public class BaseDAL
    {
        //实例化数据库上下文
        public socketlib_serverEntities dbcontext = new socketlib_serverEntities();
    }
}
