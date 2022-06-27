# ASP-Dotnet-Core-with-Azure-Service-Bus-Integration

Introduction to Azure Bus Integration in ASP .Net Core. Shows an approach to work with a microservices based architecture using .Net Core, and Azure Service  applying Domain Driven Design (DDD) and Comand and Query Responsibility Segregation (CQRS) and other patterns.

## Architechture

![image](https://user-images.githubusercontent.com/58937669/176027340-80ac13d1-40c2-4362-8638-bfd40919a050.png)

## Sender and Reciver

Generic util function for message sender and reciver to event bus

### Sender

```
 public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName)
        {
            var queueClient = new QueueClient(_config.GetConnectionString("AzureServiceBus"), queueName);
            string messageBody = JsonSerializer.Serialize(serviceBusMessage);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await queueClient.SendAsync(message);
        }
```

### Reciver

```
        static async Task ReviveMessage(string[] args)
        {
            queueClient = new QueueClient(connectionString, queueName);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false // Does not Remove after 30 sec
            };

            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);

            Console.ReadLine();

            await queueClient.CloseAsync();
        }


```
