using System.Net;

namespace FastWorker
{
    internal class Helper
    {
        internal static void DownloadFile(string url, string Location, string filename)
        {
            //TODO::folder should as parameter by pass ,YAMF config specify dest path

            if (!System.IO.Directory.Exists(Location))
            {
                System.IO.Directory.CreateDirectory(Location);
            }
            var webClient = new WebClient();
            try
            {
                webClient.DownloadFile(url, Location + filename);
            }
            catch
            {


            }



        }
    }
}