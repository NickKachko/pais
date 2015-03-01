using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSPP
{
    public class Net
    {
        public int SizeofCell { get; private set; }
        public Color ColorofNet { get; private set; }
        public Point Resolution { get; private set; }
        public Net(Point Res)
        {
            SizeofCell = 50;
            ColorofNet = Color.Black;
            Resolution = new Point(Res.X / SizeofCell, Res.Y / SizeofCell);
        }
        public Net(int SOC)
        {
            SizeofCell = SOC;
            ColorofNet = Color.Black;
        }
        public void DrawNet(Net MyNet, PictureBox pictureBox1, Pen MyPen, Graphics gPanel)
        {
            for (int i = 0; i <= pictureBox1.Bounds.Width; i += MyNet.SizeofCell)
            {
                gPanel.DrawLine(MyPen, i, 0, i, pictureBox1.Bounds.Height);
            }
            for (int i = 0; i <= pictureBox1.Bounds.Height; i += MyNet.SizeofCell)
            {
                gPanel.DrawLine(MyPen, 0, i, pictureBox1.Bounds.Width, i);
            }
        }
    }
}
