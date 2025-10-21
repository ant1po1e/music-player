namespace SpecMusicPlayer
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
            openButton = new InventorySystem.Controls.CustomButton();
            playPauseButton = new InventorySystem.Controls.CustomButton();
            backwardButton = new InventorySystem.Controls.CustomButton();
            nextButton = new InventorySystem.Controls.CustomButton();
            modeButton = new InventorySystem.Controls.CustomButton();
            sensitivityBar = new TrackBar();
            volumeBar = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)sensitivityBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
            SuspendLayout();
            // 
            // openButton
            // 
            openButton.BackColor = Color.Black;
            openButton.BackgroundColor = Color.Black;
            openButton.BorderColor = Color.White;
            openButton.BorderRadius = 20;
            openButton.BorderSize = 2;
            openButton.FlatAppearance.BorderSize = 0;
            openButton.FlatStyle = FlatStyle.Flat;
            openButton.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            openButton.ForeColor = Color.White;
            openButton.Location = new Point(12, 12);
            openButton.Name = "openButton";
            openButton.Size = new Size(90, 38);
            openButton.TabIndex = 0;
            openButton.Text = "Open";
            openButton.TextColor = Color.White;
            openButton.UseVisualStyleBackColor = false;
            openButton.Click += BtnOpen_Click;
            // 
            // playPauseButton
            // 
            playPauseButton.BackColor = Color.Black;
            playPauseButton.BackgroundColor = Color.Black;
            playPauseButton.BorderColor = Color.White;
            playPauseButton.BorderRadius = 20;
            playPauseButton.BorderSize = 2;
            playPauseButton.FlatAppearance.BorderSize = 0;
            playPauseButton.FlatStyle = FlatStyle.Flat;
            playPauseButton.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playPauseButton.ForeColor = Color.White;
            playPauseButton.Location = new Point(108, 12);
            playPauseButton.Name = "playPauseButton";
            playPauseButton.Size = new Size(90, 38);
            playPauseButton.TabIndex = 1;
            playPauseButton.Text = "Play";
            playPauseButton.TextColor = Color.White;
            playPauseButton.UseVisualStyleBackColor = false;
            playPauseButton.Click += BtnPlayPause_Click;
            // 
            // backwardButton
            // 
            backwardButton.BackColor = Color.Black;
            backwardButton.BackgroundColor = Color.Black;
            backwardButton.BorderColor = Color.White;
            backwardButton.BorderRadius = 20;
            backwardButton.BorderSize = 2;
            backwardButton.FlatAppearance.BorderSize = 0;
            backwardButton.FlatStyle = FlatStyle.Flat;
            backwardButton.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backwardButton.ForeColor = Color.White;
            backwardButton.Location = new Point(204, 12);
            backwardButton.Name = "backwardButton";
            backwardButton.Size = new Size(90, 38);
            backwardButton.TabIndex = 2;
            backwardButton.Text = "<<";
            backwardButton.TextColor = Color.White;
            backwardButton.UseVisualStyleBackColor = false;
            backwardButton.Click += BtnBackward_Click;
            // 
            // nextButton
            // 
            nextButton.BackColor = Color.Black;
            nextButton.BackgroundColor = Color.Black;
            nextButton.BorderColor = Color.White;
            nextButton.BorderRadius = 20;
            nextButton.BorderSize = 2;
            nextButton.FlatAppearance.BorderSize = 0;
            nextButton.FlatStyle = FlatStyle.Flat;
            nextButton.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nextButton.ForeColor = Color.White;
            nextButton.Location = new Point(300, 12);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(90, 38);
            nextButton.TabIndex = 3;
            nextButton.Text = ">>";
            nextButton.TextColor = Color.White;
            nextButton.UseVisualStyleBackColor = false;
            nextButton.Click += BtnForward_Click;
            // 
            // modeButton
            // 
            modeButton.BackColor = Color.Black;
            modeButton.BackgroundColor = Color.Black;
            modeButton.BorderColor = Color.White;
            modeButton.BorderRadius = 20;
            modeButton.BorderSize = 2;
            modeButton.FlatAppearance.BorderSize = 0;
            modeButton.FlatStyle = FlatStyle.Flat;
            modeButton.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            modeButton.ForeColor = Color.White;
            modeButton.Location = new Point(396, 12);
            modeButton.Name = "modeButton";
            modeButton.Size = new Size(130, 38);
            modeButton.TabIndex = 4;
            modeButton.Text = "Mode: Bars";
            modeButton.TextColor = Color.White;
            modeButton.UseVisualStyleBackColor = false;
            modeButton.Click += ModeButton_Click;
            // 
            // sensitivityBar
            // 
            sensitivityBar.AutoSize = false;
            sensitivityBar.Location = new Point(532, 12);
            sensitivityBar.Maximum = 10000;
            sensitivityBar.Minimum = 100;
            sensitivityBar.Name = "sensitivityBar";
            sensitivityBar.Size = new Size(182, 38);
            sensitivityBar.TabIndex = 5;
            sensitivityBar.TickStyle = TickStyle.None;
            sensitivityBar.Value = 100;
            sensitivityBar.Scroll += SensitivityBar_Scroll;
            // 
            // volumeBar
            // 
            volumeBar.AutoSize = false;
            volumeBar.Location = new Point(720, 12);
            volumeBar.Maximum = 100;
            volumeBar.Name = "volumeBar";
            volumeBar.Size = new Size(182, 38);
            volumeBar.TabIndex = 6;
            volumeBar.TickStyle = TickStyle.None;
            volumeBar.Value = 100;
            volumeBar.Scroll += VolumeBar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(575, 40);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 7;
            label1.Text = "Sensitivity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(774, 40);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 8;
            label2.Text = "Volume";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(909, 553);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(volumeBar);
            Controls.Add(sensitivityBar);
            Controls.Add(modeButton);
            Controls.Add(nextButton);
            Controls.Add(backwardButton);
            Controls.Add(playPauseButton);
            Controls.Add(openButton);
            MinimumSize = new Size(927, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Spec Music Player";
            ((System.ComponentModel.ISupportInitialize)sensitivityBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private InventorySystem.Controls.CustomButton openButton;
        private InventorySystem.Controls.CustomButton playPauseButton;
        private InventorySystem.Controls.CustomButton backwardButton;
        private InventorySystem.Controls.CustomButton nextButton;
        private InventorySystem.Controls.CustomButton modeButton;
        private TrackBar sensitivityBar;
        private TrackBar volumeBar;
        private Label label1;
        private Label label2;
    }
}
