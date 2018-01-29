using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;
using System.Windows;


namespace Balloon
{
    public class Balloon
    {
        private int x = 50;
        private int y = 50;
        private int diameter = 20;
        private Ellipse balloon1;

        public Balloon()
        {
            CreateEllipse();
            UpdateEllipse();
        }

        public void MoveRight(int xStep)
        {
            x = x + xStep;
            UpdateEllipse();
        }

        public void Time(DispatcherTimer timer)
        {
            DispatcherTimer Time = new DispatcherTimer();
            Time.Interval = TimeSpan.FromSeconds(1);
            Time.Tick += Time_Tick;
            Time.Start;
        }

        void Time_Tick(object sender, EventArgs e)
        {
            MoveRight(1);
        }

        private void CreateEllipse()
        {
            balloon1 = new Ellipse();
            balloon1.Stroke = new SolidColorBrush(Colors.Blue);
            balloon1.StrokeThickness = 2;
        }

        private void UpdateEllipse()
        {
            balloon1.Margin = new System.Windows.Thickness(x, y, 0, 0);
            balloon1.Width = diameter;
            balloon1.Height = diameter;
        }

        public void DisplayOn(Canvas drawingCanvas)
        {
            drawingCanvas.Children.Add(balloon1);
        }

        public void ChangeSize(int change)
        {
            diameter = diameter + change;
            UpdateEllipse();
        }

        public void Color(Brush brush)
        {
            balloon1.Stroke = Brushes.DarkGoldenrod;
        }
    }
}
