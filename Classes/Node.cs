using ChineseCheckers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Windows.Foundation;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    public class Node
    {
        public PlayerColor? CampColorId { get; set; }
        public Point Pointer { get; set; }
        public int? MarbleID { get; set; }

        public Node(int x, int y, PlayerColor? campColorID = null, int? pieceId = null)
        {
            this.Pointer = new Point(x, y);
            this.CampColorId = campColorID;
            this.MarbleID = pieceId;
        }

        public bool IsAvalible()
        {
            return MarbleID is null;
        }
    }
}
