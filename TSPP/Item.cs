using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPP
{
    /// <summary>
    /// The class for generic Item representation
    /// </summary>
    public class Item
    {
        /// <summary>position of the item</summary>
        private Point varPosition;
        /// <summary>is the item helpful</summary>
        public bool isHelpful;
        /// <summary>position of the item (property)</summary>
        public Point position
        {
            get
            {
                return varPosition;
            }
            set
            {
                varPosition = value;
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public Item()
        { }

        /// <summary>
        /// constructor with a parameter
        /// </summary>
        /// <param name="Pos">initial position of the item</param>
        public Item(Point Pos)
        {
        }

        /// <summary>
        /// draw the item using pen and on the panel
        /// </summary>
        /// <param name="gPanel">a panel to draw on</param>
        /// <param name="myPen">a tool that sets the drawing behavior</param>
        /// <param name="sizeOfCell">current size of the net's cell</param>
        public virtual void DrawItem(Pen myPen, Graphics gPanel, int sizeOfCell)
        {
        }
    }
}
