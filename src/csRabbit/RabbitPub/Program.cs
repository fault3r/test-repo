
using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitPub
{
    class Program
    {
        public static async Task RabbitMq()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(
                exchange: "helloex",
                type: ExchangeType.Direct);

            string routingKey = "hello";

            while (true)
            {
                Console.WriteLine("enter message to send (or 'exit' to quit): ");
                string? message = Console.ReadLine();

                if (string.IsNullOrEmpty(message) || message == "exit")
                    break;

                var body = Encoding.UTF8.GetBytes(message);
                await channel.BasicPublishAsync(
                    exchange: "helloex",
                    routingKey: routingKey,
                    body: body);

                Console.WriteLine("your message has been sent.\n");
            }
        }

        public static async Task Main(string[] args)
        {
            await RabbitMq();
        }
    }
}