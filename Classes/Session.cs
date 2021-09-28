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
            if (opponents == 3)
            {
                Players = new List<Player>
                {
                new Player(PlayerColor.Green)
                };
            }
            else
            {
                Players = new List<Player>
                {
                new Player(PlayerColor.Blue)
                };
            }

            if (opponents == 1)
            {
                Players.Add(new Player(1, PlayerColor.Purple));
            }
            if (opponents == 2)
            {
                Players.Add(new Player(1, PlayerColor.Pink));
                Players.Add(new Player(2, PlayerColor.Yellow));
            }
            if (opponents == 3)
            {
                Players.Add(new Player(1, PlayerColor.Red));
                Players.Add(new Player(2, PlayerColor.Pink));
                Players.Add(new Player(3, PlayerColor.Yellow));
            }
            if (opponents == 5)
            {
                Players.Add(new Player(1, PlayerColor.Red));
                Players.Add(new Player(2, PlayerColor.Pink));
                Players.Add(new Player(3, PlayerColor.Purple));
                Players.Add(new Player(4, PlayerColor.Yellow));
                Players.Add(new Player(5, PlayerColor.Green));
            }
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
