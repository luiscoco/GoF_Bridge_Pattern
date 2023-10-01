# GoF_Csharp-Bridge_Pattern

https://www.dotnettricks.com/learn/designpatterns/bridge-design-pattern-dotnet

https://refactoring.guru/design-patterns/examples

## What is Bridge Pattern
Bridge is a structural design pattern that lets you split a large class or a set of closely related classes into two separate hierarchies—abstraction and implementation—which can be developed independently of each other.

![image](https://github.com/luiscoco/GoF_Csharp-7.Bridge_Pattern/assets/32194879/412a9a8c-2c6e-452f-8b99-3ce2a7f598f3)

This example illustrates how the Bridge pattern can help divide the monolithic code of an app that manages devices and their remote controls. The Device classes act as the implementation, whereas the Remotes act as the abstraction.

![image](https://github.com/luiscoco/GoF_Csharp-7.Bridge_Pattern/assets/32194879/135d7115-3966-4998-aad2-81f537fdd38e)


The bridge pattern is used to separate abstraction from its implementation so that both can be modified independently.

![image](https://github.com/luiscoco/GoF_Csharp-7.Bridge_Pattern/assets/32194879/131c7634-2764-425c-b770-3b60956eaca1)

This pattern involves an interface which acts as a bridge between the abstraction class and implementer classes and also makes the functionality of implementer class independent from the abstraction class. Both types of classes can be modified without affecting to each other.

![image](https://github.com/luiscoco/GoF_Csharp-7.Bridge_Pattern/assets/32194879/976f23a8-33f1-4f4e-b845-752eeb18cbf1)

## Bridge Pattern - UML Diagram & Implementation
The UML class diagram for the implementation of the bridge design pattern is given below:

![image](https://github.com/luiscoco/GoF_Csharp-7.Bridge_Pattern/assets/32194879/ff899ca9-96c8-428e-8ea5-56a9a0dc16de)

## Bridge Pattern - Example

![image](https://github.com/luiscoco/GoF_Csharp-7.Bridge_Pattern/assets/32194879/6fea890d-7482-453f-bb6e-864b57c88c0e)

## C# - Sample Code

```csharp
/// <summary>
/// Bridge Design Pattern Demo
/// </summary>
class Program
{
 static void Main(string[] args)
 {
 IMessageSender email = new EmailSender();
 IMessageSender queue = new MSMQSender();
 IMessageSender web = new WebServiceSender();

 Message message = new SystemMessage();
 message.Subject = "Test Message";
 message.Body = "Hi, This is a Test Message";
 
 message.MessageSender = email;
 message.Send();

 message.MessageSender = queue;
 message.Send();

 message.MessageSender = web;
 message.Send();

 UserMessage usermsg = new UserMessage();
 usermsg.Subject = "Test Message";
 usermsg.Body = "Hi, This is a Test Message";
 usermsg.UserComments = "I hope you are well";

 usermsg.MessageSender = email;
 usermsg.Send();

 Console.ReadKey();
 }
}
```

```csharp
/// <summary>
/// The 'Abstraction' class
/// </summary>
public abstract class Message
{
 public IMessageSender MessageSender { get; set; }
 public string Subject { get; set; }
 public string Body { get; set; }
 public abstract void Send();
}

/// <summary>
/// The 'RefinedAbstraction' class
/// </summary>
public class SystemMessage : Message
{
 public override void Send()
 {
 MessageSender.SendMessage(Subject, Body);
 }
}

/// <summary>
/// The 'RefinedAbstraction' class
/// </summary>
public class UserMessage : Message
{
 public string UserComments { get; set; }

 public override void Send()
 {
 string fullBody = string.Format("{0}\nUser Comments: {1}", Body, UserComments);
 MessageSender.SendMessage(Subject, fullBody);
 }
}

/// <summary>
/// The 'Bridge/Implementor' interface
/// </summary>
public interface IMessageSender
{
 void SendMessage(string subject, string body);
}

/// <summary>
/// The 'ConcreteImplementor' class
/// </summary>
public class EmailSender : IMessageSender
{
 public void SendMessage(string subject, string body)
 {
 Console.WriteLine("Email\n{0}\n{1}\n", subject, body);
 }
}

/// <summary>
/// The 'ConcreteImplementor' class
/// </summary>
public class MSMQSender : IMessageSender
{
 public void SendMessage(string subject, string body)
 {
 Console.WriteLine("MSMQ\n{0}\n{1}\n", subject, body);
 }
}

/// <summary>
/// The 'ConcreteImplementor' class
/// </summary>
public class WebServiceSender : IMessageSender
{
 public void SendMessage(string subject, string body)
 {
 Console.WriteLine("Web Service\n{0}\n{1}\n", subject, body);
 }
}
```

## Who is what?
The classes, interfaces, and objects in the above class diagram can be identified as follows:

Message - Abstraction Class.

SystemMessage & UserMessage- Redefined Abstraction Classes.

IMessageSender- Bridge Interface.

EmailSender, WebServiceSender & MSMQ Sender- ConcreteImplementation class which implements the IMessageSender interface.

## When to use it?
Abstractions and implementations should be modified independently.

Changes in the implementation of an abstraction should have no impact on clients.

The Bridge pattern is used when a new version of a software or system is brought out, but the older version of the software still running for its existing client. There is no need to change the client code, but the client needs to choose which version he wants to use.

### Note
Bridge pattern has nearly the same structure as the Adapter Pattern. But it is used when designing new systems instead of the Adapter pattern which is used with already existing systems.

## Bridge pattern summary 

Decouples an abstraction from its implementation, allowing them to vary independently.

The Bridge Pattern is a structural design pattern in software engineering that decouples an abstraction (e.g., an interface or abstract class) from its implementation, allowing them to vary independently. This pattern is useful when you have multiple variations of an abstraction and multiple variations of its implementation. By using the Bridge Pattern, you can avoid creating a large number of class combinations, which can lead to a more flexible and maintainable codebase.

Let's take an example to understand the Bridge Pattern in C#. Suppose we want to create a shape-drawing application with different shapes (e.g., circle, square) and different rendering methods (e.g., raster, vector). Instead of creating separate classes for each combination of shape and rendering method, we can use the Bridge Pattern to decouple the abstraction (shape) from its implementation (rendering).

First, we define the shape abstraction:

// Abstraction: Shape
public abstract class Shape
{
    protected IRenderer renderer;

    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
}

Next, we define the implementation interface:

// Implementation: IRenderer
public interface IRenderer
{
    void RenderCircle(double radius);
    void RenderSquare(double side);
}

Now, we can create concrete implementations of the rendering methods:

// Concrete Implementation: RasterRenderer
public class RasterRenderer : IRenderer
{
    public void RenderCircle(double radius)
    {
        Console.WriteLine($"Drawing a circle of radius {radius} using raster rendering.");
    }

    public void RenderSquare(double side)
    {
        Console.WriteLine($"Drawing a square of side {side} using raster rendering.");
    }
}

// Concrete Implementation: VectorRenderer
public class VectorRenderer : IRenderer
{
    public void RenderCircle(double radius)
    {
        Console.WriteLine($"Drawing a circle of radius {radius} using vector rendering.");
    }

    public void RenderSquare(double side)
    {
        Console.WriteLine($"Drawing a square of side {side} using vector rendering.");
    }
}

With the abstraction and implementation in place, we can now create concrete shapes that use different rendering methods:

// Concrete Shape: Circle
public class Circle : Shape
{
    private double radius;

    public Circle(double radius, IRenderer renderer) : base(renderer)
    {
        this.radius = radius;
    }

    public override void Draw()
    {
        renderer.RenderCircle(radius);
    }
}

// Concrete Shape: Square
public class Square : Shape
{
    private double side;

    public Square(double side, IRenderer renderer) : base(renderer)
    {
        this.side = side;
    }

    public override void Draw()
    {
        renderer.RenderSquare(side);
    }
}

Finally, let's see how we can use the Bridge Pattern in the client code:

class Program
{
    static void Main(string[] args)
    {
        // Using raster rendering for the circle
        Shape circle = new Circle(5.0, new RasterRenderer());
        circle.Draw();

        // Using vector rendering for the square
        Shape square = new Square(4.0, new VectorRenderer());
        square.Draw();
    }
}
Output:

arduino
Copy code
Drawing a circle of radius 5 using raster rendering.
Drawing a square of side 4 using vector rendering.
As you can see, the Bridge Pattern allows us to create different shapes with different rendering methods, and the two can vary independently. This promotes flexibility and maintainability in our codebase.

## How to setup Github actions

![Csharp Github actions](https://github.com/luiscoco/GoF_Csharp-7.Bridge_Pattern/assets/32194879/9579798e-f7af-4b89-91c9-3cd9b4bc8312)














