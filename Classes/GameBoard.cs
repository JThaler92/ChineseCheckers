﻿using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Foundation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    public class GameBoard
    {
        public List<Node> Nodes { get; private set; }
        public List<Marble> Marbles { get; private set; }
        public Point Pointer { get; set; }

        public GameBoard(List<Node> nodes, List<Player> players)
        {
            Nodes = nodes;
            Marbles = new List<Marble>();
            PopulateNodes(players);
        }

        private void PopulateNodes(List<Player> players)
        {
            //Sets marbles in all colored nodes

            foreach (var L in Nodes)
            {
                if (L.CampColorId != null && players.Contains(players.Find(x => x.ColorId == L.CampColorId)))
                {
                    var P = new Marble(Marbles.Count, L.Pointer, L.CampColorId.Value);
                    Marbles.Add(P);
                    L.MarbleID = P.Id;
                }
            }
        }


        public List<Node> GetLegalJumps(Marble marble)
        {
            var availableMoves = FindLegalJumps(marble.Pointer);
            availableMoves.RemoveAt(0);
            return availableMoves;
        }
        private List<Node> FindLegalJumps(Point pointer, List<Node> availableMoves = null, bool alreadyMoved = false)
        {
            List<(int, int)> legalMoves = new List<(int, int)>()
            {
                (1, 0),
                (-1, 0),
                (0, 1),
                (0, -1),
                (1, -1),
                (-1, 1)
            };

            if (availableMoves is null)
            {
                availableMoves = new List<Node>();
                availableMoves.Add(Nodes.Find(N => N.Pointer == pointer));
            }
            Node targetNode;

            foreach (var lm in legalMoves)
            {
                targetNode = Nodes.Find(N => N.Pointer == new Point(pointer.X + lm.Item1, pointer.Y + lm.Item2));
                //if node is empty
                if (targetNode != null && !availableMoves.Contains(targetNode)) // If targetlocation is on the board and location is not already in availableMoves
                {
                    if (targetNode.MarbleID is null)
                    {
                        if (!alreadyMoved)
                        {
                            availableMoves.Add(targetNode);
                        }
                    }
                    // If the location contains a marble it extends jumping over it
                    else
                    {
                        targetNode = Nodes.Find(N => N.Pointer == new Point(pointer.X + (lm.Item1 * 2), pointer.Y + (lm.Item2 * 2)));
                        if (targetNode != null && !availableMoves.Contains(targetNode)) // If targetlocation is on the board and location is not already in availableMoves
                        {
                            if (targetNode.MarbleID is null)
                            {
                                availableMoves.Add(targetNode);
                                availableMoves = FindLegalJumps(targetNode.Pointer, availableMoves, true);
                            }
                        }
                    }
                }
            }
            return availableMoves;
        }
        public void MarbleMove(Node N, Marble selectedMarble, Moving moving)
        {
            this.Nodes.Find(Nod => selectedMarble.Id == Nod.MarbleID).MarbleID = null;
            selectedMarble.Pointer = N.Pointer;
            moving.SelectLocation(N);
            N.MarbleID = selectedMarble.Id;
        }
    }
}
