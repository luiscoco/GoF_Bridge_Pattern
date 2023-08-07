# GoF_Csharp-Bridge_Pattern

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

















