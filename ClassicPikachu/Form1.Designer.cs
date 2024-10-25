namespace ClassicPikachu
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuPanel = new Panel();
            lblHighScore = new Label();
            btnMusic = new PictureBox();
            btnSound = new PictureBox();
            btnQuit = new PictureBox();
            btnPlay = new PictureBox();
            btnContinue = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnSound).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnQuit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnPlay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnContinue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            menuPanel.Size = new Size(904, 549);
            menuPanel.TabIndex = 0;
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHighScore.ForeColor = Color.FromArgb(240, 181, 65);
            lblHighScore.Location = new Point(328, 161);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(240, 28);
            lblHighScore.TabIndex = 7;
            lblHighScore.Text = "HIGH SCORE: 0";
            lblHighScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMusic
            // 
            btnMusic.Cursor = Cursors.Hand;
            btnMusic.Image = Properties.Resources.music_on;
            btnMusic.Location = new Point(463, 457);
            btnMusic.Name = "btnMusic";
            btnMusic.Size = new Size(64, 64);
            btnMusic.SizeMode = PictureBoxSizeMode.StretchImage;
            btnMusic.TabIndex = 6;
            btnMusic.TabStop = false;
            btnMusic.Click += btnMusic_Click;
            // 
            // btnSound
            // 
            btnSound.Cursor = Cursors.Hand;
            btnSound.Image = Properties.Resources.sound_on;
            btnSound.Location = new Point(377, 457);
            btnSound.Name = "btnSound";
            btnSound.Size = new Size(64, 64);
            btnSound.SizeMode = PictureBoxSizeMode.StretchImage;
            btnSound.TabIndex = 5;
            btnSound.TabStop = false;
            btnSound.Click += btnSound_Click;
            // 
            // btnQuit
            // 
            btnQuit.Cursor = Cursors.Hand;
            btnQuit.Image = (Image)resources.GetObject("btnQuit.Image");
            btnQuit.Location = new Point(377, 366);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(150, 75);
            btnQuit.SizeMode = PictureBoxSizeMode.Zoom;
            btnQuit.TabIndex = 4;
            btnQuit.TabStop = false;
            btnQuit.Click += btnQuit_Click;
            // 
            // btnPlay
            // 
            btnPlay.Cursor = Cursors.Hand;
            btnPlay.Image = (Image)resources.GetObject("btnPlay.Image");
            btnPlay.Location = new Point(377, 285);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(150, 75);
            btnPlay.SizeMode = PictureBoxSizeMode.Zoom;
            btnPlay.TabIndex = 3;
            btnPlay.TabStop = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnContinue
            // 
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.Enabled = false;
            btnContinue.Image = (Image)resources.GetObject("btnContinue.Image");
            btnContinue.Location = new Point(377, 204);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(150, 75);
            btnContinue.SizeMode = PictureBoxSizeMode.Zoom;
            btnContinue.TabIndex = 2;
            btnContinue.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(305, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(291, 128);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(550, 339);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(514, 274);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 549);
            Controls.Add(menuPanel);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Paint += Form1_Paint;
            menuPanel.ResumeLayout(false);
            menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnSound).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnQuit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnPlay).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnContinue).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox btnContinue;
        private PictureBox btnQuit;
        private PictureBox btnPlay;
        private PictureBox btnSound;
        private PictureBox btnMusic;
        private Label lblHighScore;
    }
}
