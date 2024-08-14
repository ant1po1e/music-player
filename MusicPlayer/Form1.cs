using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;
using TagLib;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private List<string> songPaths = new List<string>();
        private int currentSongIndex = -1;
        private LoopMode currentLoopMode = LoopMode.NoLoop;
        private Random random = new Random();

        private enum LoopMode
        {
            NoLoop,
            LoopOne,
            LoopAll
        }

        public Form1()
        {
            InitializeComponent();
            player.PlayStateChange += Player_PlayStateChange;
            listBoxSongs.SelectedIndexChanged += listBoxSongs_SelectedIndexChanged;
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 50;
            player.settings.volume = 50;
            trackBarVolume.ValueChanged += trackBarVolume_ValueChanged;
            textBoxFilter.TextChanged += textBoxFilter_TextChanged;

            progressTimer.Interval = 1000;
            progressTimer.Tick += ProgressTimer_Tick;

            UpdateLoopButtonText();

            string lastSelectedFolder = Properties.Settings.Default.LastSelectedFolder;
            if (Directory.Exists(lastSelectedFolder))
            {
                songPaths = Directory.GetFiles(lastSelectedFolder, "*.mp3").ToList();
                FilterSongs();
            }

            if (Directory.Exists(lastSelectedFolder))
            {
                songPaths = Directory.GetFiles(lastSelectedFolder, "*.mp3").ToList();
                FilterSongs();
            }
            else
            {
                Properties.Settings.Default.LastSelectedFolder = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        #region Events
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                progressBarMusic.Maximum = (int)player.currentMedia.duration;
                progressBarMusic.Value = (int)player.controls.currentPosition;

                TimeSpan currentTime = TimeSpan.FromSeconds(player.controls.currentPosition);
                TimeSpan totalTime = TimeSpan.FromSeconds(player.currentMedia.duration);
                labelMinDuration.Text = $"{currentTime:mm\\:ss}";
                labelMaxDuration.Text = $"{totalTime:mm\\:ss}";
            }
        }

        private void buttonLoopMode_Click(object sender, EventArgs e)
        {
            currentLoopMode = (LoopMode)(((int)currentLoopMode + 1) % 3);
            UpdateLoopButtonText();
        }

        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            player.settings.volume = trackBarVolume.Value;
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            FilterSongs();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.LastSelectedFolder = folderBrowser.SelectedPath;
                    Properties.Settings.Default.Save(); // Save the path to settings
                    songPaths = Directory.GetFiles(folderBrowser.SelectedPath, "*.mp3").ToList();
                    FilterSongs();
                }
            }
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
                buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Play;
            }
            else
            {
                if (currentSongIndex == -1 && listBoxSongs.Items.Count > 0)
                {
                    currentSongIndex = 0;
                }
                if (player.playState == WMPPlayState.wmppsPaused &&
                    player.URL == songPaths[currentSongIndex])
                {
                    player.controls.play();
                }
                else
                {
                    PlayCurrentSong();
                }
                buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            PlayNextSong();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            PlayPreviousSong();
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            if (songPaths.Count > 0)
            {
                currentSongIndex = random.Next(0, songPaths.Count);
                PlayCurrentSong();
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSongs.SelectedIndex >= 0)
            {
                if (currentSongIndex != listBoxSongs.SelectedIndex)
                {
                    currentSongIndex = listBoxSongs.SelectedIndex;
                    UpdateSongInfo();
                    PlayCurrentSong();

                    player.controls.play();

                    progressBarMusic.Value = 0;
                    labelMinDuration.Text = "00:00";
                    labelMaxDuration.Text = "00:00";

                    buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Play;
                }
            }
        }
        #endregion

        #region Functions
        private void UpdateLoopButtonText()
        {
            switch (currentLoopMode)
            {
                case LoopMode.NoLoop:
                    buttonLoopMode.Text = "X";
                    break;
                case LoopMode.LoopOne:
                    buttonLoopMode.Text = "1";
                    break;
                case LoopMode.LoopAll:
                    buttonLoopMode.Text = "";
                    break;
            }
        }

        private void FilterSongs()
        {
            listBoxSongs.Items.Clear();
            string filter = textBoxFilter.Text.ToLower();
            var filteredSongs = songPaths
                .Where(path => Path.GetFileNameWithoutExtension(path).ToLower().Contains(filter))
                .Select(Path.GetFileName)
                .ToArray();
            listBoxSongs.Items.AddRange(filteredSongs);
        }

        private void PlayCurrentSong()
        {
            if (currentSongIndex >= 0 && currentSongIndex < songPaths.Count)
            {
                player.URL = songPaths[currentSongIndex];
                player.controls.play();
                listBoxSongs.SelectedIndex = currentSongIndex;
                UpdateSongInfo();
                progressTimer.Start();
                buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
            }
        }

        private void PlayNextSong()
        {
            if (currentSongIndex >= songPaths.Count - 1)
            {
                currentSongIndex = 0;
            }
            else
            {
                currentSongIndex++;
            }
            PlayCurrentSong();
        }

        private void PlayPreviousSong()
        {
            if (currentSongIndex == 0)
            {
                currentSongIndex = songPaths.Count - 1;
            }
            else
            {
                currentSongIndex--;
            }
            PlayCurrentSong();
        }

        private void PlayNextLoop()
        {
            if (currentSongIndex >= songPaths.Count - 1)
            {
                currentSongIndex = 0;
            }
            else
            {
                currentSongIndex++;
            }
            listBoxSongs.SelectedIndex = currentSongIndex;
            buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
            UpdateSongInfo();
            player.controls.play();
        }

        private void UpdateSongInfo()
        {
            if (currentSongIndex >= 0 && currentSongIndex < songPaths.Count)
            {
                string currentSongPath = songPaths[currentSongIndex];
                using (var file = TagLib.File.Create(currentSongPath))
                {
                    labelTitle.Text = file.Tag.Title ?? Path.GetFileNameWithoutExtension(currentSongPath);
                    labelArtist.Text = file.Tag.FirstPerformer ?? "Unknown Artist";

                    if (file.Tag.Pictures.Length > 0)
                    {
                        var bin = file.Tag.Pictures[0].Data.Data;
                        using (var ms = new MemoryStream(bin))
                        {
                            pictureBoxAlbum.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBoxAlbum.Image = null;
                    }
                }
            }
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPPlayState)NewState == WMPPlayState.wmppsStopped)
            {
                progressTimer.Stop();
                progressBarMusic.Value = 0;
                labelMinDuration.Text = "00:00";
                labelMaxDuration.Text = "00:00";
                buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Play;

                switch (currentLoopMode)
                {
                    case LoopMode.LoopOne:
                        player.controls.currentPosition = 0;
                        player.controls.play();
                        break;
                    case LoopMode.LoopAll:
                        PlayNextLoop();
                        break;
                    case LoopMode.NoLoop:
                    default:
                        // Do nothing, let the playback stop
                        break;
                }
            }
            else if ((WMPPlayState)NewState == WMPPlayState.wmppsPlaying)
            {
                progressTimer.Start();
                buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
            }
            else if ((WMPPlayState)NewState == WMPPlayState.wmppsPaused)
            {
                progressTimer.Stop();
                buttonPlayPause.IconChar = FontAwesome.Sharp.IconChar.Play;
            }
        }
        #endregion
    }
}