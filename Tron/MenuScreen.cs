using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tron
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, 60, 20, 80, 10);
            e.Graphics.FillRectangle(Brushes.Blue, 100, 20, 10, 80);
            e.Graphics.FillRectangle(Brushes.Blue, 150, 20, 80, 10);
            e.Graphics.FillRectangle(Brushes.Blue, 150, 20, 10, 80);
            e.Graphics.FillRectangle(Brushes.Blue, 230, 20, 10, 80);
            e.Graphics.FillRectangle(Brushes.Blue, 150, 60, 80, 10);
            e.Graphics.FillRectangle(Brushes.Blue, 240, 20, 80, 10);
            e.Graphics.FillRectangle(Brushes.Blue, 240, 20, 10, 80);
            e.Graphics.FillRectangle(Brushes.Blue, 320, 20, 10, 80);
            e.Graphics.FillRectangle(Brushes.Blue, 240, 80, 80, 10);




        }
    }
}
