using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading;

namespace TestYamlFile
{
    public static class MQExtensions
    {
        //public static void SendT<T>(this PublisherSocket socket, T src)
        //{
        //    var json = JsonConvert.SerializeObject(src);
        //    socket.SendFrame(json);
        //}

        //public static T ReceiveT<T>(this PublisherSocket socket)
        //{
        //    var json = socket.ReceiveFrameString();
        //    T obj = JsonConvert.DeserializeObject<T>(json);
        //    return obj;
        //}

        public static void SendT<T>(this SubscriberSocket socket, T src)
        {
            var json = JsonConvert.SerializeObject(src);
            socket.SendFrame(json);
        }

        public static T ReceiveT<T>(this SubscriberSocket socket)
        {
            var json = socket.ReceiveFrameString();
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

    }

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
                subSocket.Subscribe("");
                Console.WriteLine("Subscriber socket connecting...");
                
                var myLogger = new MyLogger();
                //TODO:: pass yaml config 
                myLogger.Setup();
                poller.RunAsync();

                subSocket.ReceiveReady += (_, a) =>
                {
                    string message = a.Socket.ReceiveFrameString();

                    var msg = JsonConvert.DeserializeObject<CommandX>(message);

                    //Console.WriteLine($"{msg.Id},{msg.Name},{msg.Url}");

                    if (msg.Id == 1)
                    {
                        //start registe scheduler;
                        //start log;
                        //FluentScheduler.JobManager.AddJob(() => Console.WriteLine($"{msg.Name}"), (s) => s.ToRunNow().AndEvery(4).Seconds());
                        FluentScheduler.JobManager.AddJob(
                                                        () => { 
                                                            Console.WriteLine($"{msg.Name}");
                                                            var parser = new MyParser();
                                                            parser.DoTest();



                                                        }, (s) => s.ToRunNow());
                    }

                };
                while (true)
                {
                    Console.WriteLine("Wait for Command.");
                    Thread.Sleep(2 * 1000);
                }

            }

        }
    }
}