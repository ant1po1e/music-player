using System;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Dsp;

namespace SpecMusicPlayer
{
    public partial class Form1 : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private SampleAggregator aggregator;
        private System.Windows.Forms.Timer timer;
        private bool isPlaying = false;

        private float[] currentHeights = new float[512];
        private const float decaySpeed = 0.8f;
        private float sensitivity = 2000f;

        private VisualizerMode currentMode = VisualizerMode.Bars;
        private float pulseRadius = 0f;

        private bool isNexting = false;

        private string[] audioFiles;
        private int currentTrackIndex = 0;
        private string currentFolderPath;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;

            timer = new System.Windows.Forms.Timer { Interval = 16 };
            timer.Tick += (s, e) =>
            {
                this.Invalidate();
            };


            sensitivityBar.Value = (int)sensitivity;
        }

        private void SensitivityBar_Scroll(object sender, EventArgs e)
        {
            sensitivity = sensitivityBar.Value;
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                audioFile.Volume = volumeBar.Value / 100f;
            }
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            if (currentMode == VisualizerMode.Bars)
            {
                currentMode = VisualizerMode.Circle;
                modeButton.Text = "Mode: Circle";
            }
            else
            {
                currentMode = VisualizerMode.Bars;
                modeButton.Text = "Mode: Bars";
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    currentFolderPath = fbd.SelectedPath;

                    audioFiles = Directory.GetFiles(currentFolderPath, "*.*", SearchOption.TopDirectoryOnly)
                        .Where(f => f.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) ||
                                    f.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
                        .ToArray();

                    if (audioFiles.Length == 0)
                    {
                        MessageBox.Show("Tidak ada file audio dalam folder ini.");
                        return;
                    }

                    currentTrackIndex = 0;
                    PlayTrack(currentTrackIndex);
                }
            }
        }

        private void PlayTrack(int index)
        {
            if (audioFiles == null || audioFiles.Length == 0) return;
            if (index < 0 || index >= audioFiles.Length) index = 0;

            isNexting = false;

            if (outputDevice != null)
            {
                outputDevice.PlaybackStopped -= OnPlaybackStopped;
                outputDevice.Stop();
                outputDevice.Dispose();
            }
            audioFile?.Dispose();

            string file = audioFiles[index];
            audioFile = new AudioFileReader(file);

            audioFile.Volume = volumeBar.Value / 100f;
            aggregator = new SampleAggregator(audioFile);

            outputDevice = new WaveOutEvent();
            outputDevice.Init(aggregator);
            outputDevice.PlaybackStopped += OnPlaybackStopped;

            outputDevice.Play();
            isPlaying = true;
            timer.Start();
            playPauseButton.Text = "Pause";

            this.Text = $"Spec Music Player | Now Playing: {Path.GetFileName(file)}";
        }

        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (!isNexting)
            {
                isNexting = true;
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(NextTrack));
                }
            }
        }


        private void NextTrack()
        {
            currentTrackIndex++;
            if (currentTrackIndex >= audioFiles.Length)
                currentTrackIndex = 0; 
            PlayTrack(currentTrackIndex);
        }

        private void PrevTrack()
        {
            currentTrackIndex--;
            if (currentTrackIndex < 0)
                currentTrackIndex = audioFiles.Length - 1;
            PlayTrack(currentTrackIndex);
        }

        private void BtnPlayPause_Click(object sender, EventArgs e)
        {
            if (outputDevice == null) return;

            if (!isPlaying)
            {
                outputDevice.Play();
                isPlaying = true;
                timer.Start();
                playPauseButton.Text = "Pause";
            }
            else
            {
                outputDevice.Pause();
                isPlaying = false;
                timer.Stop();
                playPauseButton.Text = "Play";
            }
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            if (audioFiles != null && audioFiles.Length > 1)
                NextTrack();
        }

        private void BtnBackward_Click(object sender, EventArgs e)
        {
            if (audioFiles != null && audioFiles.Length > 1)
                PrevTrack();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!isPlaying || aggregator == null) return;

            using (BufferedGraphicsContext bgc = new BufferedGraphicsContext())
            using (BufferedGraphics bg = bgc.Allocate(e.Graphics, this.ClientRectangle))
            {
                var g = bg.Graphics;
                g.Clear(Color.Black);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                float[] fft = aggregator.GetFFTData();
                int barWidth = 6;
                int halfWidth = this.ClientSize.Width / 2;
                int barCount = Math.Min(fft.Length / 2, halfWidth / barWidth);
                if (currentHeights.Length != barCount)
                    currentHeights = new float[barCount];

                if (currentMode == VisualizerMode.Bars)
                    DrawBarsMode(g, fft, barCount, barWidth, halfWidth);
                else
                    DrawCircleMode(g, fft, barCount);

                bg.Render(e.Graphics);
            }
        }

        private void DrawBarsMode(Graphics g, float[] fft, int barCount, int barWidth, int halfWidth)
        {
            for (int i = 0; i < barCount; i++)
            {
                double magnitude = Math.Sqrt(fft[i] * fft[i]);
                magnitude *= sensitivity;

                int targetHeight = (int)(Math.Log10(magnitude + 1) * (this.ClientSize.Height * 0.9));
                targetHeight = Math.Max(2, Math.Min(this.ClientSize.Height, targetHeight));

                currentHeights[i] = currentHeights[i] * decaySpeed + targetHeight * (1 - decaySpeed);
                int barHeight = (int)currentHeights[i];

                Color c1 = Color.FromArgb(0, 180, 255);
                Color c2 = Color.FromArgb(255, 50, 180);

                Rectangle rightRect = new Rectangle(halfWidth + (i * barWidth),
                    this.ClientSize.Height - barHeight, barWidth - 2, barHeight);
                Rectangle leftRect = new Rectangle(halfWidth - ((i + 1) * barWidth),
                    this.ClientSize.Height - barHeight, barWidth - 2, barHeight);

                if (barHeight <= 0) continue;

                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(rightRect, c1, c2, 90f))
                {
                    g.FillRectangle(brush, rightRect);
                    g.FillRectangle(brush, leftRect);
                }
            }
        }

        private void DrawCircleMode(Graphics g, float[] fft, int barCount)
        {
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;
            float baseRadius = Math.Min(centerX, centerY) * 0.4f;

            float bassEnergy = 0;
            for (int i = 0; i < 20 && i < fft.Length; i++)
                bassEnergy += fft[i];
            bassEnergy = bassEnergy / 20f;
            pulseRadius = pulseRadius * 0.9f + (bassEnergy * sensitivity * 0.1f);

            float radius = baseRadius + pulseRadius;
            float angleStep = 360f / barCount;

            float hueShift = (Environment.TickCount % 5000) / 5000f;
            for (int i = 0; i < barCount; i++)
            {
                double magnitude = Math.Sqrt(fft[i] * fft[i]);
                magnitude *= sensitivity;
                int targetHeight = (int)(Math.Log10(magnitude + 1) * 300);
                targetHeight = Math.Max(2, targetHeight);

                currentHeights[i] = currentHeights[i] * decaySpeed + targetHeight * (1 - decaySpeed);
                float barHeight = currentHeights[i];

                float angle = (float)(i * angleStep * Math.PI / 180f);
                float x1 = centerX + (float)Math.Cos(angle) * radius;
                float y1 = centerY + (float)Math.Sin(angle) * radius;
                float x2 = centerX + (float)Math.Cos(angle) * (radius + barHeight);
                float y2 = centerY + (float)Math.Sin(angle) * (radius + barHeight);

                Color mainColor = HsvToColor((hueShift + i / (float)barCount) % 1f, 1f, 1f);
                Color glowColor = Color.FromArgb(50, mainColor);

                using (var glowPen = new Pen(glowColor, 8))
                using (var mainPen = new Pen(mainColor, 2))
                {
                    g.DrawLine(glowPen, x1, y1, x2, y2);
                    g.DrawLine(mainPen, x1, y1, x2, y2);
                }
            }
        }

        private Color HsvToColor(float h, float s, float v)
        {
            int hi = Convert.ToInt32(Math.Floor(h * 6)) % 6;
            float f = h * 6 - hi;
            int vInt = (int)(v * 255);
            int p = (int)(v * (1 - s) * 255);
            int q = (int)(v * (1 - f * s) * 255);
            int t = (int)(v * (1 - (1 - f) * s) * 255);
            return hi switch
            {
                0 => Color.FromArgb(vInt, t, p),
                1 => Color.FromArgb(q, vInt, p),
                2 => Color.FromArgb(p, vInt, t),
                3 => Color.FromArgb(p, q, vInt),
                4 => Color.FromArgb(t, p, vInt),
                _ => Color.FromArgb(vInt, p, q)
            };
        }
    }

    public enum VisualizerMode
    {
        Bars,
        Circle
    }

    public class SampleAggregator : ISampleProvider
    {
        private readonly ISampleProvider source;
        private readonly Complex[] fftBuffer = new Complex[1024];
        private readonly float[] fftMagnitudes = new float[1024];
        private int fftPos;

        public SampleAggregator(ISampleProvider source)
        {
            this.source = source;
        }

        public WaveFormat WaveFormat => source.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = source.Read(buffer, offset, count);
            if (samplesRead == 0)
                return 0;

            for (int i = 0; i < samplesRead; i++)
            {
                fftBuffer[fftPos].X = (float)(buffer[offset + i] * FastFourierTransform.HammingWindow(i, 1024));
                fftBuffer[fftPos].Y = 0;
                fftPos++;

                if (fftPos >= 1024)
                {
                    FastFourierTransform.FFT(true, 10, fftBuffer);
                    for (int j = 0; j < 1024; j++)
                        fftMagnitudes[j] = (float)Math.Sqrt(
                            fftBuffer[j].X * fftBuffer[j].X +
                            fftBuffer[j].Y * fftBuffer[j].Y);
                    fftPos = 0;
                }
            }

            return samplesRead;
        }

        public float[] GetFFTData() => fftMagnitudes;
    }
}
