using NetMQ;
using NetMQ.Sockets;
using Serilog;
using System;
using System.Threading;

namespace TestYamlFile
{
    internal class PushServ
    {
        public PushServ()
        {
        }

        internal void DoTest()
        {

            using (var subSocket = new SubscriberSocket())
            using (var poller = new NetMQPoller { subSocket })
            {
                subSocket.Options.ReceiveHighWatermark = 1000;
                subSocket.Connect("tcp://localhost:12345");
                subSocket.Subscribe("CMD");
                Console.WriteLine("Subscriber socket connecting...");
                
                poller.RunAsync();
                var myLogger = new MyLogger();
                //TODO:: pass yaml config 
                myLogger.Setup();

                subSocket.ReceiveReady += (s, a) =>
                {
                    string message = a.Socket.ReceiveFrameString();

                    Log.Information(message);

                };
                while (true)
                {
                    Thread.Sleep(2 * 1000);
                }

            }

        }
    }
}