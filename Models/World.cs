using System.Collections.Generic;
using System.Drawing;

namespace Balls.Models;

public class World : Shape
{
    public World(Rectangle rectangle, Point dir, World world, Brush brush) 
        : base(rectangle, dir, world, brush, ShapeType.Rectangle)
    {
    }

    List<Shape> shapes = new List<Shape>();

    public void addShape(Shape shape)
    {
        shapes.Add(shape);
    }

    public override void Move()
    {
        base.Move();
        foreach (var shape in shapes)
        {
            shape.Move();
        }
    }

    public override void draw(Graphics g)
    {
        base.draw(g);
        foreach (var shape in shapes)
        {
            shape.draw(g);
        }
    }

}
