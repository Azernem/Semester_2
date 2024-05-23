namespace CatchTheButton;

/// <summary>
/// Catch a button.
/// </summary>
public partial class GameFrom : Form
{
    private Random random = new Random();

    /// <summary>
    /// Form constructor
    /// </summary>

    private void MouseMoveUnderButton(object sender, MouseEventArgs e)
    {
        var PositionButton = new Point(random.Next(Width - button.Width), random.Next(Height - button.Height));

        while (Math.Abs(Control.MousePosition.X - PositionButton.X) < 150 || Math.Abs(Control.MousePosition.Y - PositionButton.Y) < 50)
        {
            PositionButton = new Point(random.Next(Width - button.Width - 50),
            random.Next(Height - button.Height - 50));
        }
        button.Location = PositionButton;
    }

    private void ClickButton(object sender, EventArgs e)
    {
        Close();
    }
    /// <summary>
    /// initialise.
    /// </summary>
    public GameFrom()
    {
        InitializeComponent();
    }
}