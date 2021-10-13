using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TestYamlFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var task_push = Task.Run(() => {
                var pushServ = new PushServ();
                pushServ.DoTest();
            });

            var parser = new MyParser();
            parser.DoTest();

        }
    }
}
