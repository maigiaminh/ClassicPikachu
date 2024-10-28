using System.Diagnostics;
using System.Drawing.Imaging;
using System.Numerics;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ClassicPikachu
{
    public partial class PikachuGame : Form
    {
        private Image[] images;
        private int[,] grid;

        private PictureBox firstClicked = null;
        private PictureBox secondClicked = null;

        private PictureBox[] px;
        private Label[] lblTags;
        private GameModel gameModel;

        private bool delay = false;
        private int timeLeft;

        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private List<Point> path = new List<Point>();
        private System.Windows.Forms.Timer clearPathTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer checkMoveTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer delayPressTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();

        private bool isMusicOn = true;
        private bool isSoundOn = true;

        private AudioManager audioManager;

        private int level;
        private int tableWidth;
        private int tableHeight;
        private int cellWidth = 50;
        private int cellHeight = 70;
        private int offsetWidth;
        private int offsetHeight;

        private bool isPause = false;
        private bool isPlaying = false;

        private int score;
        private int matchCount = 0;
        private int totalCell;
        private int highscore;
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

        public PikachuGame()
        {
            InitializeComponent();

            LoadImages();

            audioManager = new AudioManager();
            audioManager.StartBackgroundMusic(0.3f);

            clearPathTimer.Interval = 500;
            clearPathTimer.Tick += ClearPathTimer_Tick;

            checkMoveTimer.Interval = 800;
            checkMoveTimer.Tick += CheckMoveTimer_Tick;

            delayPressTimer.Interval = 1000;
            delayPressTimer.Tick += DelayPressTimer_Tick;

            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;

            highscore = LoadHighScore();

            EnablePanel("menu");
        }

        private void StartGame(int level, bool isNewGame = false)
        {
            matchCount = 0;

            if (isNewGame)
            {
                score = 0;
                lblScore.Text = "SCORE: 0";
                string filePath = Path.Combine(Application.StartupPath, "Resources", "savedgame.json");
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            countdownTimer.Start();

            isPlaying = true;
            isPause = false;

            if (px != null && px.Length > 0)
            {
                foreach (PictureBox p in px)
                {
                    if (p == null) { continue; }
                    p.Dispose();
                }
            }

            pictureBoxes.Clear();

            switch (level)
            {
                case 0:
                    tableHeight = 7;
                    tableWidth = 14;
                    gameModel = new GameModel(tableWidth, tableHeight, 36);
                    grid = new int[gameModel.Width, gameModel.Height];

                    ResetTable(ref grid);

                    px = new PictureBox[gameModel.Height * gameModel.Width];
                    lblTags = new Label[gameModel.Height * gameModel.Width];

                    progressPlayTime.Maximum = 100;
                    progressPlayTime.Value = 100;
                    timeLeft = 100;

                    offsetWidth = 150;
                    offsetHeight = 100;

                    totalCell = 30;
                    break;

                case 1:
                    tableHeight = 7;
                    tableWidth = 16;
                    gameModel = new GameModel(tableWidth, tableHeight, 36);
                    grid = new int[gameModel.Width, gameModel.Height];

                    ResetTable(ref grid);

                    px = new PictureBox[gameModel.Height * gameModel.Width];
                    lblTags = new Label[gameModel.Height * gameModel.Width];

                    progressPlayTime.Maximum = 100;
                    progressPlayTime.Value = 100;
                    timeLeft = 100;

                    offsetWidth = 100;
                    offsetHeight = 100;

                    totalCell = 35;
                    break;

                case 2:
                    tableHeight = 7;
                    tableWidth = 18;
                    gameModel = new GameModel(tableWidth, tableHeight, 36);
                    grid = new int[gameModel.Width, gameModel.Height];

                    ResetTable(ref grid);

                    px = new PictureBox[gameModel.Height * gameModel.Width];
                    lblTags = new Label[gameModel.Height * gameModel.Width];

                    progressPlayTime.Maximum = 100;
                    progressPlayTime.Value = 100;
                    timeLeft = 100;

                    offsetWidth = 50;
                    offsetHeight = 100;

                    totalCell = 40;
                    break;
            }

            for (int i = 0; i < gameModel.Height; i++)
            {
                for (int j = 0; j < gameModel.Width; j++)
                {
                    int idx = i * gameModel.Width + j;

                    int tag = gameModel.GetCell(i, j);

                    grid[j, i] = tag;

                    px[idx] = new PictureBox();

                    px[idx].Width = cellWidth;
                    px[idx].Height = cellHeight;
                    px[idx].Top = offsetHeight + i * cellHeight;
                    px[idx].Left = offsetWidth + j * cellWidth;

                    px[idx].Image = images[tag];
                    px[idx].Tag = tag;
                    px[idx].SizeMode = PictureBoxSizeMode.CenterImage;
                    px[idx].BackColor = Color.Transparent;
                    px[idx].Cursor = Cursors.Hand;

                    px[idx].BringToFront();
                    px[idx].Click += new EventHandler(pictureBoxClickEventhandle);
                    px[idx].MouseHover += new EventHandler(pictureBoxMouseHoverEventhandle);
                    px[idx].MouseLeave += new EventHandler(pictureBoxMouseLeaveEventhandle);

                    pictureBoxes.Add(px[idx]);

                    /*
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
                    */

                    gamePanel.Controls.Add(px[idx]);

                    if ((int)px[idx].Tag == 0)
                    {
                        px[idx].Dispose();
                    }
                }
            }

        }

        private void DisableAllPanel()
        {
            menuPanel.Hide();
            chooseLevelPanel.Hide();
            gamePanel.Hide();
            pausePanel.Hide();
        }

        private void EnablePanel(string panelName)
        {
            DisableAllPanel();
            switch (panelName)
            {
                case "menu":
                    menuPanel.Show();
                    string filePath = Path.Combine(Application.StartupPath, "Resources", "savedgame.json");
                    lblHighScore.Text = $"HIGHSCORE: {highscore}";
                    if (File.Exists(filePath))
                    {
                        btnContinue.Image = Properties.Resources.cont;
                        btnContinue.Enabled = true;
                    }
                    else
                    {
                        btnContinue.Image = Properties.Resources.cont_disable;
                        btnContinue.Enabled = false;
                    }
                    break;
                case "choose":
                    chooseLevelPanel.Show();
                    break;
                case "game":
                    gamePanel.Show();
                    break;
                case "pause":
                    pausePanel.Show();
                    break;
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
            if (delay == true) return;

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
                        audioManager.PlaySoundEffect("oho");
                        return;
                    }


                    firstClicked.Image = images[(int)firstClicked.Tag];
                    secondClicked = pb;
                    int x1 = (firstClicked.Left - offsetWidth) / cellWidth;
                    int y1 = (firstClicked.Top - offsetHeight) / cellHeight;
                    int x2 = (secondClicked.Left - offsetWidth) / cellWidth;
                    int y2 = (secondClicked.Top - offsetHeight) / cellHeight;
                    if (IsShortestPath(grid, new Point(x1, y1), new Point(x2, y2)))
                    {
                        delay = true;

                        grid[x1, y1] = -1;
                        grid[x2, y2] = -1;
                        int idx1 = y1 * grid.GetLength(0) + x1;
                        int idx2 = y2 * grid.GetLength(0) + x2;
                        //lblTags[idx1].Text = grid[x1, y1].ToString();
                        //lblTags[idx2].Text = grid[x2, y2].ToString();

                        firstClicked.Visible = false;
                        secondClicked.Visible = false;

                        pictureBoxes[idx1].Tag = -1;
                        pictureBoxes[idx2].Tag = -1;

                        clearPathTimer.Start();
                        checkMoveTimer.Start();
                        delayPressTimer.Start();

                        audioManager.PlaySoundEffect("hit");

                        score += (level == 0) ? 3 : (level == 1) ? 5 : 10;
                        lblScore.Text = "SCORE: " + score.ToString();

                        matchCount++;

                        if (matchCount >= totalCell)
                        {
                            audioManager.PlaySoundEffect("win");

                            isPlaying = false;
                            isPause = true;
                            countdownTimer.Stop();
                            checkMoveTimer.Stop();

                            if (score > highscore)
                            {
                                highscore = score;
                                SaveHighScore(score);
                            }

                            DialogResult dialogResult = MessageBox.Show("You have clear this table. Do you want to continue?", "CONGRATULATION", MessageBoxButtons.YesNo);
                            
                            if (dialogResult == DialogResult.Yes)
                            {
                                StartGame(level);
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                EnablePanel("menu");
                                GameData currentGameData = new GameData
                                {
                                    Grid = ConvertGridToList(grid),
                                    Level = level,
                                    MatchCount = matchCount,
                                    Score = score,
                                    Time = timeLeft
                                };
                                SaveGame(currentGameData, @"Resources\savedgame.json");
                                SaveGame(currentGameData, @"Resources\savedgame.json");
                            }
                        }
                    }
                    else
                    {
                        audioManager.PlaySoundEffect("oho");
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
            gamePanel.Invalidate();
        }

        private void DrawPath(Graphics g)
        {
            if (path.Count < 2) return;

            int offset = level == 0 ? cellWidth : level == 1 ? cellWidth / 2 : 0;
            using (Pen pen = new Pen(Color.FromArgb(0, 255, 66), 5))
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Point point1 = new Point(path[i].X * cellWidth + offsetWidth + offsetWidth / 2 - offset,
                                            path[i].Y * cellHeight + offsetHeight + cellHeight / 2);
                    Point point2 = new Point(path[i + 1].X * cellWidth + offsetWidth + offsetWidth / 2 - offset,
                                            path[i + 1].Y * cellHeight + offsetHeight + cellHeight / 2);
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
        private void CheckMoveTimer_Tick(object sender, EventArgs e)
        {
            checkMoveTimer.Stop();
            CheckAndShuffleTable();
        }

        private void DelayPressTimer_Tick(object sender, EventArgs e)
        {
            delayPressTimer.Stop();
            delay = false;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0 && isPlaying)
            {
                if (isPause) { return; }
                timeLeft--;
                progressPlayTime.Value = timeLeft;
            }
            else
            {
                isPlaying = false;
                countdownTimer.Stop();
                DialogResult dialogResult;
                if (score > highscore)
                {
                    highscore = score;
                    SaveHighScore(score);
                    dialogResult = MessageBox.Show($"You got the highest score: {score}", "YOU LOST", MessageBoxButtons.OK);
                }
                else
                {
                    dialogResult = MessageBox.Show($"You scored: {score}", "YOU LOST", MessageBoxButtons.OK);
                }

                audioManager.PlaySoundEffect("lose");

                if (dialogResult == DialogResult.OK)
                {
                    EnablePanel("menu");
                    string filePath = Path.Combine(Application.StartupPath, "Resources", "savedgame.json");
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }

        private void ShuffleTable()
        {
            audioManager.PlaySoundEffect("shuffle");

            Random random = new Random();

            var tags = pictureBoxes.Where(pb => (int)pb.Tag != 0).Select(pb => pb.Tag).ToList();

            if (tags.Count == 0)
            {
                MessageBox.Show("Không có Tag hợp lệ nào để shuffle!");
                return;
            }

            tags = tags.OrderBy(x => random.Next()).ToList();

            tags.ForEach(p => { Debug.WriteLine(p); });
            int index = 0;

            foreach (var pb in pictureBoxes)
            {
                int row = (pb.Top - offsetHeight) / cellHeight;
                int col = (pb.Left - offsetWidth) / cellWidth;

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

                    grid[col, row] = (int)pb.Tag;
                    index++;
                }
            }

        }

        private bool HasValidMove()
        {
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                var pb1 = pictureBoxes[i];

                if ((int)pb1.Tag == 0 || (int)pb1.Tag == -1)
                    continue;
                for (int j = i + 1; j < pictureBoxes.Count; j++)
                {
                    var pb2 = pictureBoxes[j];

                    if ((int)pb2.Tag == 0 || (int)pb2.Tag == -1)
                        continue;

                    if (pb1.Tag.Equals(pb2.Tag))
                    {
                        if (IsPathClear(pb1, pb2))
                        {
                            path.ForEach(p => { Debug.WriteLine(p); });
                            path.Clear();
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void CheckAndShuffleTable()
        {

            while (!HasValidMove())
            {
                MessageBox.Show("Không còn nước đi, shuffle lại bàn chơi!");
                ShuffleTable();
            }
        }

        private bool IsPathClear(PictureBox pb1, PictureBox pb2)
        {
            int x1 = (pb1.Left - offsetWidth) / cellWidth;
            int y1 = (pb1.Top - offsetHeight) / cellHeight;
            int x2 = (pb2.Left - offsetWidth) / cellWidth;
            int y2 = (pb2.Top - offsetHeight) / cellHeight;

            return (IsShortestPath(grid, new Point(x1, y1), new Point(x2, y2)));
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            audioManager.backgroundPlayer?.Dispose();
            audioManager.backgroundMusic?.Dispose();
            audioManager.backgroundPlayer = null;
            audioManager.backgroundMusic = null;
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            ToggleMusic();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            audioManager.PlaySoundEffect("click", 1f);
            EnablePanel("choose");
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            ToggleSound();
        }

        private void ToggleSound()
        {
            audioManager.PlaySoundEffect("click");
            isSoundOn = !isSoundOn;
            if (isSoundOn)
            {
                btnSound.Image = Properties.Resources.sound_on;
                btnSoundPause.Image = Properties.Resources.sound_on;
                audioManager.MuteSoundEffects(false);
            }
            else
            {
                btnSound.Image = Properties.Resources.sound_off;
                btnSoundPause.Image = Properties.Resources.sound_off;
                audioManager.MuteSoundEffects(true);
            }
        }

        private void ToggleMusic()
        {
            audioManager.PlaySoundEffect("click");
            isMusicOn = !isMusicOn;
            if (isMusicOn)
            {
                btnMusic.Image = Properties.Resources.music_on;
                btnMusicPaused.Image = Properties.Resources.music_on;
                audioManager.MuteBackgroundMusic(false);
            }
            else
            {
                btnMusic.Image = Properties.Resources.music_off;
                btnMusicPaused.Image = Properties.Resources.music_off;
                audioManager.MuteBackgroundMusic(true);
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            EnablePanel("menu");
            audioManager.PlaySoundEffect("click", 1f);
            GameData currentGameData = new GameData
            {
                Grid = ConvertGridToList(grid),
                Level = level,
                MatchCount = matchCount,
                Score = score,
                Time = timeLeft
            };
            SaveGame(currentGameData, @"Resources\savedgame.json");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            audioManager.PlaySoundEffect("click", 1f);
            if (score > highscore)
            {
                highscore = score;
                SaveHighScore(score);
            }

            GameData currentGameData = new GameData
            {
                Grid = ConvertGridToList(grid),
                Level = level,
                MatchCount = matchCount,
                Score = score,
                Time = timeLeft
            };
            SaveGame(currentGameData, @"Resources\savedgame.json");

            EnablePanel("menu");

        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            EnablePanel("game");
            isPause = false;
            audioManager.PlaySoundEffect("click", 1f);
        }

        private void btnSoundPause_Click(object sender, EventArgs e)
        {
            ToggleSound();
        }

        private void btnMusicPaused_Click(object sender, EventArgs e)
        {
            ToggleMusic();
        }

        private void btnQuitPaused_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            audioManager.PlaySoundEffect("click", 1f);
            EnablePanel("choose");
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            audioManager.PlaySoundEffect("click", 1f);
            isPause = true;
            EnablePanel("pause");
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            ShuffleTable();
            while (!HasValidMove())
            {
                ShuffleTable();
            }
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            DrawPath(e.Graphics);
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            EnablePanel("game");
            audioManager.PlaySoundEffect("click", 1f);
            level = 0;
            lblLevel.Text = "LEVEL: EASY";
            StartGame(level, true);
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            EnablePanel("game");
            audioManager.PlaySoundEffect("click", 1f);
            level = 1;
            lblLevel.Text = "LEVEL: MEDIUM";
            StartGame(level, true);
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            EnablePanel("game");
            audioManager.PlaySoundEffect("click", 1f);
            level = 2;
            lblLevel.Text = "LEVEL: HARD";
            StartGame(level, true);
        }

        private void ResetTable(ref int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = 0;
                }
            }
        }

        public void SaveGame(GameData gameData, string filePath)
        {
            gameData.Grid = ConvertGridToList(grid);

            var jsonString = JsonSerializer.Serialize(gameData);

            File.WriteAllText(filePath, jsonString);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isPlaying)
            {
                if (score > highscore)
                {
                    highscore = score;
                    SaveHighScore(score);
                }

                GameData currentGameData = new GameData
                {
                    Grid = ConvertGridToList(grid),
                    Level = level,
                    MatchCount = matchCount,
                    Score = score,
                    Time = timeLeft
                };
                SaveGame(currentGameData, @"Resources\savedgame.json");
            }
        }
        private List<List<int>> ConvertGridToList(int[,] grid)
        {
            var list = new List<List<int>>();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                var row = new List<int>();
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    row.Add(grid[i, j]);
                }
                list.Add(row);
            }
            return list;
        }

        private int[,] ConvertListToGrid(List<List<int>> list)
        {
            int rows = list.Count;
            int cols = list[0].Count;
            int[,] grid = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = list[i][j];
                }
            }
            return grid;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "Resources", "savedgame.json");
            GameData loadedData = LoadGame(filePath);

            if (loadedData != null)
            {
                RestoreGame(loadedData);
            }


        }
        public GameData LoadGame(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.WriteLine("File save not found!");
                return null;
            }

            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<GameData>(jsonString);
        }

        public void RestoreGame(GameData gameData)
        {
            if (gameData == null) return;

            grid = ConvertListToGrid(gameData.Grid);

            pictureBoxes.Clear();

            px = new PictureBox[grid.GetLength(0) * grid.GetLength(1)];
            matchCount = gameData.MatchCount;
            score = gameData.Score;
            timeLeft = gameData.Time;
            level = gameData.Level;

            lblScore.Text = "SCORE: " + score;
            string levelStr = (level == 0) ? "EASY" : level == 1 ? "MEDIUM" : "HARD";
            lblLevel.Text = "LEVEL: " + levelStr;

            EnablePanel("game");
            isPlaying = true;
            isPause = false;

            progressPlayTime.Value = timeLeft;
            progressPlayTime.Maximum = 100;
            countdownTimer.Start();

            offsetHeight = 100;
            offsetWidth = level == 0 ? 150 : level == 1 ? 100 : 50;
            totalCell = level == 0 ? 30 : level == 1 ? 35 : 40;

            for (int i = 0; i < grid.GetLength(1); i++)
            {
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    int idx = i * grid.GetLength(0) + j;

                    int tag = grid[j, i];

                    px[idx] = new PictureBox();

                    px[idx].Width = cellWidth;
                    px[idx].Height = cellHeight;
                    px[idx].Top = offsetHeight + i * cellHeight;
                    px[idx].Left = offsetWidth + j * cellWidth;

                    if(tag != -1 && tag != 0) px[idx].Image = images[tag];
                    px[idx].Tag = tag;
                    px[idx].SizeMode = PictureBoxSizeMode.CenterImage;
                    px[idx].BackColor = Color.Transparent;
                    px[idx].Cursor = Cursors.Hand;

                    px[idx].BringToFront();
                    px[idx].Click += new EventHandler(pictureBoxClickEventhandle);
                    px[idx].MouseHover += new EventHandler(pictureBoxMouseHoverEventhandle);
                    px[idx].MouseLeave += new EventHandler(pictureBoxMouseLeaveEventhandle);

                    pictureBoxes.Add(px[idx]);

                    gamePanel.Controls.Add(px[idx]);

                    if ((int)px[idx].Tag == 0)
                    {
                        px[idx].Dispose();
                    }
                }
            }
        }
        public void SaveHighScore(int highScore)
        {
            Properties.Settings.Default.HighScore = highScore;
            Properties.Settings.Default.Save();
        }

        public int LoadHighScore()
        {
            return Properties.Settings.Default.HighScore;
        }
    }
}
