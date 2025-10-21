using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeatherApp
{
    public partial class ProgressBar: Form
    {
        private System.Windows.Forms.Timer timer;
        private int progress = 0;
        private string[] funnyMessages = new string[]
        {
            "Fetching satellite imagery...",
            "Analyzing cloud density...",
            "Calibrating barometric pressure sensors...",
            "Measuring wind vectors...",
            "Cross-referencing Doppler radar...",
            "Normalizing humidity datasets...",
            "Enhancing infrared spectrum data...",
            "Running machine learning on raindrops...",
            "Finalizing precipitation probabilities...",
            "Rendering high-resolution forecast model..."
        };

        public ProgressBar()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progress <= 100)
            {
                progressBar1.Value = progress;
                int msgIndex = Math.Min(progress / 10, funnyMessages.Length - 1);
                label1.Text = funnyMessages[msgIndex];
                progress++;
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Idk, just look outside", "Weather Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
