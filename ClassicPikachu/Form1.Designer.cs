namespace ClassicPikachu
{
    partial class PikachuGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PikachuGame));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnContinue = new PictureBox();
            btnPlay = new PictureBox();
            btnQuit = new PictureBox();
            btnSound = new PictureBox();
            btnMusic = new PictureBox();
            lblHighScore = new Label();
            menuPanel = new Panel();
            gamePanel = new Panel();
            btnPause = new PictureBox();
            btnShuffle = new PictureBox();
            lblLevel = new Label();
            progressPlayTime = new ProgressBar();
            lblScore = new Label();
            chooseLevelPanel = new Panel();
            btnBackToMenu = new PictureBox();
            btnHard = new PictureBox();
            btnMedium = new PictureBox();
            btnEasy = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox9 = new PictureBox();
            pausePanel = new Panel();
            btnMenu = new PictureBox();
            label3 = new Label();
            btnMusicPaused = new PictureBox();
            btnSoundPause = new PictureBox();
            btnQuitPaused = new PictureBox();
            pictureBox10 = new PictureBox();
            btnResume = new PictureBox();
            pictureBox13 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnContinue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnPlay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnQuit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnSound).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMusic).BeginInit();
            menuPanel.SuspendLayout();
            gamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnPause).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnShuffle).BeginInit();
            chooseLevelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBackToMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnHard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMedium).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEasy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            pausePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMusicPaused).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnSoundPause).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnQuitPaused).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnResume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(650, 350);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 250);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(350, 20);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(300, 128);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // btnContinue
            // 
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.Image = Properties.Resources.cont;
            btnContinue.Location = new Point(425, 200);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(150, 75);
            btnContinue.SizeMode = PictureBoxSizeMode.Zoom;
            btnContinue.TabIndex = 2;
            btnContinue.TabStop = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnPlay
            // 
            btnPlay.Cursor = Cursors.Hand;
            btnPlay.Image = (Image)resources.GetObject("btnPlay.Image");
            btnPlay.Location = new Point(425, 300);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(150, 75);
            btnPlay.SizeMode = PictureBoxSizeMode.Zoom;
            btnPlay.TabIndex = 3;
            btnPlay.TabStop = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnQuit
            // 
            btnQuit.Cursor = Cursors.Hand;
            btnQuit.Image = (Image)resources.GetObject("btnQuit.Image");
            btnQuit.Location = new Point(425, 400);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(150, 75);
            btnQuit.SizeMode = PictureBoxSizeMode.Zoom;
            btnQuit.TabIndex = 4;
            btnQuit.TabStop = false;
            btnQuit.Click += btnQuit_Click;
            // 
            // btnSound
            // 
            btnSound.Cursor = Cursors.Hand;
            btnSound.Image = Properties.Resources.sound_on;
            btnSound.Location = new Point(425, 500);
            btnSound.Name = "btnSound";
            btnSound.Size = new Size(64, 64);
            btnSound.SizeMode = PictureBoxSizeMode.StretchImage;
            btnSound.TabIndex = 5;
            btnSound.TabStop = false;
            btnSound.Click += btnSound_Click;
            // 
            // btnMusic
            // 
            btnMusic.Cursor = Cursors.Hand;
            btnMusic.Image = Properties.Resources.music_on;
            btnMusic.Location = new Point(511, 500);
            btnMusic.Name = "btnMusic";
            btnMusic.Size = new Size(64, 64);
            btnMusic.SizeMode = PictureBoxSizeMode.StretchImage;
            btnMusic.TabIndex = 6;
            btnMusic.TabStop = false;
            btnMusic.Click += btnMusic_Click;
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHighScore.ForeColor = Color.FromArgb(240, 181, 65);
            lblHighScore.Location = new Point(394, 160);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(212, 31);
            lblHighScore.TabIndex = 7;
            lblHighScore.Text = "HIGH SCORE: 0";
            lblHighScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(64, 73, 115);
            menuPanel.Controls.Add(lblHighScore);
            menuPanel.Controls.Add(btnMusic);
            menuPanel.Controls.Add(btnSound);
            menuPanel.Controls.Add(btnQuit);
            menuPanel.Controls.Add(btnPlay);
            menuPanel.Controls.Add(btnContinue);
            menuPanel.Controls.Add(pictureBox2);
            menuPanel.Controls.Add(pictureBox1);
            menuPanel.Dock = DockStyle.Fill;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(1000, 600);
            menuPanel.TabIndex = 0;
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.FromArgb(64, 73, 115);
            gamePanel.Controls.Add(btnPause);
            gamePanel.Controls.Add(btnShuffle);
            gamePanel.Controls.Add(lblLevel);
            gamePanel.Controls.Add(progressPlayTime);
            gamePanel.Controls.Add(lblScore);
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.Location = new Point(0, 0);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(1000, 600);
            gamePanel.TabIndex = 8;
            gamePanel.Paint += gamePanel_Paint;
            // 
            // btnPause
            // 
            btnPause.Cursor = Cursors.Hand;
            btnPause.Image = (Image)resources.GetObject("btnPause.Image");
            btnPause.Location = new Point(926, 10);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(48, 48);
            btnPause.SizeMode = PictureBoxSizeMode.StretchImage;
            btnPause.TabIndex = 11;
            btnPause.TabStop = false;
            btnPause.Click += btnPause_Click;
            // 
            // btnShuffle
            // 
            btnShuffle.Cursor = Cursors.Hand;
            btnShuffle.Image = (Image)resources.GetObject("btnShuffle.Image");
            btnShuffle.Location = new Point(846, 10);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new Size(48, 48);
            btnShuffle.SizeMode = PictureBoxSizeMode.StretchImage;
            btnShuffle.TabIndex = 10;
            btnShuffle.TabStop = false;
            btnShuffle.Click += btnShuffle_Click;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = Color.FromArgb(240, 181, 65);
            lblLevel.Location = new Point(20, 70);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(145, 28);
            lblLevel.TabIndex = 9;
            lblLevel.Text = "LEVEL: 0";
            lblLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressPlayTime
            // 
            progressPlayTime.Location = new Point(250, 20);
            progressPlayTime.Name = "progressPlayTime";
            progressPlayTime.Size = new Size(500, 29);
            progressPlayTime.TabIndex = 8;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.FromArgb(240, 181, 65);
            lblScore.Location = new Point(20, 21);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(156, 28);
            lblScore.TabIndex = 7;
            lblScore.Text = "SCORE: 0";
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chooseLevelPanel
            // 
            chooseLevelPanel.BackColor = Color.FromArgb(64, 73, 115);
            chooseLevelPanel.Controls.Add(btnBackToMenu);
            chooseLevelPanel.Controls.Add(btnHard);
            chooseLevelPanel.Controls.Add(btnMedium);
            chooseLevelPanel.Controls.Add(btnEasy);
            chooseLevelPanel.Controls.Add(pictureBox8);
            chooseLevelPanel.Controls.Add(pictureBox9);
            chooseLevelPanel.Dock = DockStyle.Fill;
            chooseLevelPanel.Location = new Point(0, 0);
            chooseLevelPanel.Name = "chooseLevelPanel";
            chooseLevelPanel.Size = new Size(1000, 600);
            chooseLevelPanel.TabIndex = 8;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.Cursor = Cursors.Hand;
            btnBackToMenu.Image = (Image)resources.GetObject("btnBackToMenu.Image");
            btnBackToMenu.Location = new Point(35, 500);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(100, 75);
            btnBackToMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            btnBackToMenu.TabIndex = 5;
            btnBackToMenu.TabStop = false;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // btnHard
            // 
            btnHard.Cursor = Cursors.Hand;
            btnHard.Image = (Image)resources.GetObject("btnHard.Image");
            btnHard.Location = new Point(425, 400);
            btnHard.Name = "btnHard";
            btnHard.Size = new Size(150, 75);
            btnHard.SizeMode = PictureBoxSizeMode.Zoom;
            btnHard.TabIndex = 4;
            btnHard.TabStop = false;
            btnHard.Click += btnHard_Click;
            // 
            // btnMedium
            // 
            btnMedium.Cursor = Cursors.Hand;
            btnMedium.Image = (Image)resources.GetObject("btnMedium.Image");
            btnMedium.Location = new Point(425, 300);
            btnMedium.Name = "btnMedium";
            btnMedium.Size = new Size(150, 75);
            btnMedium.SizeMode = PictureBoxSizeMode.Zoom;
            btnMedium.TabIndex = 3;
            btnMedium.TabStop = false;
            btnMedium.Click += btnMedium_Click;
            // 
            // btnEasy
            // 
            btnEasy.Cursor = Cursors.Hand;
            btnEasy.Image = (Image)resources.GetObject("btnEasy.Image");
            btnEasy.Location = new Point(425, 200);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new Size(150, 75);
            btnEasy.SizeMode = PictureBoxSizeMode.Zoom;
            btnEasy.TabIndex = 2;
            btnEasy.TabStop = false;
            btnEasy.Click += btnEasy_Click;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(350, 20);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(300, 128);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 1;
            pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(650, 350);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(500, 250);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 0;
            pictureBox9.TabStop = false;
            // 
            // pausePanel
            // 
            pausePanel.BackColor = Color.FromArgb(64, 73, 115);
            pausePanel.Controls.Add(btnMenu);
            pausePanel.Controls.Add(label3);
            pausePanel.Controls.Add(btnMusicPaused);
            pausePanel.Controls.Add(btnSoundPause);
            pausePanel.Controls.Add(btnQuitPaused);
            pausePanel.Controls.Add(pictureBox10);
            pausePanel.Controls.Add(btnResume);
            pausePanel.Controls.Add(pictureBox13);
            pausePanel.Dock = DockStyle.Fill;
            pausePanel.Location = new Point(0, 0);
            pausePanel.Name = "pausePanel";
            pausePanel.Size = new Size(1000, 600);
            pausePanel.TabIndex = 8;
            // 
            // btnMenu
            // 
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
            btnMenu.Location = new Point(380, 500);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(64, 64);
            btnMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            btnMenu.TabIndex = 8;
            btnMenu.TabStop = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Algerian", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(240, 181, 65);
            label3.Location = new Point(246, 50);
            label3.Name = "label3";
            label3.Size = new Size(512, 134);
            label3.TabIndex = 7;
            label3.Text = "PAUSED";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMusicPaused
            // 
            btnMusicPaused.Cursor = Cursors.Hand;
            btnMusicPaused.Image = Properties.Resources.music_on;
            btnMusicPaused.Location = new Point(556, 500);
            btnMusicPaused.Name = "btnMusicPaused";
            btnMusicPaused.Size = new Size(64, 64);
            btnMusicPaused.SizeMode = PictureBoxSizeMode.StretchImage;
            btnMusicPaused.TabIndex = 6;
            btnMusicPaused.TabStop = false;
            btnMusicPaused.Click += btnMusicPaused_Click;
            // 
            // btnSoundPause
            // 
            btnSoundPause.Cursor = Cursors.Hand;
            btnSoundPause.Image = Properties.Resources.sound_on;
            btnSoundPause.Location = new Point(468, 500);
            btnSoundPause.Name = "btnSoundPause";
            btnSoundPause.Size = new Size(64, 64);
            btnSoundPause.SizeMode = PictureBoxSizeMode.StretchImage;
            btnSoundPause.TabIndex = 5;
            btnSoundPause.TabStop = false;
            btnSoundPause.Click += btnSoundPause_Click;
            // 
            // btnQuitPaused
            // 
            btnQuitPaused.Cursor = Cursors.Hand;
            btnQuitPaused.Image = (Image)resources.GetObject("btnQuitPaused.Image");
            btnQuitPaused.Location = new Point(425, 400);
            btnQuitPaused.Name = "btnQuitPaused";
            btnQuitPaused.Size = new Size(150, 75);
            btnQuitPaused.SizeMode = PictureBoxSizeMode.Zoom;
            btnQuitPaused.TabIndex = 4;
            btnQuitPaused.TabStop = false;
            btnQuitPaused.Click += btnQuitPaused_Click;
            // 
            // pictureBox10
            // 
            pictureBox10.Cursor = Cursors.Hand;
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(425, 300);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(150, 75);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 3;
            pictureBox10.TabStop = false;
            pictureBox10.Click += pictureBox10_Click;
            // 
            // btnResume
            // 
            btnResume.Cursor = Cursors.Hand;
            btnResume.Image = (Image)resources.GetObject("btnResume.Image");
            btnResume.Location = new Point(425, 200);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(150, 75);
            btnResume.SizeMode = PictureBoxSizeMode.Zoom;
            btnResume.TabIndex = 2;
            btnResume.TabStop = false;
            btnResume.Click += btnResume_Click;
            // 
            // pictureBox13
            // 
            pictureBox13.Image = (Image)resources.GetObject("pictureBox13.Image");
            pictureBox13.Location = new Point(650, 350);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(500, 250);
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox13.TabIndex = 0;
            pictureBox13.TabStop = false;
            // 
            // PikachuGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(menuPanel);
            Controls.Add(gamePanel);
            Controls.Add(chooseLevelPanel);
            Controls.Add(pausePanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PikachuGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pikachu";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Paint += Form1_Paint;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnContinue).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnPlay).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnQuit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnSound).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMusic).EndInit();
            menuPanel.ResumeLayout(false);
            menuPanel.PerformLayout();
            gamePanel.ResumeLayout(false);
            gamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnPause).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnShuffle).EndInit();
            chooseLevelPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnBackToMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnHard).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMedium).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEasy).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            pausePanel.ResumeLayout(false);
            pausePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMusicPaused).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnSoundPause).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnQuitPaused).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnResume).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox btnContinue;
        private PictureBox btnPlay;
        private PictureBox btnQuit;
        private PictureBox btnSound;
        private PictureBox btnMusic;
        private Label lblHighScore;
        private Panel menuPanel;
        private Panel gamePanel;
        private Label lblLevel;
        private ProgressBar progressPlayTime;
        private Label lblScore;
        private Panel chooseLevelPanel;
        private PictureBox btnHard;
        private PictureBox btnMedium;
        private PictureBox btnEasy;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox btnBackToMenu;
        private PictureBox btnShuffle;
        private PictureBox btnPause;
        private Panel pausePanel;
        private Label label3;
        private PictureBox btnMusicPaused;
        private PictureBox btnSoundPause;
        private PictureBox btnQuitPaused;
        private PictureBox pictureBox10;
        private PictureBox btnResume;
        private PictureBox pictureBox13;
        private PictureBox btnMenu;
    }
}
