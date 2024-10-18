using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ClassicPikachu
{
    public partial class Form1 : Form
    {
        private Image[] images;
        private PictureBox firstClicked = null;
        private PictureBox secondClicked = null;
        private int matchCount = 0;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private void LoadImages()
        {
            images = new Image[36];
            images[0] = Properties.Resources._0;
            images[1] = Properties.Resources._1;
            images[2] = Properties.Resources._2;
            images[3] = Properties.Resources._3;
            images[4] = Properties.Resources._4;
            images[5] = Properties.Resources._5;
            images[6] = Properties.Resources._6;
            images[7] = Properties.Resources._7;
            images[8] = Properties.Resources._8;
            images[9] = Properties.Resources._9;
            images[10] = Properties.Resources._10;
            images[11] = Properties.Resources._11;
            images[12] = Properties.Resources._12;
            images[13] = Properties.Resources._13;
            images[14] = Properties.Resources._14;
            images[15] = Properties.Resources._15;
            images[16] = Properties.Resources._16;
            images[17] = Properties.Resources._17;
            images[18] = Properties.Resources._18;
            images[19] = Properties.Resources._19;
            images[20] = Properties.Resources._20;
            images[21] = Properties.Resources._21;
            images[22] = Properties.Resources._22;
            images[23] = Properties.Resources._23;
            images[24] = Properties.Resources._24;
            images[25] = Properties.Resources._25;
            images[26] = Properties.Resources._26;
            images[27] = Properties.Resources._27;
            images[28] = Properties.Resources._28;
            images[29] = Properties.Resources._29;
            images[30] = Properties.Resources._30;
            images[31] = Properties.Resources._31;
            images[32] = Properties.Resources._32;
            images[33] = Properties.Resources._33;
            images[34] = Properties.Resources._34;
            images[35] = Properties.Resources._35;
        }

        public Form1()
        {
            InitializeComponent();
            LoadImages();
            GameModel gameModel = new GameModel(8, 5, 15);
            PictureBox[] px = new PictureBox[gameModel.Height * gameModel.Width];
    
            for (int i = 0; i < gameModel.Height; i++)
                for (int j = 0; j < gameModel.Width; j++)
                {
                    int idx = i * gameModel.Width + j;

                    px[idx] = new PictureBox();
                    px[idx].Width = 40;
                    px[idx].Height = 50;
                    px[idx].Top = 10 + i * 50;
                    px[idx].Left = 10 + j * 40;

                    px[idx].Image = images[gameModel.GetCell(i, j)];
                    px[idx].Tag = gameModel.GetCell(i, j);
                    px[idx].SizeMode = PictureBoxSizeMode.CenterImage;
                    px[idx].BackColor = Color.Transparent;
                    px[idx].Cursor = Cursors.Hand;

                    px[idx].Click += new EventHandler(pictureBoxClickEventhandle);
                    px[idx].MouseHover += new EventHandler(pictureBoxMouseHoverEventhandle);
                    px[idx].MouseLeave += new EventHandler(pictureBoxMouseLeaveEventhandle);
                    this.Controls.Add(px[idx]);
                }

            //LoadImages();
            //CreatePictureBoxes(3);
            //InitializeGame();
        }
        public void pictureBoxMouseHoverEventhandle(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.BackColor = Color.Red;
            }
        }
        public void pictureBoxMouseLeaveEventhandle(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                pb.BorderStyle = BorderStyle.None;
                pb.BackColor = Color.Transparent;
            }
        }
        public void pictureBoxClickEventhandle(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            
            if (pb != null)
            {
                if (firstClicked == null)
                {
                    pb.Image = SetImageOpacity(pb.Image, 0.4f);
                    firstClicked = pb;
                }
                else 
                {
                    firstClicked.Image = images[(int) firstClicked.Tag];
                    firstClicked = null;
                }
            }
        }

        private Image SetImageOpacity(Image originalImage, float opacity)
        {
            Bitmap bmp = new Bitmap(originalImage.Width, originalImage.Height);
            Graphics g = Graphics.FromImage(bmp);

            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = opacity; 

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            g.DrawImage(originalImage,
                        new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                        0, 0, originalImage.Width, originalImage.Height,
                        GraphicsUnit.Pixel, attributes);
            g.Dispose();
            return bmp;
        }


        private void CreatePictureBoxes(int difficulty)
        {
            this.Controls.Clear();

            int gridSize;
            switch (difficulty)
            {
                case 1: 
                    gridSize = 4;
                    break;
                case 2: 
                    gridSize = 6;
                    break;
                case 3: 
                    gridSize = 8;
                    break;
                default:
                    return; 
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Width = 80,
                        Height = 80,
                        Margin = new Padding(5),
                        BackColor = Color.LightGray,
                        Tag = null
                    };
                    pictureBox.Location = new Point(j * 80, i * 80);
                    this.Controls.Add(pictureBox);
                    pictureBox.Cursor = Cursors.Hand;
                }
            }
        }


        private void CheckForMatch()
        {
            MessageBox.Show("CHECK");
            // Kiểm tra xem hình ảnh có khớp hay không
            if (firstClicked.Tag.Equals(secondClicked.Tag))
            {
                // Nếu khớp, tăng số cặp khớp và làm trống các PictureBox
                matchCount++;
                firstClicked.Dispose();
                secondClicked.Dispose();
                firstClicked = null;
                secondClicked = null;
                MessageBox.Show("OK");

                // Kiểm tra xem đã thắng game chưa
                if (matchCount == images.Length / 2)
                {
                    MessageBox.Show("Chúc mừng! Bạn đã thắng!");
                }
            }
            else
            {
                // Nếu không khớp, đặt lại hình ảnh sau một khoảng thời gian ngắn
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000; // Thời gian chờ (1 giây)
                timer.Tick += (s, e) =>
                {
                    firstClicked.Image = null; // Đặt lại hình ảnh đầu tiên
                    secondClicked.Image = null; // Đặt lại hình ảnh thứ hai
                    firstClicked = null; // Đặt lại PictureBox đầu tiên
                    secondClicked = null; // Đặt lại PictureBox thứ hai
                    timer.Stop(); // Dừng timer
                };
                timer.Start(); // Bắt đầu timer
            }

        }

        // Hàm kiểm tra đường đi giữa 2 hình
        private bool IsShortestPath(int[,] grid, Point start, Point end)
        {
            int rows = grid.GetLength(0);  // Số hàng
            int cols = grid.GetLength(1);  // Số cột

            // Định nghĩa 4 hướng di chuyển: trái, phải, lên, xuống
            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            // Tạo mảng để lưu số lần rẽ và trạng thái đã duyệt
            bool[,,] visited = new bool[rows, cols, 4];

            // Hàng đợi lưu trữ tọa độ, hướng di chuyển và số lần rẽ
            Queue<(int x, int y, int dir, int turns)> queue = new Queue<(int, int, int, int)>();

            // Khởi tạo: bắt đầu từ điểm đầu tiên với 4 hướng khác nhau
            for (int i = 0; i < 4; i++)
            {
                queue.Enqueue((start.X, start.Y, i, 0));
                visited[start.X, start.Y, i] = true;
            }

            while (queue.Count > 0)
            {
                var (x, y, dir, turns) = queue.Dequeue();

                // Nếu đã đến điểm đích, trả về true
                if (x == end.X && y == end.Y)
                {
                    return true;
                }

                // Tiếp tục duyệt theo hướng hiện tại
                int newX = x + dx[dir];
                int newY = y + dy[dir];

                // Kiểm tra di chuyển trong lưới
                if (newX >= 0 && newY >= 0 && newX < rows && newY < cols && grid[newX, newY] == 0)
                {
                    if (!visited[newX, newY, dir])
                    {
                        visited[newX, newY, dir] = true;
                        queue.Enqueue((newX, newY, dir, turns));
                    }
                }

                // Kiểm tra rẽ sang các hướng khác (không quá 3 lần rẽ)
                if (turns < 3)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i != dir)  // Không rẽ về cùng hướng
                        {
                            int newDirX = x + dx[i];
                            int newDirY = y + dy[i];

                            if (newDirX >= 0 && newDirY >= 0 && newDirX < rows && newDirY < cols && grid[newDirX, newDirY] == 0)
                            {
                                if (!visited[newDirX, newDirY, i])
                                {
                                    visited[newDirX, newDirY, i] = true;
                                    queue.Enqueue((newDirX, newDirY, i, turns + 1));
                                }
                            }
                        }
                    }
                }
            }

            return false; // Không tìm thấy đường hợp lệ
        }

    }
}
