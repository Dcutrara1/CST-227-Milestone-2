using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_1___Grid_Based_Game
{
    class Game_Cell
    {       
        // Properties
        public bool Visited { get; set; }
        public bool Bomb { get; set; }
        public bool BombUp { get; set; }
        public bool BombUpRight { get; set; }
        public bool BombRight { get; set; }
        public bool BombDownRight { get; set; }
        public bool BombDown { get; set; }
        public bool BombDownLeft { get; set; }
        public bool BombLeft { get; set; }
        public bool BombUpLeft { get; set; }
        static public int Count { get; set; }        
    }
}
