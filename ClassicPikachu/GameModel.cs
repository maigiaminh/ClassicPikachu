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

            HashSet<int> cellIndex = new HashSet<int>();

            Random random = new Random();

            for (int i = 0; i < width * height / 2; i++)
            {
                int type = random.Next(0, numOfType);
                int firstCell = random.Next(random.Next(0, width * height + 1));
                while (cellIndex.Contains(firstCell))
                    firstCell = random.Next(random.Next(0, width * height + 1));
                table[firstCell / width, firstCell % width] = type;
                cellIndex.Add(firstCell);

                int secondCell = random.Next(random.Next(0, width * height + 1));
                while (cellIndex.Contains(secondCell))
                    secondCell = random.Next(random.Next(0, width * height + 1));
                table[secondCell / width, secondCell % width] = type;
                cellIndex.Add(secondCell);
            }
        }
        public int GetCell(int i, int j) => table[i, j];
    }
}
