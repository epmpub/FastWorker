using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ReadYamlFile
{
    class Configuration
    {
        public string DatabaseConnectionString { get; set; }
        public string UploadFolder { get; set; }
        public List<string> ApprovedFileTypes { get; set; }
    }

    class Program
    {

        static void de()
        {
            var yml = @"
                name: George Washington
                age: 89
                height_in_inches: 5.75
                addresses:
                  home:
                    street: 400 Mockingbird Lane
                    city: Louaryland
                    state: Hawidaho
                    zip: 99970
                ";

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
                .Build();

            //yml contains a string containing your YAML
            var p = deserializer.Deserialize<Person>(yml);
            var h = p.Addresses["home"]; //Be care ful
            System.Console.WriteLine($"{p.Name} is {p.Age} years old and lives at {h.Street} in {h.City}, {h.State}.");
        }

        static void se()
        {
            var person = new Person
            {
                Name = "Abe Lincoln",
                Age = 25,
                HeightInInches = 6f + 4f / 12f,
                Addresses = new Dictionary<string, Address>{
                    { "home", new  Address() {
                            Street = "2720  Sundown Lane",
                            City = "Kentucketsville",
                            State = "Calousiyorkida",
                            Zip = "99978",
                            }
                    },
                    { "work", new  Address() {
                            Street = "1600 Pennsylvania Avenue NW",
                            City = "Washington",
                            State = "District of Columbia",
                            Zip = "20500",
                        }
                    },
    }
            };

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(person);
            System.Console.WriteLine(yaml);

        }

        static void ReadFromTxt()
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                .Build();

            var myConfig = deserializer.Deserialize<Configuration>(File.ReadAllText("config.yaml"));

            Console.WriteLine(myConfig.DatabaseConnectionString);
            Console.WriteLine(myConfig.UploadFolder);

            foreach (var item in myConfig.ApprovedFileTypes)
            {
                Console.WriteLine(item);
            }

        }
        static void Main(string[] args)
        {

            //se();
            de();








        }

        private class Address
        {
            public string Street { get; internal set; }
            public string City { get; internal set; }
            public string Zip { get; internal set; }
            public string State { get; internal set; }
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public float HeightInInches { get; set; }
            public Dictionary<string, Address> Addresses { get; set; }
        }
    }
}
