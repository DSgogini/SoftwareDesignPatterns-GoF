using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is Observer Design Pattern.");

            SubjectEventManager subjectEventManager = new SubjectEventManager();

            subjectEventManager.Attach(new ConcreateOberverA());
            subjectEventManager.Attach(new ConcreateOberverB());


            subjectEventManager.SomeBusinessLogicToNotify();
        }
    }
}

public class ConcreateOberverA : IObserver
{
    public void Recieve(ISubjectEventManager subject)
    {
        Console.WriteLine($"{GetType().Name} :: Notification Received.");
    }
}

public class ConcreateOberverB : IObserver
{
    public void Recieve(ISubjectEventManager subject)
    {
        Console.WriteLine($"{GetType().Name} :: Notification Received.");
    }
}

/// <summary>
/// Oberver design pattern => also known as Listener, Event-Subscriber
/// Reference :: https://refactoring.guru/design-patterns/observer
/// </summary>
public class SubjectEventManager : ISubjectEventManager
{
    private Dictionary<string, IObserver> _observers = new Dictionary<string, IObserver>();
    public void Attach(IObserver observer)
    {
        string nameKey = observer.GetType().Name;
        if (!_observers.ContainsKey(nameKey))
        {
            _observers.Add(nameKey, observer);
            Console.WriteLine($"Observer registered with name {nameKey}");
        }
    }

    public void Detach(IObserver observer)
    {
        string nameKey = observer.GetType().Name;
        if (_observers.ContainsKey(nameKey))
            _observers.Remove(nameKey);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            Console.WriteLine($"Sending notification to {observer.Key}");
            observer.Value.Recieve(this);
        }
    }

    public void SomeBusinessLogicToNotify()
    {
        Thread.Sleep(50000);
        this.Notify();
    }
}

public interface ISubjectEventManager
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public interface IObserver
{
    void Recieve(ISubjectEventManager subject);
}