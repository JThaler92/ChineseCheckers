using ChineseCheckers.Enums;
using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    public class Session
    {
        //public Moving moving { get; set; }
        public Dictionary<PlayerColor, PlayerColor> GoalTarget { get; set; }
        public GameBoard Board { get; set; }
        public List<Player> Players { get; set; }
        public Player CurrentPlayer { get; set; }
        public bool HasWinner { get; set; }

        public Session(List<Node> Nodes, int opponents)
        {
            //moving = new Moving(25);
            GoalTarget = new Dictionary<PlayerColor, PlayerColor>()
            {
                {PlayerColor.Blue, PlayerColor.Purple },
                {PlayerColor.Purple, PlayerColor.Blue },
                {PlayerColor.Green, PlayerColor.Pink },
                {PlayerColor.Pink, PlayerColor.Green },
                {PlayerColor.Yellow, PlayerColor.Red },
                {PlayerColor.Red, PlayerColor.Yellow }
            };
            
            if (opponents == 3)
            {
                Players = new List<Player>
                {
                new Player(PlayerColor.Green, StartSettings.playerOne)
                };
            }
            else
            {
                Players = new List<Player>
                {
                new Player(PlayerColor.Blue, StartSettings.playerOne)
                };
            }

            if (opponents == 1)
            {
                Players.Add(new Player(1, PlayerColor.Purple, StartSettings.playerTwo));
            }
            if (opponents == 2)
            {
                Players.Add(new Player(1, PlayerColor.Pink, StartSettings.playerTwo));
                Players.Add(new Player(2, PlayerColor.Yellow, StartSettings.playerThree));
            }
            if (opponents == 3)
            {
                Players.Add(new Player(1, PlayerColor.Red, StartSettings.playerTwo));
                Players.Add(new Player(2, PlayerColor.Pink, StartSettings.playerThree));
                Players.Add(new Player(3, PlayerColor.Yellow, StartSettings.playerFour));
            }
            if (opponents == 5)
            {
                Players.Add(new Player(1, PlayerColor.Red, StartSettings.playerTwo));
                Players.Add(new Player(2, PlayerColor.Pink, StartSettings.playerThree));
                Players.Add(new Player(3, PlayerColor.Purple, StartSettings.playerFour));
                Players.Add(new Player(4, PlayerColor.Yellow, StartSettings.playerFive));
                Players.Add(new Player(5, PlayerColor.Green, StartSettings.playerSix));
            }
            Board = new GameBoard(Nodes, Players);
            HasWinner = false;
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
            if (CurrentPlayer.IsAI)
            {
                while (Moving.move)
                {
                    Thread.Sleep(500);
                }
                WinCheck();
                MoveAI();
            }
        }

        public void WinCheck()
        {
            Debug.WriteLine("WINCHECK CALLED");
            this.Players.ForEach(x => x.Score = 0);
            foreach (var M in Board.Marbles)
            {
                var goal = GoalTarget[M.MarbleColor];
                var marblePos = Board.Nodes.Find(x => x.Pointer == M.Pointer);

                if (marblePos.CampColorId == goal)
                {
                    var player = Players.Find(x => x.ColorId == M.MarbleColor);
                    player.Score++;
                }
                
            }    
            foreach (var P in Players)
            {
                Debug.WriteLine(P.Score);
                if (P.Score == 1)
                {
                    //TODO: BREAK GAME;
                    HasWinner = true;
                    Debug.WriteLine(P.ColorId + " WINS");
                }
            }
        }
        private void MoveAI()
        {
            //Thread.Sleep(1500);
            var marbles = Board.Marbles.Where(x => x.MarbleColor == this.CurrentPlayer.ColorId);

            Dictionary<Marble, List<Node>> legalNodes = new Dictionary<Marble, List<Node>>();

            foreach (var M in marbles)
            {
                var moves = Board.GetLegalJumps(M);
                if (moves.Count > 0)
                {
                    legalNodes.Add(M, moves);
                }
            }
            //Moving animation = new Moving(25);
            Random rnd = new Random();
            var randomMarble = legalNodes.ElementAt(rnd.Next(0, legalNodes.Count));
            var marble = randomMarble.Key;
            Moving.SelectMarble(marble); // Set AI Marble to move
            var targetNode = randomMarble.Value.ElementAt(rnd.Next(0, randomMarble.Value.Count));
            Board.MarbleMove(targetNode, marble);
            Turn();
        }
    }
}
