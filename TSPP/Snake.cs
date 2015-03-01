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
    /// The class for snake representation
    /// </summary>
    public class Snake
    {
        /// <summary>an instance of the snake</summary>
        private static Snake _singleton;
        /// <summary>a set of positions of the snake</summary>
        public List<Point> position { get; set; }
        /// <summary>a direction the snake heading</summary>
        public ArrowDirection Direction { get; set; }

        /// <summary>
        /// a private default constructor to prevent outside instantiation
        /// </summary>
        private Snake()
        {
            // Prevent outside instantiation
        }

        /// <summary>
        /// use this instead constructor in order to get a snake's object
        /// </summary>
        /// <returns>an instance of the snake</returns>
        public static Snake GetSingleton()
        {
            if (_singleton == null)
            {
                _singleton = new Snake();
                _singleton.position = new List<Point>();
                _singleton.position.Add(new Point(0, 0));
                _singleton.Direction = new ArrowDirection();
                _singleton.Direction = ArrowDirection.Right;
            }
            return _singleton;
        }

        /// <summary>
        /// draw the snake using pen and on the panel
        /// </summary>
        /// <param name="gPanel">a panel to draw on</param>
        /// <param name="myPen">a tool that sets the drawing behavior</param>
        /// <param name="sizeOfCell">current size of the net's cell</param>
        public void DrawSnake(Graphics gPanel, Pen myPen, int sizeOfCell)
        {
            foreach (Point p in position)
            {
                gPanel.FillRectangle(myPen.Brush, p.X * sizeOfCell, p.Y * sizeOfCell, sizeOfCell, sizeOfCell);
            }
        }

        /// <summary>
        /// move whithin the net
        /// </summary>
        /// <param name="netRes">resolution of the net</param>
        public void Move(Point netRes)
        {
            for (int i = position.Count - 1; i > 0; i--)
            {
                position[i] = position[i - 1]; 
            }
            Point temp = position[0];
            if (Direction == ArrowDirection.Down) { temp.Y++; if (temp.Y >= netRes.Y) temp.Y = 0; }
            if (Direction == ArrowDirection.Up) { temp.Y--; if (temp.Y < 0) temp.Y = netRes.Y - 1; }
            if (Direction == ArrowDirection.Right) { temp.X++; if (temp.X >= netRes.X) temp.X = 0; }
            if (Direction == ArrowDirection.Left) { temp.X--; if (temp.X < 0) temp.X = netRes.X - 1; }
            position[0] = temp;
        }

        /// <summary>
        /// add one item to the snake's size
        /// </summary>
        public void Add()
        {
            position.Add(position[position.Count - 1]);
        }
    }
}
