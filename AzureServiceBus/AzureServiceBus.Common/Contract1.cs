namespace AzureServiceBus.Common
{
    public class Contract1
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
    }
}