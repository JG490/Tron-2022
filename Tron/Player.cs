using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Tron
{
    internal class Player
    {
        public int width = 10;
        public int height = 10;
        public int speed = 6;
        public int x, y;
        public string direction;

        public Player(int _x, int _y, string _direction)
        {
            x = _x;
            y = _y;
            direction = _direction;
        }

        public void Move(string direction)
        {
            if (direction == "null")
            {
                speed = 0;
            }
            if (direction == "up")
            {
                y -= speed;
                if (y < 0)
                {
                    speed = -speed;
                }
            }
            if (direction == "down")
            {
                y += speed;
                if (y > 700)
                {
                    speed -= speed;
                }
            }
            if (direction == "right")
            {
                x += speed;
                if (x > 700)
                {
                    speed -= speed;
                }
            }
            if (direction == "left")
            {
                x -= speed;
                if (x < 0)
                {
                    speed -= speed;
                }
            }
        }
        public bool Collision(Player p)
        {
            Rectangle p1 = new Rectangle(p.x, p.y, p.width, p.height);
            Rectangle trailRec = new Rectangle (x, y, width, height);
            Rectangle topBorder = new Rectangle(0, 0, 700, -2);
            Rectangle bottomBorder = new Rectangle(0, 700, 700, 2);
            Rectangle rightBorder = new Rectangle(0, 0, -2, 700);
            Rectangle leftBorder = new Rectangle(700, 0, 2, 700);
            if (trailRec.IntersectsWith(p1))
            {

                return true;
            }
            return false;
        }

    }
}
