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
        public int? Score { get; set; }

        public Player(PlayerColor colorId)
        {
            this.ColorId = colorId;
        }

        public Player(int id, PlayerColor colorID)
        {
            this.ColorId = colorID;
            this.Id = id;
            this.IsAI = true;
        }
    }
}
