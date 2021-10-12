using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TestYamlFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new MyParser();
            parser.DoTest();

        }
    }
}
