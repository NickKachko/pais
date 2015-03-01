using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPP
{
    public class BlueItem : Item
    {
        public BlueItem(Point Pos)
        {
            Position = Pos;
            IsHelpful = true;
        }
        public override void DrawItem(Pen MyPen, Graphics gPanel, int SizeofCell)
        {
            gPanel.FillRectangle(MyPen.Brush, Position.X * SizeofCell, Position.Y * SizeofCell, SizeofCell, SizeofCell);
        }
    }
}
