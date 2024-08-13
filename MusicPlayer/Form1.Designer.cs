namespace MusicPlayer
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
            components = new System.ComponentModel.Container();
            labelArtist = new Label();
            labelTitle = new Label();
            pictureBoxAlbum = new PictureBox();
            trackBarVolume = new TrackBar();
            textBoxFilter = new TextBox();
            panel2 = new Panel();
            buttonShuffle = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            buttonLoopMode = new FontAwesome.Sharp.IconButton();
            buttonPrevious = new FontAwesome.Sharp.IconButton();
            buttonNext = new FontAwesome.Sharp.IconButton();
            buttonPlayPause = new FontAwesome.Sharp.IconButton();
            labelMinDuration = new Label();
            labelMaxDuration = new Label();
            buttonSelectFolder = new FontAwesome.Sharp.IconButton();
            progressBarMusic = new ProgressBar();
            listBoxSongs = new ListBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressTimer = new System.Windows.Forms.Timer(components);
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlbum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // labelArtist
            // 
            labelArtist.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelArtist.ForeColor = Color.White;
            labelArtist.Location = new Point(163, 88);
            labelArtist.Name = "labelArtist";
            labelArtist.Size = new Size(877, 32);
            labelArtist.TabIndex = 9;
            labelArtist.Text = "Artist";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(163, 37);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(97, 38);
            labelTitle.TabIndex = 10;
            labelTitle.Text = "Title";
            // 
            // pictureBoxAlbum
            // 
            pictureBoxAlbum.BackColor = Color.FromArgb(155, 233, 255);
            pictureBoxAlbum.Dock = DockStyle.Left;
            pictureBoxAlbum.Location = new Point(0, 0);
            pictureBoxAlbum.Name = "pictureBoxAlbum";
            pictureBoxAlbum.Size = new Size(150, 150);
            pictureBoxAlbum.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAlbum.TabIndex = 11;
            pictureBoxAlbum.TabStop = false;
            // 
            // trackBarVolume
            // 
            trackBarVolume.AutoSize = false;
            trackBarVolume.Location = new Point(818, 76);
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(222, 33);
            trackBarVolume.TabIndex = 12;
            // 
            // textBoxFilter
            // 
            textBoxFilter.Location = new Point(750, 121);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(290, 23);
            textBoxFilter.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(39, 55, 68);
            panel2.Controls.Add(textBoxFilter);
            panel2.Controls.Add(pictureBoxAlbum);
            panel2.Controls.Add(labelTitle);
            panel2.Controls.Add(labelArtist);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1052, 150);
            panel2.TabIndex = 18;
            // 
            // buttonShuffle
            // 
            buttonShuffle.BackColor = Color.Transparent;
            buttonShuffle.FlatStyle = FlatStyle.Flat;
            buttonShuffle.ForeColor = Color.FromArgb(32, 45, 53);
            buttonShuffle.IconChar = FontAwesome.Sharp.IconChar.Shuffle;
            buttonShuffle.IconColor = Color.FromArgb(10, 181, 211);
            buttonShuffle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonShuffle.IconSize = 50;
            buttonShuffle.Location = new Point(381, 26);
            buttonShuffle.Name = "buttonShuffle";
            buttonShuffle.Size = new Size(60, 60);
            buttonShuffle.TabIndex = 19;
            buttonShuffle.UseVisualStyleBackColor = false;
            buttonShuffle.Click += buttonShuffle_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(39, 55, 68);
            panel3.Controls.Add(buttonLoopMode);
            panel3.Controls.Add(buttonPrevious);
            panel3.Controls.Add(buttonNext);
            panel3.Controls.Add(buttonPlayPause);
            panel3.Controls.Add(labelMinDuration);
            panel3.Controls.Add(labelMaxDuration);
            panel3.Controls.Add(buttonSelectFolder);
            panel3.Controls.Add(progressBarMusic);
            panel3.Controls.Add(trackBarVolume);
            panel3.Controls.Add(buttonShuffle);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 466);
            panel3.Name = "panel3";
            panel3.Size = new Size(1052, 125);
            panel3.TabIndex = 19;
            // 
            // buttonLoopMode
            // 
            buttonLoopMode.BackColor = Color.Transparent;
            buttonLoopMode.FlatAppearance.BorderSize = 0;
            buttonLoopMode.FlatStyle = FlatStyle.Flat;
            buttonLoopMode.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLoopMode.ForeColor = Color.FromArgb(10, 181, 211);
            buttonLoopMode.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            buttonLoopMode.IconColor = Color.FromArgb(10, 181, 211);
            buttonLoopMode.IconFont = FontAwesome.Sharp.IconFont.Solid;
            buttonLoopMode.IconSize = 50;
            buttonLoopMode.Location = new Point(635, 26);
            buttonLoopMode.Name = "buttonLoopMode";
            buttonLoopMode.Size = new Size(60, 60);
            buttonLoopMode.TabIndex = 26;
            buttonLoopMode.Text = "1";
            buttonLoopMode.UseVisualStyleBackColor = false;
            buttonLoopMode.Click += buttonLoopMode_Click;
            // 
            // buttonPrevious
            // 
            buttonPrevious.BackColor = Color.Transparent;
            buttonPrevious.FlatStyle = FlatStyle.Flat;
            buttonPrevious.ForeColor = Color.FromArgb(32, 45, 53);
            buttonPrevious.IconChar = FontAwesome.Sharp.IconChar.Backward;
            buttonPrevious.IconColor = Color.FromArgb(10, 181, 211);
            buttonPrevious.IconFont = FontAwesome.Sharp.IconFont.Solid;
            buttonPrevious.Location = new Point(447, 31);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(50, 50);
            buttonPrevious.TabIndex = 25;
            buttonPrevious.UseVisualStyleBackColor = false;
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // buttonNext
            // 
            buttonNext.BackColor = Color.Transparent;
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.ForeColor = Color.FromArgb(32, 45, 53);
            buttonNext.IconChar = FontAwesome.Sharp.IconChar.Forward;
            buttonNext.IconColor = Color.FromArgb(10, 181, 211);
            buttonNext.IconFont = FontAwesome.Sharp.IconFont.Solid;
            buttonNext.Location = new Point(579, 31);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(50, 50);
            buttonNext.TabIndex = 24;
            buttonNext.UseVisualStyleBackColor = false;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonPlayPause
            // 
            buttonPlayPause.BackColor = Color.Transparent;
            buttonPlayPause.FlatStyle = FlatStyle.Flat;
            buttonPlayPause.ForeColor = Color.FromArgb(32, 45, 53);
            buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Play;
            buttonPlayPause.IconColor = Color.FromArgb(10, 181, 211);
            buttonPlayPause.IconFont = FontAwesome.Sharp.IconFont.Solid;
            buttonPlayPause.Location = new Point(503, 21);
            buttonPlayPause.Name = "buttonPlayPause";
            buttonPlayPause.Size = new Size(70, 70);
            buttonPlayPause.TabIndex = 23;
            buttonPlayPause.UseVisualStyleBackColor = false;
            buttonPlayPause.Click += buttonPlayPause_Click;
            // 
            // labelMinDuration
            // 
            labelMinDuration.AutoSize = true;
            labelMinDuration.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMinDuration.ForeColor = Color.White;
            labelMinDuration.Location = new Point(294, 91);
            labelMinDuration.Name = "labelMinDuration";
            labelMinDuration.Size = new Size(55, 18);
            labelMinDuration.TabIndex = 22;
            labelMinDuration.Text = "00:00";
            // 
            // labelMaxDuration
            // 
            labelMaxDuration.AutoSize = true;
            labelMaxDuration.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMaxDuration.ForeColor = Color.White;
            labelMaxDuration.Location = new Point(726, 91);
            labelMaxDuration.Name = "labelMaxDuration";
            labelMaxDuration.Size = new Size(55, 18);
            labelMaxDuration.TabIndex = 14;
            labelMaxDuration.Text = "00:00";
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.BackColor = Color.Transparent;
            buttonSelectFolder.FlatStyle = FlatStyle.Flat;
            buttonSelectFolder.ForeColor = Color.FromArgb(32, 45, 53);
            buttonSelectFolder.IconChar = FontAwesome.Sharp.IconChar.FolderBlank;
            buttonSelectFolder.IconColor = Color.FromArgb(10, 181, 211);
            buttonSelectFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonSelectFolder.Location = new Point(22, 35);
            buttonSelectFolder.Name = "buttonSelectFolder";
            buttonSelectFolder.Size = new Size(60, 60);
            buttonSelectFolder.TabIndex = 20;
            buttonSelectFolder.UseVisualStyleBackColor = false;
            buttonSelectFolder.Click += buttonSelectFolder_Click;
            // 
            // progressBarMusic
            // 
            progressBarMusic.Location = new Point(358, 97);
            progressBarMusic.Name = "progressBarMusic";
            progressBarMusic.Size = new Size(362, 12);
            progressBarMusic.TabIndex = 20;
            // 
            // listBoxSongs
            // 
            listBoxSongs.BackColor = Color.FromArgb(145, 184, 227);
            listBoxSongs.Dock = DockStyle.Fill;
            listBoxSongs.Font = new Font("Verdana", 12F);
            listBoxSongs.FormattingEnabled = true;
            listBoxSongs.ItemHeight = 18;
            listBoxSongs.Location = new Point(0, 150);
            listBoxSongs.Name = "listBoxSongs";
            listBoxSongs.Size = new Size(1052, 316);
            listBoxSongs.TabIndex = 0;
            listBoxSongs.SelectedIndexChanged += listBoxSongs_SelectedIndexChanged;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(852, 150);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 316);
            panel4.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 45, 53);
            ClientSize = new Size(1052, 591);
            Controls.Add(panel4);
            Controls.Add(listBoxSongs);
            Controls.Add(panel3);
            Controls.Add(panel2);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlbum).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonStop;
        private Label labelArtist;
        private Label labelTitle;
        private PictureBox pictureBoxAlbum;
        private TrackBar trackBarVolume;
        private TextBox textBoxFilter;
        private Panel panel1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton buttonShuffle;
        private Panel panel3;
        private ListBox listBoxSongs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer progressTimer;
        private ProgressBar progressBarMusic;
        private Label labelMaxDuration;
        private FontAwesome.Sharp.IconButton buttonSelectFolder;
        private Label labelMinDuration;
        private FontAwesome.Sharp.IconButton buttonPlayPause;
        private FontAwesome.Sharp.IconButton buttonNext;
        private FontAwesome.Sharp.IconButton buttonPrevious;
        private FontAwesome.Sharp.IconButton buttonLoopMode;
        private Panel panel4;
        private InventorySystem.Controls.CustomButton customButton5;
        private InventorySystem.Controls.CustomButton customButton4;
    }
}
