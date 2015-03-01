using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPP
{
    /// <summary>
    /// The class for a harmful Item representation
    /// </summary>
    public class RedItem : Item
    {
        /// <summary>to count milliseconds passed from the last timestamp</summary>
        public int secondCounter;
        /// <summary>milliseconds between timestamps</summary>
        public int maxSecond;

        /// <summary>
        /// constructor taking initial position
        /// </summary>
        /// <param name="pos">the position to start on</param>
        public RedItem(Point pos)
        {
            position = pos;
            secondCounter = 0;
            maxSecond = 10;
            isHelpful = false;
        }

        /// <summary>
        /// draw the item using pen and on the panel
        /// </summary>
        /// <param name="gPanel">a panel to draw on</param>
        /// <param name="myPen">a tool that sets the drawing behavior</param>
        /// <param name="sizeOfCell">current size of the net's cell</param>
        public override void DrawItem(Pen myPen, Graphics gPanel, int sizeOfCell)
        {
            gPanel.FillRectangle(myPen.Brush, position.X * sizeOfCell, position.Y * sizeOfCell, sizeOfCell, sizeOfCell);
        }
    }
}
