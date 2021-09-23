using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Classes
{
    class Rule
    {
        public static string RuleText = "The aim is to race all one's frogs into the star corner on the opposite side of the board before the opponents do the same. " +
            "The destination corner is called home. Each player has 10 frogs. Each player starts with their colored frogs on one of the six points or " +
            "corners of the star and attempts to race them all home into the opposite corner."+ /* Colum1 */
            "\n\nPlayers take turns moving a single frog, either by moving one step in any \ndirection to an adjacent empty lily pad, " +
            "or by jumping in one or any number \nof available consecutive hops over other single frogs. A player may not \ncombine hopping with a single-step move " +
            "– a move consists of one \nor the other." + 
            "\n\nIn the example, Pink might move the topmost frog one space diagonally \nforward as shown. " +
            "A hop consists of jumping over a single adjacent frog,\neither one's own or an opponent's, to the empty lily pad directly beyond it in \nthe same " +
            "line of direction. Blue might advance the indicated frog by a chain of three hops in a single move. \nIt is not mandatory to make the most hops possible. " +
            "(In some instances a player may choose to stop the jumping sequence part way in order to impede the opponent's progress, " +
            "or to align frogs for planned future moves.)";


    }
}
