using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitSub
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

            await channel.QueueDeclareAsync(
                queue: "helloqu",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            string routingKey = "hello";
            await channel.QueueBindAsync(
                queue: "helloqu",
                exchange: "helloex",
                routingKey: routingKey);

            Console.WriteLine("waiting for message..");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                await channel.BasicAckAsync(
                    deliveryTag: ea.DeliveryTag,
                    multiple: false);
                Console.WriteLine($"message received: {message}");
            };

            await channel.BasicConsumeAsync(
                queue: "helloqu",
                autoAck: false,
                consumer: consumer
            );

            Console.WriteLine("press any key to quit.");
            Console.ReadKey();
        }

        public static async Task Main(string[] args)
        {
            await RabbitMq();
        }
    }
}