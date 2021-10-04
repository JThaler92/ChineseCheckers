using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace ChineseCheckers.Classes
{
    public static class Moving
    {
        public static int moveID { get; set; }
        public static double current_X { get; set; }
        public static double current_Y { get; set; }

        public static double target_X { get; set; }
        public static double target_Y { get; set; }

        public static int target_theta { get; set; }

        public static double velocity_x { get; set; }
        public static double velocity_y { get; set; }

        public static double distance_x { get; set; }
        public static double distance_y { get; set; }

        public static int divider = 25; //{ get; set; }

        public static bool move = false;
        //public bool move { get; set; }

        /*
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Divider">Sets velocity (Higher value = slower movment)</param>
        public Moving(int Divider) 
        {
            this.divider = Divider;
        }
        */
        /// <summary>
        /// Select a marble to move.
        /// </summary>
        /// <param name="currentlySelected">Instance of Marble class</param>
        public static void SelectMarble(Marble currentlySelected) 
        {
            current_X = currentlySelected.Pointer.X;
            current_Y = currentlySelected.Pointer.Y;        
            moveID = currentlySelected.Id;
           
            
        }

        /// <summary>
        /// Select target location to move to, and add a rotation angle.
        /// </summary>
        /// <param name="N"></param>
        public static void SelectLocation(Node N) 
        {
            move = true;
            target_X = N.Pointer.X;
            target_Y = N.Pointer.Y;

            current_X = Math.Round(current_X);
            current_Y = Math.Round(current_Y);

            if (target_X > current_X && target_Y == current_Y)
            {
                target_theta = 0;
            }
            else if (target_X > current_X && target_Y < current_Y)
            {
                target_theta = -60;
            }
            else if (target_X == current_X && target_Y < current_Y)
            {
                target_theta = -120;
            }
            else if (target_X < current_X && target_Y == current_Y)
            {
                target_theta = -180;
            }
            else if (target_X < current_X && target_Y > current_Y)
            {
                target_theta = -240;
            }
            else if (target_X == current_X && target_Y > current_Y)
            {
                target_theta = -300;
            }
        }

        /// <summary>
        /// Moves a marble from current location to target location visualy.
        /// </summary>
        /// <param name="MarbleList">List of all marbles on the board</param>
        public static void GraphicMovment(List<Marble> MarbleList) 
        {
            foreach (var marble in MarbleList)
            {
                if (marble.Id == moveID)
                {
                    Point marblePlaceholder = new Point(current_X, current_Y);

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

                    marble.Pointer = marblePlaceholder;
                    marble.Angle_theta = target_theta;

                    if (Math.Abs(distance_y) < 0.03 && Math.Abs(distance_x) < 0.03)
                    {
                        marblePlaceholder.X = Math.Round(marble.Pointer.X); // If movment bugs, this can be error.
                        marblePlaceholder.Y = Math.Round(marble.Pointer.Y);

                        marble.Pointer = marblePlaceholder;

                        move = false;
                    }
                }
            }
        }
    }
}
