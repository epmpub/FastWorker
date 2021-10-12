using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYamlFile
{
    public class Config
    {
        public string Name { get; set; }
        public int Interval { get; set; }
        public string Resource { get; set; }
        public string Logger { get; set; }
        public List<Dictionary<string, Job>> Task { get; set; }
    }

    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Command { get; set; }
        public string Url { get; set; }
    }

}
