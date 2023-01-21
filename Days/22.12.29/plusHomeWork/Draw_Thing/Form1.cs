using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Draw_Thing
{
    public partial class Form1 : Form
    {
        private Point CenterPoint = new Point();

        //private Point[] Rect_point_ = new Point[4];
        public Form1()
        {
            InitializeComponent();
            CenterPoint.X = 300;
            CenterPoint.Y = 300;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Point[] point_ = new Point[2];

            //point_[0].X = 0;
            //point_[0].Y = 0;
            //point_[1].X = 840;
            //point_[1].Y = 600;

            //Graphics grp = e.Graphics;
            //Pen pen_ = new Pen(Color.Black);
            ////grp.DrawLine(pen_, point_[0], point_[1]);

            //grp.DrawLine(pen_, 300, 100,400,250);
            //grp.DrawLine(pen_, 400, 250,100,250);
            //grp.DrawLine(pen_, 100, 250,300,100);

            //grp.DrawLine(pen_, 100, 100, 200, 100);
            //grp.DrawLine(pen_, 200, 100, 200, 200);
            //grp.DrawLine(pen_, 200, 200, 100, 200);
            //grp.DrawLine(pen_, 100, 200, 100, 100);
            //pen_.Dispose();
            //grp.Dispose();

            Rect_Setting(CenterPoint, 100, e);
        }

        public void Rect_Setting(Point onePoint,int width, PaintEventArgs e)
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
                CenterPoint.Y -= 1;
            }
            if (e.KeyCode == Keys.S)
            {
                CenterPoint.Y += 1;
            }
            if(e.KeyCode == Keys.A)
            {
                CenterPoint.X -= 1;
            }
            if (e.KeyCode == Keys.D)
            {
                CenterPoint.X += 1;
            }

        }
    }
}