using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FastWorker
{
    internal class PullServ
    {
        public PullServ() { }

        internal void DoTest(string url)
        {
            string configString = null;
            try
            {
                configString = Helper.DownloadString(url);
            }
            catch
            {
            }

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
                .Build();
            Config conf = null;
            try
            {
                conf = deserializer.Deserialize<Config>(configString/*File.ReadAllText(filePath+fileName)*/);
            }
            catch (Exception e)
            {

                Console.WriteLine($"Des error with: {e.Message} ");
            }

            var executor = new Executor(conf);
            executor.Run(conf);

        }



    }
}