using Balls.Models;

namespace Balls;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        Game game = new Game(this.ClientRectangle);
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 50;
        timer.Tick += (s, ev) =>
        {
            Invalidate();
        };
        timer.Start();

        this.Paint += (s, ev) => {
            game.move();
            game.draw(ev.Graphics);
        };
    }


}