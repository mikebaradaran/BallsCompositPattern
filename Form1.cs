using Balls.Models;

namespace Balls;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    Game game;
    private void Form1_Load(object sender, EventArgs e)
    {
        game = new Game(this.ClientRectangle);
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 50;
        timer.Tick += (s, ev) =>
        {
            Invalidate();
        };
        timer.Start();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        game.move();
        game.draw(e.Graphics);
    }
}