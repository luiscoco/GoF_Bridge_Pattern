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


// Implementation: IRenderer
public interface IRenderer
{
    void RenderCircle(double radius);
    void RenderSquare(double side);
}


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

