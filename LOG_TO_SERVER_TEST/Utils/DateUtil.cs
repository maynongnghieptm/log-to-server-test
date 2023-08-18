using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LOG_TO_SERVER_TEST.Utils
{
    public class DateUtil
    {

        public static long millis()
        {
            return DateTime.Now.Ticks;
        }

    }
}
