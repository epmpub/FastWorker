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
        public List<Dictionary<string, Command>> Tasks { get; set; }
        public List<Dictionary<string, Script>> Scripts { get; set; }

    }

    public class Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Cmd { get; set; }
    }



    public class Script
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }



}
