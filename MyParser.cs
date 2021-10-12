using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TestYamlFile
{
    internal class MyParser
    {
        public MyParser()
        {
        }

        internal void DoTest()
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
                .Build();

            var conf = deserializer.Deserialize<Config>(File.ReadAllText("conf.yaml"));

            var executor = new Executor(conf);
            executor.Run(conf);

        }



    }
}