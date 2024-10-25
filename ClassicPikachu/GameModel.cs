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

            for (int i = 0; i < (width - 2) * (height - 2) / 2; i++)
            {
                int type = random.Next(1, numOfType);

                //First Cell
                int x1 = random.Next(1, height - 1);
                int y1 = random.Next(1, width - 1);
                while (table[x1, y1] != 0)
                {
                    x1 = random.Next(1, height - 1);
                    y1 = random.Next(1, width - 1);
                }

                table[x1, y1] = type;

                //Second Cell
                int x2 = random.Next(1, height - 1);
                int y2 = random.Next(1, width - 1);
                while (table[x2, y2] != 0)
                {
                    x2 = random.Next(1, height - 1);
                    y2 = random.Next(1, width - 1);
                }

                 table[x2, y2] = type;
            }
        }
        public int GetCell(int i, int j) => table[i, j];
    }
}
