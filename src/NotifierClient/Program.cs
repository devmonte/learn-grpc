using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Notifier;

namespace NotifierClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var grpcChannel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Notifier.Notifier.NotifierClient(grpcChannel);
            var reply = await client.NotifyAsync(new NotificationRequest
                {Id = 666, Content = "Hello from small client!"});

            Console.WriteLine($"Reply: {reply.Result}");
            Console.ReadKey();
        }
    }
}
