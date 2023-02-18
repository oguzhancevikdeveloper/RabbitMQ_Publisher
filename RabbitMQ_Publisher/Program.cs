
using RabbitMQ.Client;
using System.Text;

// Bağlantı Oluşturma.
ConnectionFactory factory = new();
factory.Uri = new("amqps://ajgenuck:uxjM3ZNS4MoDEmnbXOyPtlfixMZZBA4A@shark.rmq.cloudamqp.com/ajgenuck");

// Bağlantıyı aktifleştirme ve kanal açmak.
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue oluşturma.
channel.QueueDeclare(queue:"example-queue",exclusive:false);

//Queue mesaj gönderme
// RabbitMQ kuyruğa ataçağı mesajları byte türünde kabul eder. Bizimde mesajları byte'a dönüştrümemiz gerek.
byte[] message = Encoding.UTF8.GetBytes("Selamunaleyküm");
channel.BasicPublish(exchange:"",routingKey: "example-queue",body:message);

Console.ReadLine();
