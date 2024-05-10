using Azure.Messaging.ServiceBus;
using AzureServiceBus.Common;
using Newtonsoft.Json;

namespace AzureServiceBus.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contract1 received = ReceiveMessage().GetAwaiter().GetResult();
            Console.WriteLine($"Received contract for name: {received.Name}");
        }

        static async Task<Contract1> ReceiveMessage()
        {
            string connectionString = "Endpoint=sb://tryouts1-ksaketh2.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=sjZXi0B+caKtGRitDFN9OF1bbvxKJ6808+ASbB6rDyY=";
            string queueName = "tryouts1";

            Console.WriteLine($"Receiving message from Service bus queue {queueName}");

            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // the received message is a different type as it contains some service set properties
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            // get the message body as a string
            string body = receivedMessage.Body.ToString();
            Contract1 received = JsonConvert.DeserializeObject<Contract1>(body);
            
            // complete/abandon/dead letter the message, thereby deleting it from the service
            await receiver.CompleteMessageAsync(receivedMessage);

            return received;
        }
    }
}