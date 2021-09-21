using ChineseCheckers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    public class Player
    {
        public int Id { get; set; }
        public bool IsAI { get; set; }
        public PlayerColor ColorId;

        public Player()
        {

        }

        public Player(int id)
        {
            this.Id = id;
            this.IsAI = true;
        }
    }
}
