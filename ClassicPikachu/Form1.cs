using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClassicPikachu
{
    public partial class Form1 : Form
    {
        private Image[] images;
        private int[,] grid;
        private PictureBox firstClicked = null;
        private PictureBox secondClicked = null;
        PictureBox[] px;
        Label[] lblTags;
        GameModel gameModel;
        private int matchCount = 0;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private List<Point> path = new List<Point>();
        private System.Windows.Forms.Timer clearPathTimer = new System.Windows.Forms.Timer();

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

            clearPathTimer.Interval = 1000;
            clearPathTimer.Tick += ClearPathTimer_Tick;

            gameModel = new GameModel(8, 5, 15);
            grid = new int[gameModel.Width, gameModel.Height];

            px = new PictureBox[gameModel.Height * gameModel.Width];
            lblTags = new Label[gameModel.Height * gameModel.Width];

            for (int i = 0; i < gameModel.Height; i++)
                for (int j = 0; j < gameModel.Width; j++)
                {
                    int idx = i * gameModel.Width + j;

                    int tag = gameModel.GetCell(i, j);

                    grid[j, i] = tag;

                    px[idx] = new PictureBox();

                    px[idx].Width = 40;
                    px[idx].Height = 50;
                    px[idx].Top = 50 + i * 50;
                    px[idx].Left = 50 + j * 40;

                    px[idx].Image = images[tag];
                    px[idx].Tag = tag;
                    px[idx].SizeMode = PictureBoxSizeMode.CenterImage;
                    px[idx].BackColor = Color.Transparent;
                    px[idx].Cursor = Cursors.Hand;

                    px[idx].Click += new EventHandler(pictureBoxClickEventhandle);
                    px[idx].MouseHover += new EventHandler(pictureBoxMouseHoverEventhandle);
                    px[idx].MouseLeave += new EventHandler(pictureBoxMouseLeaveEventhandle);

                    pictureBoxes.Add(px[idx]);

                    lblTags[idx] = new Label();
                    lblTags[idx].Width = 24;
                    lblTags[idx].Height = 16;
                    lblTags[idx].Text = tag.ToString();
                    lblTags[idx].TextAlign = ContentAlignment.MiddleCenter;
                    lblTags[idx].BackColor = Color.Transparent;
                    lblTags[idx].ForeColor = Color.Black;
                    lblTags[idx].Font = new Font("Arial", 8, FontStyle.Bold);
                    lblTags[idx].BackColor = Color.Transparent;
                    lblTags[idx].Location = new Point(px[idx].Left + (px[idx].Width - lblTags[idx].Width) / 2,
                                                      px[idx].Top + (px[idx].Height - lblTags[idx].Height) / 2);
                    this.Controls.Add(lblTags[idx]);
                    this.Controls.Add(px[idx]);

                    if ((int)px[idx].Tag == 0)
                    {
                        px[idx].Dispose();
                    }
                }

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
                    if (firstClicked == pb || (int)firstClicked.Tag != (int)pb.Tag)
                    {
                        firstClicked.Image = images[(int)firstClicked.Tag];
                        firstClicked = null;
                        return;
                    }


                    firstClicked.Image = images[(int)firstClicked.Tag];
                    secondClicked = pb;
                    int x1 = (firstClicked.Left - 50) / 40;
                    int y1 = (firstClicked.Top - 50) / 50;
                    int x2 = (secondClicked.Left - 50) / 40;
                    int y2 = (secondClicked.Top - 50) / 50;
                    if (IsShortestPath(grid, new Point(x1, y1), new Point(x2, y2)))
                    {
                        grid[x1, y1] = -1;
                        grid[x2, y2] = -1;
                        int idx1 = y1 * grid.GetLength(0) + x1;
                        int idx2 = y2 * grid.GetLength(0) + x2;
                        lblTags[idx1].Text = grid[x1, y1].ToString();
                        lblTags[idx2].Text = grid[x2, y2].ToString();

                        firstClicked.Visible = false;
                        secondClicked.Visible = false;

                        pictureBoxes[idx1].Tag = -1;
                        pictureBoxes[idx2].Tag = -1;

                        MessageBox.Show(pictureBoxes.Count() + "");
                    }
                    else
                    {
                        MessageBox.Show("NOT OK");
                    }
                    firstClicked = null;
                    secondClicked = null;
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

        private bool IsShortestPath(int[,] grid, Point start, Point end)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            bool[,,] visited = new bool[rows, cols, 4];

            (int x, int y, int dir)[,,] parent = new (int, int, int)[rows, cols, 4];

            Queue<(int x, int y, int dir, int turns)> queue = new Queue<(int, int, int, int)>();

            for (int i = 0; i < 4; i++)
            {
                int adjX = start.X + dx[i];
                int adjY = start.Y + dy[i];

                if (adjX == end.X && adjY == end.Y)
                {
                    Debug.WriteLine($"Shortest path: ({start.X}, {start.Y}) -> ({end.X}, {end.Y})");

                    path.Add(new Point(start.X, start.Y));
                    path.Add(new Point(end.X, end.Y));
                    UpdatePath(path);
                    clearPathTimer.Start();
                    return true;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                int newX = start.X + dx[i];
                int newY = start.Y + dy[i];

                if (newX >= 0 && newY >= 0 && newX < rows && newY < cols && (grid[newX, newY] == 0 || grid[newX, newY] == -1))
                {
                    queue.Enqueue((newX, newY, i, 1));
                    visited[newX, newY, i] = true;
                    parent[newX, newY, i] = (start.X, start.Y, -1);
                }
            }

            while (queue.Count > 0)
            {
                var (x, y, dir, turns) = queue.Dequeue();

                if (x == end.X && y == end.Y)
                {
                    List<Point> path = new List<Point>();
                    path.Add(new Point(x, y));

                    while (!(x == start.X && y == start.Y))
                    {
                        var (prevX, prevY, prevDir) = parent[x, y, dir];
                        path.Add(new Point(prevX, prevY));
                        x = prevX;
                        y = prevY;
                        dir = prevDir;
                    }

                    path.Reverse();
                    Debug.WriteLine("Shortest path:");
                    foreach (var p in path)
                    {
                        Debug.WriteLine($"({p.X}, {p.Y})");
                    }
                    UpdatePath(path);

                    clearPathTimer.Start();

                    return true;
                }

                int newX = x + dx[dir];
                int newY = y + dy[dir];

                if (newX >= 0 && newY >= 0 && newX < rows && newY < cols)
                {
                    if ((newX == end.X && newY == end.Y) || (grid[newX, newY] == 0 || grid[newX, newY] == -1))
                    {
                        if (!visited[newX, newY, dir])
                        {
                            visited[newX, newY, dir] = true;
                            queue.Enqueue((newX, newY, dir, turns));
                            parent[newX, newY, dir] = (x, y, dir);
                        }
                    }
                }

                if (turns < 3)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i != dir)
                        {
                            newX = x + dx[i];
                            newY = y + dy[i];

                            if (newX >= 0 && newY >= 0 && newX < rows && newY < cols)
                            {
                                if ((newX == end.X && newY == end.Y) || (grid[newX, newY] == 0 || grid[newX, newY] == -1))
                                {
                                    if (!visited[newX, newY, i])
                                    {
                                        visited[newX, newY, i] = true;
                                        queue.Enqueue((newX, newY, i, turns + 1));
                                        parent[newX, newY, i] = (x, y, dir);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
        private void UpdatePath(List<Point> newPath)
        {
            path = newPath;
            this.Invalidate();
        }

        private void DrawPath(Graphics g)
        {
            if (path.Count < 2) return;

            using (Pen pen = new Pen(Color.FromArgb(0, 255, 66), 5))
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Point point1 = new Point(path[i].X * 40 + 50 + 20, path[i].Y * 50 + 50 + 25);
                    Point point2 = new Point(path[i + 1].X * 40 + 50 + 20, path[i + 1].Y * 50 + 50 + 25);
                    g.DrawLine(pen, point1, point2);
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawPath(e.Graphics);
        }
        private void ClearPathTimer_Tick(object sender, EventArgs e)
        {
            path.Clear();
            this.Invalidate();
            clearPathTimer.Stop();
        }

        private void ShuffleTable()
        {
            Random random = new Random();

            var tags = pictureBoxes.Where(pb => (int)pb.Tag != 0).Select(pb => pb.Tag).ToList();

            if (tags.Count == 0)
            {
                MessageBox.Show("Không có Tag hợp lệ nào để shuffle!");
                return;
            }

            tags = tags.OrderBy(x => random.Next()).ToList();

            tags.ForEach(p  => { Debug.WriteLine(p); });
            int index = 0;

            foreach (var pb in pictureBoxes)
            {
                if ((int)pb.Tag != 0) 
                {

                    if ((int)tags[index] == -1)
                    {
                        pb.Tag = -1;
                        pb.Image = null;
                        pb.Visible = false;
                    }
                    else
                    {
                        pb.Image = images[(int)tags[index]];
                        pb.Tag = (int)tags[index];
                        pb.Visible = true;
                    }

                    index++;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShuffleTable();
        }
    }
}
