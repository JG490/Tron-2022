///Joey Gerber
///ICS4u
///Tony Theodoropoulos
//


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tron
{
    public partial class GameScreen : UserControl
    {
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool spaceDown = false;
        bool escDown = false;
        int screenSize = 700;
        int tick = 0;

        Player p1 = new Player(20, 0, "down");
        Player p2 = new Player(680, 700, "up");
        List<Player> p1Trail = new List<Player>();
        List<Player> p2Trail = new List<Player>();
        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }
        public void InitializeGame()
        {
            resetPosition();
            Form1.p1Score = 0;
            Form1.p2Score = 0;
            displayLabel.Text = "Press Space to Continue, esc to exit";
        }
        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.Escape:
                    escDown = false;
                    break;

            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.Escape:
                    escDown = true;
                    break;

            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            displayLabel.Visible = false;
            //Changes direction Tron should be moving in.
            NewTrail(p1.x, p1.y, p2.x, p2.y); 
            //for player 1
            if (upArrowDown == true)
            {
                p2.direction = "up";
            }
            if (downArrowDown == true)
            {
                p2.direction = "down";
            }
            if (leftArrowDown == true)
            {
                p2.direction = "left";
            }
            if (rightArrowDown == true)
            {
                p2.direction = "right";
            }

            //for player 2
            if (wDown == true)
            {
                p1.direction = "up";
            }
            if (sDown == true)
            {
                p1.direction = "down";
            }
            if (aDown == true)
            {
                p1.direction = "left";
            }
            if (dDown == true)
            {
                p1.direction = "right";
            }
            //sends direction to player class
            //for player 1
            if (p1.direction == "up")
            {
                p1.Move("up");
            }
            if (p1.direction == "down")
            {
                p1.Move("down");
            }
            if (p1.direction == "left")
            {
                p1.Move("left");
            }
            if (p1.direction == "right")
            {
                p1.Move("right");
            }

            //for player 2
            if (p2.direction == "up")
            {
                p2.Move("up");
            }
            if (p2.direction == "down")
            {
                p2.Move("down");
            }
            if (p2.direction == "left")
            {
                p2.Move("left");
            }
            if (p2.direction == "right")
            {
                p2.Move("right");
            }
            //collisions with border

            //collisions with trail
            if (p1Trail.Count > 2)
            {
                try
                {
                    for (int i = 0; i < p2Trail.Count() - 2; i++)
                    {
                        if (p2Trail[i].Collision(p2))
                        {
                            Pointgain(1);
                            waitTimer.Enabled = true;
                            gameTimer.Enabled = false;
                        }
                    }
                }
                catch
                {
                    Pointgain(1);
                    waitTimer.Enabled = true;
                    gameTimer.Enabled = false;
                }
            
            try { 
                for (int i = 0; i < p1Trail.Count() - 2; i++)
                {
                    if (p1Trail[i].Collision(p1))
                    {
                        Pointgain(2);
                        waitTimer.Enabled = true;
                        gameTimer.Enabled = false;
                    }
                }
                }
                catch
                {
                    Pointgain(2);
                    waitTimer.Enabled = true;
                    gameTimer.Enabled = false;
                }
                try {
                    foreach (Player a in p1Trail)
                    {
                        if (a.Collision(p2))
                        {
                            Pointgain(1);
                            waitTimer.Enabled = true;
                            gameTimer.Enabled = false;
                        }
                    }
                }
                catch
                {
                    Pointgain(1);
                    waitTimer.Enabled = true;
                    gameTimer.Enabled = false;
                } 
                try { 
                foreach (Player b in p2Trail)
                {
                    if (b.Collision(p1))
                    {
                        Pointgain(2);
                        waitTimer.Enabled = true;
                        gameTimer.Enabled = false;
                    }
                }
                }
                catch
                {
                    Pointgain(2);
                    waitTimer.Enabled = true;
                    gameTimer.Enabled = false;
                }
                if (p1.Collision(p2))
                {
                    Pointgain(0);
                    waitTimer.Enabled = true;
                    gameTimer.Enabled = false;
                }
            }
            if (spaceDown == true)
            {
                resetPosition();
                p1Trail.Clear();
                p2Trail.Clear();
            }
            if (escDown == true)
            {
                gameTimer.Enabled = false;
                Form1.ChangeScreen(this, new MenuScreen());
            }
            if (Form1.p1Score == 3)
            {
                displayLabel.Text = "Blue Wins";
            }
            if (Form1.p2Score == 3)
            {
                displayLabel.Text = "Orange Wins";
            }
            Refresh();
        }
        public void NewTrail(int p1x, int p1y, int p2x, int p2y)
        {
            Player a = new Player(p1x, p1y, "null");
            Player b = new Player(p2x, p2y, "null");
            p1Trail.Add(a);
            p2Trail.Add(b);
        }
        public void Pointgain(int player)
        {
            if (player == 0)
            {
                Thread.Sleep(500);
                resetPosition();
                gameTimer.Enabled = true;
            }
            if (player == 1)
            { 
                Form1.p1Score++;
                Thread.Sleep(500);
                resetPosition();
                gameTimer.Enabled = true;
            }
            if (player == 2)
            {
                Form1.p2Score++;
                Thread.Sleep(500);
                resetPosition();
                gameTimer.Enabled = true;
            }
        }
        private void GameScreen_Paint_1(object sender, PaintEventArgs e)
        {
            player1Label.Text = $"{Form1.p1Score}";
            player2Label.Text = $"{Form1.p2Score}";
            e.Graphics.FillRectangle(Brushes.DodgerBlue, p1.x, p1.y, p1.width, p1.height);
            e.Graphics.FillRectangle(Brushes.DarkGoldenrod, p2.x, p2.y, p2.width, p2.height);
            foreach (Player a in p1Trail)
            {
                e.Graphics.FillRectangle(Brushes.DodgerBlue, a.x, a.y, p1.width, p1.height);
            }
            foreach (Player b in p2Trail)
            {
                e.Graphics.FillRectangle(Brushes.DarkGoldenrod, b.x, b.y, p2.width, p2.height);
            }
        }

        private void waitTimer_Tick(object sender, EventArgs e)
        {
            displayLabel.Visible = true;
            displayLabel.Enabled = true;
            if (escDown == true)
            {
                waitTimer.Enabled = false;
                Form1.ChangeScreen(this, new MenuScreen());
            }
            if (spaceDown == true)
            {
                p1Trail.Clear();
                p2Trail.Clear();
                resetPosition();
                gameTimer.Enabled = true;
                waitTimer.Enabled = false;


            }
        }
        public void resetPosition()
        {
            p1.x = 20;
            p1.y = 0;
            p2.x = 680;
            p2.y = 700;
            p1.direction = "down";
            p2.direction = "up";

        }
    }
}
