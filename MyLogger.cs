using Serilog;
using Serilog.Events;
using System;
using System.Text;

namespace FastWorker
{
    internal class MyLogger
    {
        public MyLogger()
        {
        }

        internal void Setup(Config c)
        {
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
             .Enrich.FromLogContext()
             //.WriteTo.Console()
             .WriteTo.File(c.Logger + "\\pwshCMD-stdout.txt", encoding: Encoding.UTF8)
             .CreateLogger();
        }
        //share global log settings.
        internal void Setup()
        {
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .WriteTo.File("c:\\log2\\netMQ-stdout.txt", encoding: Encoding.UTF8)
             .CreateLogger();
        }
    }
}