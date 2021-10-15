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


        /// <param name="colorId">the color of the players marbles</param>
        /// <param name="name">name of the player</param>
        public Player(PlayerColor colorId, string name)
        {
            this.ColorId = colorId;
            this.Name = name;
        }


        /// <param name="id">the id of the player</param>
        /// <param name="colorID">the color of the players marbles</param>
        /// <param name="name">the name of the players</param>
        public Player(int id, PlayerColor colorID, string name)
        {
            this.ColorId = colorID;
            this.Id = id;
            this.IsAI = true;
            this.Name = name;
        }
    }
}
