﻿using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    public class GameBoard
    {
        public List<Node> Nodes { get; private set; }
        public List<Marble> Marbles { get; private set; }

        public GameBoard(List<Node> nodes, List<Player> players)
        {
            this.Nodes = nodes;         
            this.Marbles = new List<Marble>();
            PopulateNodes(players);
        }

        private void PopulateNodes(List<Player> players)
        {
            //Sets marbles in all colored nodes

            foreach (var L in Nodes)
            {
                if (L.CampColorId != null)
                {
                    var P = new Marble(Marbles.Count, L.Pointer, L.CampColorId.Value);
                    Marbles.Add(P);
                    L.MarbleID = P.Id;
                }
            }
        }
       
    }
}
