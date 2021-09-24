using ChineseCheckers.Enums;
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
        public Player CurrentPlayer { get; set; }
        public Session(List<Node> Nodes, int opponents)
        {
            Players = new List<Player>
            {
                new Player(PlayerColor.Blue)
            };

            if (opponents == 1)
            {
                Players.Add(new Player(1, PlayerColor.Purple));
            }
            if (opponents == 2)
            {
                Players.Add(new Player(1, PlayerColor.Pink));
                Players.Add(new Player(2, PlayerColor.Yellow));
            }
            //if (opponents == 3)
            //{
            //    //this.Players.Add(new Player(1));
            //    //this.Players.Add(new Player(2));
            //    //this.Players.Add(new Player(3));
            //}
            //if (opponents == 4)
            //{
            //    this.Players.Add(new Player(1));
            //}
            //if (opponents == 5)
            //{
            //    this.Players.Add(new Player(1));
            //}
            Board = new GameBoard(Nodes, Players);
            CurrentPlayer = Players.First();
        }

        public void Turn()
        {
            var nextPlayer = Players.FirstOrDefault(x => x.Id == CurrentPlayer.Id + 1);
            if (nextPlayer == null)
            {
                nextPlayer = Players.First();
            }
            CurrentPlayer = nextPlayer;
        }
    }
}
