using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LB4._1
{
    static class Logger
    {
        public static void info(String info)
        {
            Debug.WriteLine($"[INFO {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}]: {info}");
        }
    }
}
