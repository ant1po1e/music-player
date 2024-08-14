using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Controls
{
    public class CustomTrackBar : Control
    {
        private int minValue = 0;
        private int maxValue = 100;
        private int currentValue = 50;

        private bool isDragging = false;

        public int Minimum
        {
            get { return minValue; }
            set
            {
                minValue = value;
                Invalidate(); // Redraw control when property changes
            }
        }

        public int Maximum
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                Invalidate();
            }
        }

        public int Value
        {
            get { return currentValue; }
            set
            {
                currentValue = Math.Max(minValue, Math.Min(maxValue, value));
                Invalidate();
                OnValueChanged(EventArgs.Empty);
            }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        public CustomTrackBar()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            this.MinimumSize = new Size(50, 20);
            this.MaximumSize = new Size(1000, 20);
            this.Size = new Size(200, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw track line
            Rectangle trackLineRect = new Rectangle(0, this.Height / 2 - 2, this.Width, 4);
            g.FillRectangle(Brushes.Gray, trackLineRect);

            // Draw thumb
            float thumbPos = (float)(currentValue - minValue) / (maxValue - minValue) * this.Width;
            Rectangle thumbRect = new Rectangle((int)thumbPos - 7, this.Height / 2 - 7, 14, 14);
            g.FillEllipse(Brushes.DodgerBlue, thumbRect);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                UpdateValueFromMouse(e.X);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                UpdateValueFromMouse(e.X);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void UpdateValueFromMouse(int mouseX)
        {
            float percentage = Math.Max(0, Math.Min(1, (float)mouseX / this.Width));
            Value = (int)(minValue + percentage * (maxValue - minValue));
        }
    }
}