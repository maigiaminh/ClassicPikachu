using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicPikachu
{
    public class GameData
    {
        public List<List<int>> Grid { get; set; }
        public int MatchCount { get; set; }
        public int Score {  get; set; }
        public int Time { get; set; }
        public int Level { get; set; }
    }
}
