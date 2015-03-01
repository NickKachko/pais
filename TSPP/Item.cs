using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPP
{
    public class Item
    {
        private Point varPosition;
        public bool IsHelpful;
        public Point Position
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

        public Item()
        { }

        public Item(Point Pos)
        {
        }

        public virtual void DrawItem(Pen MyPen, Graphics gPanel, int SizeofCell)
        {
        }
    }
}
