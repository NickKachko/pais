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
    /// <summary>
    /// The class for the main GUI form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>a panel to draw on</summary>
        Graphics gPanel;
        /// <summary>a tool that sets the drawing behavior</summary>
        Pen myPen;
        /// <summary>a gaming area</summary>
        Net myNet;
        /// <summary>an instance of a snake</summary>
        Snake mySnake;
        /// <summary>an entity to generate random numbers</summary>
        Random myRand;
        /// <summary>an useful item</summary>
        BlueItem myItem;
        /// <summary>a harmful item</summary>
        RedItem myBadItem;
        /// <summary>time interval to move the snake within</summary>
        int timerInterval = 400;
        /// <summary>is an item was just added</summary>
        bool isJustAdded = false;
        /// <summary>to determine whether the mouse was pressed</summary>
        bool mouseClicked=false;

        /// <summary>
        /// default constructor for the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// what to do when a form is loading
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            gPanel = pictureBox1.CreateGraphics();
            myNet = new Net(new Point(pictureBox1.Bounds.Width,pictureBox1.Bounds.Height));
            myPen = new Pen(myNet.colorOfNet);
            mySnake = Snake.GetSingleton();
            timer1.Interval = timerInterval;
            myNet.DrawNet(myNet,pictureBox1,myPen,gPanel);
            myRand = new Random();
            myItem = new BlueItem(new Point(myRand.Next(myNet.resolution.X), myRand.Next(myNet.resolution.Y)));
            myBadItem = new RedItem(new Point(myRand.Next(myNet.resolution.X), myRand.Next(myNet.resolution.Y)));
        }
        
        /// <summary>
        /// to track specific key presses
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.Enter) if (!timer1.Enabled) timer1.Start();
            if (e.KeyCode == Keys.Left) if (mySnake.Direction != ArrowDirection.Right) { mySnake.Direction = ArrowDirection.Left; if (trackBar1.Value!=trackBar1.Maximum) trackBar1.Value++; }
            if (e.KeyCode == Keys.Right) if (mySnake.Direction != ArrowDirection.Left) { mySnake.Direction = ArrowDirection.Right; if (trackBar1.Value != trackBar1.Minimum)trackBar1.Value--; }
            if (e.KeyCode == Keys.Up) if (mySnake.Direction != ArrowDirection.Down) { mySnake.Direction = ArrowDirection.Up; if (trackBar1.Value != trackBar1.Maximum)trackBar1.Value++; }
            if (e.KeyCode == Keys.Down) if (mySnake.Direction != ArrowDirection.Up) { mySnake.Direction = ArrowDirection.Down; if (trackBar1.Value != trackBar1.Minimum)trackBar1.Value--; }
        }

        /// <summary>
        /// occurs every tick of the timer
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point temp;

            
            mySnake.Move(myNet.resolution);
            myBadItem.secondCounter++;
            if (myBadItem.secondCounter >= myBadItem.maxSecond)
            {
                myBadItem = new RedItem(new Point(myRand.Next(myNet.resolution.X), myRand.Next(myNet.resolution.Y)));
                myBadItem.secondCounter = 0;
            }
            if (mySnake.position[0] == myItem.position)
            {
                    mySnake.Add();
                    myItem = new BlueItem(new Point(myRand.Next(myNet.resolution.X), myRand.Next(myNet.resolution.Y)));
                    isJustAdded = true;
            }
            DrawAll();
            temp = mySnake.position[0];
            mySnake.position.Remove(mySnake.position[0]);
            if (!isJustAdded)
                if (mySnake.position.Contains(temp))
                    this.Close();
            mySnake.position.Insert(0, temp);
            isJustAdded = false;
            if (mySnake.position[0] == myBadItem.position)
                this.Close();
        }
        
        /// <summary>
        /// draw all items on the form
        /// </summary>
        private void DrawAll()
        {
            gPanel.Clear(SystemColors.Control);
            myNet.DrawNet(myNet, pictureBox1, myPen, gPanel);
            mySnake.DrawSnake(gPanel, myPen, myNet.sizeOfCell);
            myItem.DrawItem(new Pen(Color.Blue), gPanel, myNet.sizeOfCell);
            myBadItem.DrawItem(new Pen(Color.Red), gPanel, myNet.sizeOfCell);
        }

        /// <summary>
        /// what to do if an exit tool was clicked
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// when a track bar value is changed
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (mouseClicked) timer1.Interval = trackBar1.Value * 100;
            //this.pictureBox1.Focus();
        }

        /// <summary>
        /// delegate keypresses on the track bar to the form
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void trackBar1_KeyDown(object sender, KeyEventArgs e)
        {
            Form1_KeyDown(sender, e);
        }

        /// <summary>
        /// to set up a bool flag
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
        }

        /// <summary>
        /// to set off a bool flag
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
        }

        /// <summary>
        /// what to do if a help tool was clicked
        /// </summary>
        /// <param name="sender">object that caused event</param>
        /// <param name="e">event parameters</param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 Temp = new AboutBox1();
            Temp.Show();
        }
    }

    /// <summary>
    /// This is a main namespace to develop a projects in
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
    }

}
