﻿using ChineseCheckers.Enums;
using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    public class Marble
    {
        public int Id { get; set; }
        public Point Pointer { get; set; }
        public PlayerColor MarbleColor { get; set; }
        public CanvasBitmap Image { get; set; }

        public Marble(int id, Point pointer, PlayerColor marblecolor)
        {
            this.Id = id;
            this.Pointer = pointer;
            this.MarbleColor = marblecolor;
        }
    }
}