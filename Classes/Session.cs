using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    public class Session
    {
        public GameBoard Board { get; set; }
        public List<Player> Players { get; set; }


        public Session(List<Node> Nodes)
        {
            this.Players = new List<Player>();
            this.Players.Add(new Player());


            this.Board = new GameBoard(Nodes, this.Players);
        }


    }
}
