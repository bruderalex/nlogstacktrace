using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ConsoleApplication1
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var m = new MyClass();
            m.DoSomething();

            // <file unknown> in logfile
            _logger.Trace("message from Program");

            var frames = new StackTrace(true).GetFrames();
            if (frames != null)
            {
                // correct frames fith filename
                var fullFrames = frames.Where(frame => !string.IsNullOrEmpty(frame.GetFileName()));
            }
        }
    }

    public class MyClass
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public string Name { get; set; }
        public int Age { get; set; }

        public void DoSomething()
        {
            // <file unknown> in logfile
            _logger.Trace("message from MyClass");
        }
    }
}
