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
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsAI { get; set; }
        public PlayerColor ColorId;
        public int? Score { get; set; }

        public Player(PlayerColor colorId, string name)
        {
            this.ColorId = colorId;
            this.Name = name;
        }

        public Player(int id, PlayerColor colorID, string name)
        {
            this.ColorId = colorID;
            this.Id = id;
            this.IsAI = true;
            this.Name = name;
        }
    }
}
