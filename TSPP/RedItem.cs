using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPP
{
    public class RedItem : Item
    {
        public int SecondCounter, MaxSecond;
        public RedItem(Point Pos)
        {
            Position = Pos;
            SecondCounter = 0;
            MaxSecond = 10;
            IsHelpful = false;
        }
        public override void DrawItem(Pen MyPen, Graphics gPanel, int SizeofCell)
        {
            gPanel.FillRectangle(MyPen.Brush, Position.X * SizeofCell, Position.Y * SizeofCell, SizeofCell, SizeofCell);
        }
    }
}
