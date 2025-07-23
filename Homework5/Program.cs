internal class Program
{
    private static void Main()
    {
        var laptopClient = new LaptopClient();
        var phoneClient = new PhoneClient();
        var webClient = new WebClientApp();

        var mailServer = new MailServer();

        Console.WriteLine("Subscribe clients...");
        mailServer.Subscribe(laptopClient);
        mailServer.Subscribe(phoneClient);
        mailServer.Subscribe(webClient);

        Console.WriteLine("\nNew mail #1:");
        mailServer.Publish();

        Console.WriteLine("\nUnSubscribe Web-клиент...");
        mailServer.Unsubscribe(webClient);

        Console.WriteLine("\nNew mail #2:");
        mailServer.Publish();
    }
}


public interface IPublisher
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
    void Publish();
}

public interface ISubscriber
{
    void Update();
}

public class MailServer : IPublisher
{
    private List<ISubscriber> _subscribers = new();

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Publish()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update();
        }
    }
}

public class LaptopClient : ISubscriber
{
    public void Update()
    {
        Console.WriteLine("Notification on Laptop");
    }
}

public class PhoneClient : ISubscriber
{
    public void Update()
    {
        Console.WriteLine("Notification on Phone");
    }
}

public class WebClientApp : ISubscriber
{
    public void Update()
    {
        Console.WriteLine("Notification on Web");
    }
}
