using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Text;

namespace TestYamlFile
{
    internal class Executor
    {
        public Executor(Config c)
        {
            var Logger = new MyLogger();
            Logger.Setup(c);
            //LoggerSetup(c);
        }

        //private static void LoggerSetup(Config c)
        //{
        //    Log.Logger = new LoggerConfiguration()
        //     .MinimumLevel.Debug()
        //     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        //     .Enrich.FromLogContext()
        //     .WriteTo.Console()
        //     .WriteTo.File(c.Logger + "\\pwshCMD-stdout.txt", encoding: Encoding.UTF8)
        //     .CreateLogger();
        //}

        public void RunPWSHCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = @"/c powershell  -NoLogo -NoProfile -executionpolicy unrestricted " + "path";
            startInfo.Arguments = @"/c powershell  -NoLogo -NoProfile -executionpolicy unrestricted -Command " + command;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = false;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            Log.Information(process.StandardOutput.ReadToEnd());
            //Log.Error(process.StandardError.ReadToEnd());

        }
        public void RunBATCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = @"/c powershell  -NoLogo -NoProfile -executionpolicy unrestricted " + "path";
            startInfo.Arguments = @"/c " + command;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = false;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            Log.Information(process.StandardOutput.ReadToEnd());

        }

        public void RunVBSCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = @"/c powershell  -NoLogo -NoProfile -executionpolicy unrestricted " + "path";
            startInfo.Arguments = @"/c cscript " + command;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = false;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            Log.Information(process.StandardOutput.ReadToEnd());

        }


        internal void Run(Config p)
        {

            //Console.WriteLine($"{p.Name},{p.Logger}");

            foreach (var item in p.Task)
            {
                Console.WriteLine($"{item["Job"].Name},{item["Job"].Id},{item["Job"].Type},{item["Job"].Url},{item["Job"].Command}");

                switch (item["Job"].Type)
                {
                    case "PWSH":
                        Console.WriteLine("PWSH");
                        RunPWSHCommand(item["Job"].Command);
                        break;
                    case "BAT":
                        Console.WriteLine("BAT");
                        RunBATCommand(item["Job"].Command);
                        break;
                    case "VBS":
                        Console.WriteLine("VBS");
                        RunBATCommand(item["Job"].Command);
                        break;
                    default:
                        Console.WriteLine("Unkown");
                        break;
                }
            }


        }
    }
}