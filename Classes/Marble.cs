using ChineseCheckers.Enums;
using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    public class Marble
    {
        public int Id { get; set; }
        public Point Pointer { get; set; }
        public int Angle_theta { get; set; }
        public PlayerColor MarbleColor { get; set; }
        
        /// <param name="id">Id of the marble</param>
        /// <param name="pointer">Point value representing X and Y coordinates on the board</param>
        /// <param name="marblecolor">The color which the marble will have</param>
        /// <param name="angle_theta">Sets the angle of the marble head</param>
        public Marble(int id, Point pointer, PlayerColor marblecolor, int angle_theta)
        {
            Id = id;
            Pointer = pointer;
            MarbleColor = marblecolor;
            Angle_theta = angle_theta;
        }
    }
}
