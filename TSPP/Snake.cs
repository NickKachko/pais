using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSPP
{
    public class Snake
    {
        private Snake()
        {
            // Prevent outside instantiation
        }

        private static Snake _singleton;

        public static Snake GetSingleton()
        {
            if (_singleton == null)
            {
                _singleton = new Snake();
                _singleton.Position = new List<Point>();
                _singleton.Position.Add(new Point(0, 0));
                _singleton.Direction = new ArrowDirection();
                _singleton.Direction = ArrowDirection.Right;
            }
            return _singleton;
        }

        public List<Point> Position { get; set; }
        public ArrowDirection Direction { get; set; }
        public void DrawSnake(Graphics gPanel, Pen MyPen, int SizeofCell)
        {
            foreach (Point p in Position)
            {
                gPanel.FillRectangle(MyPen.Brush, p.X * SizeofCell, p.Y * SizeofCell, SizeofCell, SizeofCell);
            }
        }

        public void Move(Point NetRes)
        {
            for (int i = Position.Count - 1; i > 0; i--)
            {
                Position[i] = Position[i - 1];
            }
            Point temp = Position[0];
            if (Direction == ArrowDirection.Down) { temp.Y++; if (temp.Y >= NetRes.Y) temp.Y = 0; }
            if (Direction == ArrowDirection.Up) { temp.Y--; if (temp.Y < 0) temp.Y = NetRes.Y - 1; }
            if (Direction == ArrowDirection.Right) { temp.X++; if (temp.X >= NetRes.X) temp.X = 0; }
            if (Direction == ArrowDirection.Left) { temp.X--; if (temp.X < 0) temp.X = NetRes.X - 1; }
            Position[0] = temp;
        }

        public void Add()
        {
            Position.Add(Position[Position.Count - 1]);
        }
    }
}
