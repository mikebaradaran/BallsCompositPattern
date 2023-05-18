using System.Drawing;

namespace Balls.Models;

public class Game
{
    private World w1;
    public Game(Rectangle rectangle)
    {
        World w2, w3;
        rectangle.Inflate(-30, -30);
        w1 = new World(rectangle, new Point(0, 0), null, Brushes.LightYellow);
        w2 = new World(new Rectangle(10,10,250,250), new Point(3, 3), w1, Brushes.LightGreen);
        w3 = new World(new Rectangle(5, 5, 100, 100), new Point(5, 5), w2, Brushes.LightBlue);

        w1.addShape(new Shape(new Rectangle(1, 1, 40, 40), new Point(8,12), w1, Brushes.Red, ShapeType.Ball));
        w1.addShape(w2);

        w2.addShape(new Shape(new Rectangle(5, 5, 20, 20), new Point(6, 5), w2, Brushes.Blue, ShapeType.Ball));
        w2.addShape(w3);

        w3.addShape(new Shape(new Rectangle(5, 5, 20, 20), new Point(10, 6), w3, Brushes.Black, ShapeType.Ball));
    }

    public void move()
    {
        w1.Move();
    }
    public void draw(Graphics g)
    {
        w1.draw(g);
    }
}
