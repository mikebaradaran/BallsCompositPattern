using System.Drawing;

namespace Balls.Models;

public enum ShapeType
{
    Rectangle, Ball
}

public class Shape
{
    public World world;
    public Rectangle rectangle;
    public Point dir;
    public Brush brush;
    public ShapeType shapeType;

    public Shape(Rectangle rectangle, Point dir, World world, Brush brush, ShapeType shapeType)
    {
        if(world != null)
            rectangle.Offset(world.rectangle.Left, world.rectangle.Top);
        this.rectangle = rectangle;
        this.dir = dir;
        this.world = world;
        this.brush = brush;
        this.shapeType = shapeType;
    }
    public virtual void draw(Graphics g)
    {
        if (shapeType == ShapeType.Rectangle)
            g.FillRectangle(brush, rectangle);
        else
            g.FillEllipse(brush, rectangle);
    }

    public virtual void Move__OLD()
    {
        if (world == null)  // this is the first top world
            return;

        rectangle.Offset(dir);
        if (rectangle.Left < world.rectangle.Left)
        {
            dir.X = -dir.X;
            rectangle.X = world.rectangle.Left;
        }
        if (rectangle.Top < world.rectangle.Top)
        {
            dir.Y = -dir.Y;
            rectangle.Y = world.rectangle.Top;
        }
        if (rectangle.Right > world.rectangle.Right)
        {
            dir.X = -dir.X;
            rectangle.X = world.rectangle.Right - rectangle.Width;
        }
        if (rectangle.Bottom > world.rectangle.Bottom)
        {
            dir.Y = -dir.Y;
            rectangle.Y = world.rectangle.Bottom - rectangle.Height;
        }
    }

    public virtual void Move()
    {
        if (world == null)  // this is the first top world
            return;

        rectangle.Offset(dir);
        Hit hit = Utils.chackHitPosition(ref rectangle, world.rectangle);

        if (hit == Hit.Left || hit == Hit.Right)
            dir.X = -dir.X;

        if (hit == Hit.Top || hit == Hit.Bottom)
            dir.Y = -dir.Y;
    }
}

