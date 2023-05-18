using System.Drawing;

namespace Balls.Models;


public enum Hit
{
    None, Top, Right, Bottom, Left
}
public class Utils
{
    public static Hit chackHitPosition(ref Rectangle r, Rectangle w)
    {
        if (r.Left < w.Left)
        {
            r.X = w.Left;
            return Hit.Left;
        }
        if (r.Top < w.Top)
        {
            r.Y = w.Top;
            return Hit.Top;
        }
        if (r.Right > w.Right)
        {
            r.X = w.Right - r.Width;
            return Hit.Right;
        }
        if (r.Bottom > w.Bottom)
        {
            r.Y = w.Bottom - r.Height;
            return Hit.Bottom;
        }
        return Hit.None;

    }
}
