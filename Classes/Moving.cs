using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace ChineseCheckers.Classes
{
    public class Moving
    {
        public int moveID { get; set; }

        public double current_X { get; set; }
        public double current_Y { get; set; }

        public double target_X { get; set; }
        public double target_Y { get; set; }

        public double velocity_x { get; set; }
        public double velocity_y { get; set; }

        public double distance_x { get; set; }
        public double distance_y { get; set; }

        public int divider { get; set; }

        public bool move { get; set; }


    public Moving(int Divider, bool Move) 
        {
            this.divider = Divider;
            this.move = Move;
        }

        public void test(List<Marble> test1) 
        {
            foreach (var marble in test1)
            {
                if (marble.Id == moveID)
                {
                    Point tester = new Point(current_X, current_Y);

                    current_X += velocity_x;
                    current_Y += velocity_y;

                    distance_x = target_X - current_X;
                    distance_y = target_Y - current_Y;

                    velocity_x = distance_x / divider;
                    velocity_y = distance_y / divider;

                    if (Math.Abs(distance_x) < 0.02)
                    {
                        velocity_x = 0;
                    }
                    else
                    {
                        current_X += velocity_x;
                    }

                    if (Math.Abs(distance_y) < 0.02)
                    {
                        velocity_y = 0;
                    }
                    else
                    {
                        current_Y += velocity_y;
                    }

                    marble.Pointer = tester;

                    if (Math.Abs(distance_y) < 0.05 && Math.Abs(distance_x) < 0.05)
                    {
                        move = false;
                    }
                }
            }


        }
    }
}
