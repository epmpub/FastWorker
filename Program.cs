using System.Threading.Tasks;
namespace FastWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            //ToDo: Run FastWorker ,Sub/Pub Mode


            var pushServ = new PushServ();
            pushServ.DoTest();


            //ToDo: Run Pull Serv, Pull Mode.

            //Helper.DownloadFile("https://it2u.oss-cn-shenzhen.aliyuncs.com/yaml/conf.yaml", "c:\\windows\\temp\\", "conf.yaml");
            //var pullServ = new PullServ();
            //pullServ.DoTest();

        }
    }
}
