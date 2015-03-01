using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSPP
{
    public partial class Form1 : Form
    {
        Graphics gPanel;
        Pen MyPen;
        Net MyNet;
        Snake MySnake;
        Random MyRand;
        BlueItem MyItem;
        RedItem MyBadItem;
        int TimerInterval=400;
        bool IsJustAdded=false;
        bool MouseClicked=false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gPanel = pictureBox1.CreateGraphics();
            MyNet = new Net(new Point(pictureBox1.Bounds.Width,pictureBox1.Bounds.Height));
            MyPen = new Pen(MyNet.ColorofNet);
            MySnake = Snake.GetSingleton();
            timer1.Interval = TimerInterval;
            MyNet.DrawNet(MyNet,pictureBox1,MyPen,gPanel);
            MyRand = new Random();
            MyItem = new BlueItem(new Point(MyRand.Next(MyNet.Resolution.X), MyRand.Next(MyNet.Resolution.Y)));
            MyBadItem = new RedItem(new Point(MyRand.Next(MyNet.Resolution.X), MyRand.Next(MyNet.Resolution.Y)));
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.Enter) if (!timer1.Enabled) timer1.Start();
            if (e.KeyCode == Keys.Left) if (MySnake.Direction != ArrowDirection.Right) { MySnake.Direction = ArrowDirection.Left; if (trackBar1.Value!=trackBar1.Maximum) trackBar1.Value++; }
            if (e.KeyCode == Keys.Right) if (MySnake.Direction != ArrowDirection.Left) { MySnake.Direction = ArrowDirection.Right; if (trackBar1.Value != trackBar1.Minimum)trackBar1.Value--; }
            if (e.KeyCode == Keys.Up) if (MySnake.Direction != ArrowDirection.Down) { MySnake.Direction = ArrowDirection.Up; if (trackBar1.Value != trackBar1.Maximum)trackBar1.Value++; }
            if (e.KeyCode == Keys.Down) if (MySnake.Direction != ArrowDirection.Up) { MySnake.Direction = ArrowDirection.Down; if (trackBar1.Value != trackBar1.Minimum)trackBar1.Value--; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point temp;

            
            MySnake.Move(MyNet.Resolution);
            MyBadItem.SecondCounter++;
            if (MyBadItem.SecondCounter >= MyBadItem.MaxSecond)
            {
                MyBadItem = new RedItem(new Point(MyRand.Next(MyNet.Resolution.X), MyRand.Next(MyNet.Resolution.Y)));
                MyBadItem.SecondCounter = 0;
            }
            if (MySnake.Position[0] == MyItem.Position)
            {
                    MySnake.Add();
                    MyItem = new BlueItem(new Point(MyRand.Next(MyNet.Resolution.X), MyRand.Next(MyNet.Resolution.Y)));
                    IsJustAdded = true;
            }
            DrawAll();
            temp = MySnake.Position[0];
            MySnake.Position.Remove(MySnake.Position[0]);
            if (!IsJustAdded)
                if (MySnake.Position.Contains(temp))
                    this.Close();
            MySnake.Position.Insert(0, temp);
            IsJustAdded = false;
            if (MySnake.Position[0] == MyBadItem.Position)
                this.Close();
        }
        
        private void DrawAll()
        {
            gPanel.Clear(SystemColors.Control);
            MyNet.DrawNet(MyNet, pictureBox1, MyPen, gPanel);
            MySnake.DrawSnake(gPanel, MyPen, MyNet.SizeofCell);
            MyItem.DrawItem(new Pen(Color.Blue), gPanel, MyNet.SizeofCell);
            MyBadItem.DrawItem(new Pen(Color.Red), gPanel, MyNet.SizeofCell);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (MouseClicked) timer1.Interval = trackBar1.Value * 100;
            //this.pictureBox1.Focus();
        }

        private void trackBar1_KeyDown(object sender, KeyEventArgs e)
        {
            Form1_KeyDown(sender, e);
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseClicked = true;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseClicked = false;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 Temp = new AboutBox1();
            Temp.Show();
        }
    }
}
