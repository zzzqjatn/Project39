using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Draw_Thing
{
    public partial class Form1 : Form
    {
        private Point CenterPoint = new Point();

        public Form1()
        {
            InitializeComponent();
            CenterPoint.X = 300;
            CenterPoint.Y = 300;
        }

        private void form_Paint(object sender, PaintEventArgs e)
        {
            Rect_Paint(CenterPoint, 100, e);
        }

        public void Rect_Paint(Point onePoint,int width, PaintEventArgs e)
        {
            Point[] Rect_point_ = new Point[4];

            Graphics grp = e.Graphics;
            Pen pen_ = new Pen(Color.Black);

            Rect_point_[0].X = onePoint.X - width / 2;
            Rect_point_[0].Y = onePoint.Y - width / 2;

            Rect_point_[1].X = onePoint.X + width / 2;
            Rect_point_[1].Y = onePoint.Y - width / 2;

            Rect_point_[2].X = onePoint.X + width / 2;
            Rect_point_[2].Y = onePoint.Y + width / 2;

            Rect_point_[3].X = onePoint.X - width / 2;
            Rect_point_[3].Y = onePoint.Y + width / 2;


            grp.DrawLine(pen_, Rect_point_[0], Rect_point_[1]);
            grp.DrawLine(pen_, Rect_point_[1], Rect_point_[2]);
            grp.DrawLine(pen_, Rect_point_[2], Rect_point_[3]);
            grp.DrawLine(pen_, Rect_point_[3], Rect_point_[0]);

            pen_.Dispose();
            grp.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                CenterPoint.Y -= 2;
                //MessageBox.Show(CenterPoint.Y.ToString());
            }

            if (e.KeyCode == Keys.S)
            {
                CenterPoint.Y += 2;
            }

            if(e.KeyCode == Keys.A)
            {
                CenterPoint.X -= 2;
            }

            if (e.KeyCode == Keys.D)
            {
                CenterPoint.X += 2;
            }

            //this.Invalidate();
            //this.Update();
            this.Refresh();
        }
    }
}