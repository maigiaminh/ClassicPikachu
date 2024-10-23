using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicPikachu
{
    class GameModel
    {
        private int[,] table;
        private int width, height;

        public int Width => width;
        public int Height => height;
        public GameModel(int width, int height, int numOfType)
        {
            this.width = width;
            this.height = height;

            table = new int[height, width];

            Random random = new Random();

            for (int i = 0; i < width * height / 2; i++)
            {
                int type = random.Next(1, numOfType);
                
                //First Cell
                int x1 = random.Next(0, height);
                int y1 = random.Next(0, width);
                while (table[x1, y1] != 0) {
                    x1 = random.Next(0, height);
                    y1 = random.Next(0, width);
                }

                table[x1, y1] = type;

                //Second Cell
                int x2 = random.Next(0, height);
                int y2 = random.Next(0, width);
                while (table[x2, y2] != 0)
                {
                    x2 = random.Next(0, height);
                    y2 = random.Next(0, width);
                }

                table[x2, y2] = type;
            }
        }
        public int GetCell(int i, int j) => table[i, j];
    }
}
