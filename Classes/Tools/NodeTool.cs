using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseCheckers.Enums;
using ChineseCheckers.Classes;

namespace ChineseCheckers.Classes.Tools
{
    class NodeTool
    {
        /// <summary>
        /// Create all required nodes
        /// </summary>
        /// <returns>List with all nodes</returns>
        public static List<Node> InitiateNodes()
        {
            List<Node> nodeList = new List<Node>()
            {
                { new Node( 0, 0, PlayerColor.Pink )},
                { new Node( 0, 1, PlayerColor.Pink)}, { new Node( 1, 0, PlayerColor.Pink )},
                { new Node( 0, 2, PlayerColor.Pink )}, { new Node( 1, 1, PlayerColor.Pink )}, { new Node( 2, 0, PlayerColor.Pink )},
                { new Node( 0, 3, PlayerColor.Pink )}, { new Node( 1, 2, PlayerColor.Pink )}, { new Node( 2, 1, PlayerColor.Pink )}, { new Node( 3, 0, PlayerColor.Pink )},
                { new Node( -4, 8, PlayerColor.Red)}, { new Node( -3, 7, PlayerColor.Red )}, { new Node( -2, 6, PlayerColor.Red )}, { new Node( -1, 5 , PlayerColor.Red)}, { new Node( 0, 4 )}, { new Node( 1, 3 )}, { new Node( 2, 2 )}, { new Node( 3, 1 )}, { new Node( 4, 0 )}, { new Node( 5, -1, PlayerColor.Purple )}, { new Node( 6, -2, PlayerColor.Purple )}, { new Node( 7, -3, PlayerColor.Purple )}, { new Node( 8, -4, PlayerColor.Purple )},
                { new Node( -3, 8, PlayerColor.Red)}, { new Node( -2, 7, PlayerColor.Red )}, { new Node( -1, 6, PlayerColor.Red )}, { new Node( 0, 5 )}, { new Node( 1, 4 )}, { new Node( 2, 3 )}, { new Node( 3, 2 )}, { new Node( 4, 1 )}, { new Node( 5, 0 )}, { new Node( 6, -1, PlayerColor.Purple )}, { new Node( 7, -2, PlayerColor.Purple )}, { new Node( 8, -3, PlayerColor.Purple )},
                { new Node( -2, 8, PlayerColor.Red )}, { new Node( -1, 7, PlayerColor.Red )}, { new Node( 0, 6 )}, { new Node( 1, 5 )}, { new Node( 2, 4 )}, { new Node( 3, 3 )}, { new Node( 4, 2 )}, { new Node( 5, 1 )}, { new Node( 6, 0 )}, { new Node( 7, -1, PlayerColor.Purple )}, { new Node( 8, -2, PlayerColor.Purple )},
                { new Node( -1, 8, PlayerColor.Red )}, { new Node( 0, 7 )}, { new Node( 1, 6 )}, { new Node( 2, 5 )}, { new Node( 3, 4 )}, { new Node( 4, 3 )}, { new Node( 5, 2 )}, { new Node( 6, 1 )}, { new Node( 7, 0 )}, { new Node( 8, -1, PlayerColor.Purple )},
                { new Node( 0, 8 )}, { new Node( 1, 7 )}, { new Node( 2, 6 )}, { new Node( 3, 5 )}, { new Node( 4, 4 )}, { new Node( 5, 3 )}, { new Node( 6, 2 )}, { new Node( 7, 1 )}, { new Node( 8, 0 )},
                { new Node( 0, 9, PlayerColor.Blue )}, { new Node( 1, 8 )}, { new Node( 2, 7 )}, { new Node( 3, 6 )}, { new Node( 4, 5 )}, { new Node( 5, 4 )}, { new Node( 6, 3 )}, { new Node( 7, 2 )}, { new Node( 8, 1 )}, { new Node( 9, 0, PlayerColor.Yellow )},
                { new Node( 0, 10, PlayerColor.Blue )}, { new Node( 1, 9, PlayerColor.Blue )}, { new Node( 2, 8 )}, { new Node( 3, 7 )}, { new Node( 4, 6 )}, { new Node( 5, 5 )}, { new Node( 6, 4 )}, { new Node( 7, 3 )}, { new Node( 8, 2 )}, { new Node( 9, 1, PlayerColor.Yellow )}, { new Node( 10, 0, PlayerColor.Yellow )},
                { new Node( 0, 11, PlayerColor.Blue )}, { new Node( 1, 10, PlayerColor.Blue )}, { new Node( 2, 9, PlayerColor.Blue )}, { new Node( 3, 8 )}, { new Node( 4, 7 )}, { new Node( 5, 6 )}, { new Node( 6, 5 )}, { new Node( 7, 4 )}, { new Node( 8, 3 )}, { new Node( 9, 2, PlayerColor.Yellow )}, { new Node( 10, 1, PlayerColor.Yellow )}, { new Node( 11, 0, PlayerColor.Yellow )},
                { new Node( 0, 12, PlayerColor.Blue )}, { new Node( 1, 11, PlayerColor.Blue )}, { new Node( 2, 10, PlayerColor.Blue )}, { new Node( 3, 9, PlayerColor.Blue )}, { new Node( 4, 8 )}, { new Node( 5, 7 )}, { new Node( 6, 6 )}, { new Node( 7, 5 )}, { new Node( 8, 4 )}, { new Node( 9, 3, PlayerColor.Yellow )}, { new Node( 10, 2, PlayerColor.Yellow )}, { new Node( 11, 1, PlayerColor.Yellow )}, { new Node( 12, 0, PlayerColor.Yellow )},
                { new Node( 5, 8, PlayerColor.Green )}, { new Node( 6, 7, PlayerColor.Green )}, { new Node( 7, 6, PlayerColor.Green )}, { new Node( 8, 5, PlayerColor.Green )},
                { new Node( 6, 8, PlayerColor.Green )}, { new Node( 7, 7, PlayerColor.Green )}, { new Node( 8, 6, PlayerColor.Green )},
                { new Node( 7, 8, PlayerColor.Green )}, { new Node( 8, 7, PlayerColor.Green )},
                { new Node( 8, 8, PlayerColor.Green )}
            };
            return nodeList;
        }
    }
}
