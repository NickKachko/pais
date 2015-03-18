using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TSPP
{
    /// <summary>
    /// The class for the net attributes and functions
    /// </summary>
    public class Net
    {
        /// <summary>size of the item cell in pixels</summary>
        public int sizeOfCell { get; private set; }
        /// <summary>color of the net</summary>
        public Color colorOfNet { get; private set; }
        /// <summary>resolution of the net in (itemsX, itemsY)</summary>
        public Point resolution { get; private set; }

        /// <summary>
        /// create an instance using the resolution information
        /// </summary>
        /// <param name="res">resolution</param>
        public Net(Point res)
        {
            sizeOfCell = 50;
            colorOfNet = Color.Black;
            resolution = new Point(res.X / sizeOfCell, res.Y / sizeOfCell);
        }

        /// <summary>
        /// create an instance using the size of the cell data
        /// </summary>
        /// <param name="soc"></param>
        public Net(int soc)
        {
            sizeOfCell = soc;
            colorOfNet = Color.Black;
        }

        /// <summary>
        /// draw the current net within specific picturebox using pen and on the panel
        /// </summary>
        /// <param name="myNet">current instance of the net</param>
        /// <param name="pictureBox1">picturebox where is a panel is placed</param>
        /// <param name="myPen">a tool that sets the drawing behavior</param>
        /// <param name="gPanel">a panel to draw on</param>
        public void DrawNet(Net myNet, PictureBox pictureBox1, Pen myPen, Graphics gPanel)
        {
            for (int i = 0; i <= pictureBox1.Bounds.Width; i += myNet.sizeOfCell)
            {
                gPanel.DrawLine(myPen, i, 0, i, pictureBox1.Bounds.Height);
            }
            for (int i = 0; i <= pictureBox1.Bounds.Height; i += myNet.sizeOfCell)
            {
                gPanel.DrawLine(myPen, 0, i, pictureBox1.Bounds.Width, i);
            }
        }
    }
}
