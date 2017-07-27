using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluteEngine
{
    class Trace
    {
        /// <summary>
        /// Makes a log in the output using a string
        /// </summary>
        /// <param name="text">Text</param>
        public static void Log(string text)
        {
            Debug.WriteLine("Log: "+text);
        }

        /// <summary>
        /// Makes a log in the output using an object
        /// </summary>
        /// <param name="o">Object</param>
        public static void Log(object o)
        {
            Debug.WriteLine("Log: " + o.ToString());
        }
    }
}
