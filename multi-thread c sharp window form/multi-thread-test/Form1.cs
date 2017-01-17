using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading;


namespace multi_thread_test
{
    public partial class Form1 : Form
    {
        TextBlock txt1 = new TextBlock();
        public Form1()
        {
            InitializeComponent();
            Window mainWindow = new Window();

            // Create a canvas sized to fill the window
            Canvas myCanvas = new Canvas();
            myCanvas.Background = System.Windows.Media.Brushes.Brown;

            // Add a "Hello World!" text element to the Canvas
            txt1.FontSize = 14;
            txt1.Text = "Hello World!";
            Canvas.SetTop(txt1, 100);
            Canvas.SetLeft(txt1, 10);
            myCanvas.Children.Add(txt1);

            mainWindow.Content = myCanvas;
            mainWindow.Title = "Canvas Sample";
            mainWindow.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread child = new Thread(new ParameterizedThreadStart(UpdateText));
            child.Start("Updated!");
        }

        private void UpdateText(object str)
        {
            Action<string> actionDelegate = (x) => { this.txt1.Text = x.ToString(); };
            this.txt1.Dispatcher.Invoke(actionDelegate,new object[]{str});
        }
    }
}
