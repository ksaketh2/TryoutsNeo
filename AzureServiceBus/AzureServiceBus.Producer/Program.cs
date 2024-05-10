using Azure.Messaging.ServiceBus;
using AzureServiceBus.Common;
using Newtonsoft.Json;

namespace AzureServiceBus.Producer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendMessage(new Contract1 { Name = "saketh" }).GetAwaiter().GetResult();
        }

        static async Task SendMessage(Contract1 contract)
        {
            string connectionString = "Endpoint=sb://tryouts1-ksaketh2.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=sjZXi0B+caKtGRitDFN9OF1bbvxKJ6808+ASbB6rDyY=";
            string queueName = "tryouts1";

            Console.WriteLine($"Sending message to Service bus queue {queueName}");

            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(JsonConvert.SerializeObject(contract));

            // send the message
            await sender.SendMessageAsync(message);
        }
    }
}