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

        /// <param name="x">the X coordinate of the node</param>
        /// <param name="y">the Y coordinate of the nod</param>
        /// <param name="campColorID">the color of the node</param>
        /// <param name="pieceId">the Id of the marble on the node</param>
        public Node(int x, int y, PlayerColor? campColorID = null, int? pieceId = null)
        {
            Pointer = new Point(x, y);
            CampColorId = campColorID;
            MarbleID = pieceId;
        }

        /// <summary>
        /// Function that checks whether the node is available for a marble
        /// </summary>
        /// <returns>boolean value if available or not</returns>
        public bool IsAvalible()
        {
            return MarbleID is null;
        }
    }
}
