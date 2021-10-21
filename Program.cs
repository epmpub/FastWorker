using System.Threading.Tasks;
namespace TestYamlFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var pushServ = new PushServ();
            pushServ.DoTest();

            //Helper.DownloadFile("https://it2u.oss-cn-shenzhen.aliyuncs.com/yaml/conf.yaml", "c:\\Windows\\Temp\\", "conf.yaml");
            //var parser = new MyParser();
            //parser.DoTest();

        }
    }
}
