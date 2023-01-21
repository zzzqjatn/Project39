using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;

namespace Draw_Thing
{
    public partial class Form1 : Form
    {
        private const int MAXINDEX = 10;    //�迭 MAX �� (�ִ� �׸� �� �ִ� ����)
        private Point[,] LinePointList = new Point[MAXINDEX, 2];    //���� 10�� �迭 [����, �� + ���� ���������� 2����]
        private Point[,] TrianglePointList = new Point[MAXINDEX, 3];    //�ﰢ�� 10�� �迭 [����, �ﰢ���� 3���� ���̱� ������ 3��]
        private Point[,] RectanglePointList = new Point[MAXINDEX, 4];   //�簢�� 10�� �迭 [����, �簢���� 4���� ���̱� ������ 4��]

        private Point[] Rect_point_ = new Point[4];     //�����̴� �簢���� 4���� ��
        private Point CenterPoint;      //  �����̴� �簢�� ���� �� ��

        private Graphics graphics_;     //GDI+ �� ����ϱ����� Ŭ����
        private Pen pen_;               //���� �׷��� �� Ŭ����

        private bool MoveRect = false;  //�����̴� �簢�� �� ���� ���� Ȯ�� bool ��
        private bool isClear = false;   //ȭ�� ����� ���� ������ Ȯ�� ���� ��

        public Form1()
        {
            InitializeComponent();

            Point temp = new Point(-1,-1);  //�ʱ�ȭ�� ���� �ӽ� temp ��
            //-1�� ���� �ʱ�ȭ
            for (int index = 0; index <= LinePointList.GetUpperBound(0); index++)
            {
                LinePointList[index, 0].X = temp.X;
                LinePointList[index, 0].Y = temp.Y;
                LinePointList[index, 1].X = temp.X;
                LinePointList[index, 1].Y = temp.Y;
            }
            //-1�� �ﰢ�� �ʱ�ȭ
            for (int index = 0; index <= TrianglePointList.GetUpperBound(0); index++)
            {
                TrianglePointList[index, 0].X = temp.X;
                TrianglePointList[index, 0].Y = temp.Y;
                TrianglePointList[index, 1].X = temp.X;
                TrianglePointList[index, 1].Y = temp.Y;
                TrianglePointList[index, 2].X = temp.X;
                TrianglePointList[index, 2].Y = temp.Y;
            }
            //-1�� �簢�� �ʱ�ȭ
            for (int index = 0; index <= RectanglePointList.GetUpperBound(0); index++)
            {
                RectanglePointList[index, 0].X = temp.X;
                RectanglePointList[index, 0].Y = temp.Y;
                RectanglePointList[index, 1].X = temp.X;
                RectanglePointList[index, 1].Y = temp.Y;
                RectanglePointList[index, 2].X = temp.X;
                RectanglePointList[index, 2].Y = temp.Y;
                RectanglePointList[index, 3].X = temp.X;
                RectanglePointList[index, 3].Y = temp.Y;
            }

            //�����̴� �簢�� �ʱ�ȭ
            CenterPoint = temp;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            graphics_ = e.Graphics; //�������� graphics_ �� PaintEventArgs�� Graphics�� ����
            pen_ = new Pen(Color.Black);    //�������� pen_ �� �ν��Ͻ�ȭ & �����ڷ� ���������� ����

            DrawAll();  //���� ����� Graphics��ü���� �׷��ִ� �Լ�

            if (isClear)    //ȭ�� ����� ���� ������ Ȯ�� ���� ��
            {
                graphics_.Clear(Color.White);   //Graphics��ü���� �����ִ� clear �޼��� �Ͼ������ �����ش�. (������ �� �����)
                isClear = false;    //����� �Ϸ� �� �ٽ� ���� ����
            }

            pen_.Dispose(); //pen_�� �� (�޸�) ����� �޼���
            graphics_.Dispose();    //graphics_ �� ��(�޸�) ����� �޼���
        }

        private void button1_Click(object sender, EventArgs e)        //�����׸��� ��ư Ŭ���� �Լ�
        {
            //���� �׸��� �Լ�
            DrawLineButton();
        }
        private void button2_Click(object sender, EventArgs e)       //�ﰢ�� �׸��� ��ư Ŭ���� �Լ�
        {
            //�ﰢ�� �׸��� �Լ�
            DrawTriangleButton();
        }
        private void button3_Click(object sender, EventArgs e)      //�簢�� �׸��� ��ư Ŭ���� �Լ�
        {
            //�簢�� �׸��� �Լ�
            DrawRectangleButton();
        }
        private void button4_Click(object sender, EventArgs e)      //�簢�� ���� ��ư Ŭ���� �Լ�
        {
            MoveRect = true;        //�ʱⰪ ���� ���ΰ� false -> true 
            CenterPoint.X = 200;    //�ʱⰪ ����( X : 200)
            CenterPoint.Y = 200;    //�ʱⰪ ����( Y : 200)
            this.panel1.Refresh();  //ȭ���� ��� �ٽ� �׷��ִ� Refresh �޼��� (panel1�� �Ʒ� ��ü���� �ٽ� �׷��ش�.)
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //��� ����� �� �ʱⰪ �ǵ����� �Լ�
            DrawAllClean();
        }
        private void DrawLineButton()   //������ �׸��� �Լ�
        {
            int[] temp = new int[4];    // ������ x, y 2�� , ���� x, y 2�� �� 4���� int���� �ޱ� ���� �����迭 �ӽð�

            //int.tryparse�� �������� �ƴ϶�� false�� ��ȯ�ϱ� ������ 4���� ���� ��� �������̶�� true ��ȯ
            if (int.TryParse(this.textBox1.Text, out temp[0]) && int.TryParse(this.textBox2.Text, out temp[1]) &&
                int.TryParse(this.textBox3.Text, out temp[2]) && int.TryParse(this.textBox4.Text, out temp[3]))
            {
                for (int index = 0; index <= LinePointList.GetUpperBound(0); index++)
                {
                    //���� ��2���� �� ��� �־�� �ϱ� ������ ���� �� x�� �ʱⰪ(-1)�̶�� ���� ���� �� �̱� ������
                    if (LinePointList[index, 0].X == -1)
                    {
                        // �� ���� �� �ݺ��� Ż��
                        LinePointList[index, 0].X = temp[0];
                        LinePointList[index, 0].Y = temp[1];
                        LinePointList[index, 1].X = temp[2];
                        LinePointList[index, 1].Y = temp[3];
                        break;
                    }
                }
                //���� ���� ��� ������ ������ ���� �ʱⰪ (-1)���̶�� �迭�� ���� ���̱� ������ ���
                if (LinePointList[LinePointList.GetUpperBound(0),0].X != -1)
                {
                    MessageBox.Show("�� �̻� ������ �� �����ϴ�", "[System] overflow");
                }
                this.panel1.Refresh();  //ȭ�� ����
            }
            else
            {
                //������ ���� ó��
                MessageBox.Show("�߸��� ���� �����Ͽ����ϴ�.", "[System] �Է� �� ���� ERROR");
            }
        }   //DrawLineButton()
        private void DrawTriangleButton()   //�ﰢ���� �׸��� �Լ�
        {
            int[] temp = new int[6];    //�ﰢ�� ��1 x,y ��2 x,y ��3 x,y �� �� �� 6���� ���� ���� �����迭 �ӽð�

            //int.tryparse�� �������� �ƴ϶�� false�� ��ȯ�ϱ� ������ 6���� ���� ��� �������̶�� true ��ȯ
            if (int.TryParse(this.textBox6.Text, out temp[0]) && int.TryParse(this.textBox5.Text, out temp[1]) &&
                int.TryParse(this.textBox7.Text, out temp[2]) && int.TryParse(this.textBox8.Text, out temp[3]) &&
                int.TryParse(this.textBox9.Text, out temp[4]) && int.TryParse(this.textBox10.Text, out temp[5]))
            {
                for (int index = 0; index <= TrianglePointList.GetUpperBound(0); index++)
                {
                    //���� �� x�� �ʱⰪ(-1)�̶�� ���� ���� �� �̱� ������
                    if (TrianglePointList[index, 0].X == -1)
                    {
                        // �� ���� �� �ݺ��� Ż��
                        TrianglePointList[index, 0].X = temp[0];
                        TrianglePointList[index, 0].Y = temp[1];
                        TrianglePointList[index, 1].X = temp[2];
                        TrianglePointList[index, 1].Y = temp[3];
                        TrianglePointList[index, 2].X = temp[4];
                        TrianglePointList[index, 2].Y = temp[5];
                        break;
                    }
                }
                //���� ���� ��� ������ ������ ���� �ʱⰪ (-1)���̶�� �迭�� ���� ���̱� ������ ���
                if (TrianglePointList[TrianglePointList.GetUpperBound(0), 0].X != -1)
                {
                    MessageBox.Show("�� �̻� ������ �� �����ϴ�", "[System] overflow");
                }
                this.panel1.Refresh(); //ȭ�� ����
            }
            else
            {                
                //������ ���� ó��
                MessageBox.Show("�߸��� ���� �����Ͽ����ϴ�.", "[System] �Է� �� ���� ERROR");
            }
        }   //DrawTriangleButton()
        private void DrawRectangleButton()  //�簢���� �׸��� �Լ�
        {
            int[] temp = new int[8];    //�簢�� ��1 x,y ��2 x,y ��3 x,y ��4 x,y �� �� 8���� ������ �ӽù迭

            //int.tryparse�� �������� �ƴ϶�� false�� ��ȯ�ϱ� ������ 8���� ���� ��� �������̶�� true ��ȯ
            if (int.TryParse(this.textBox11.Text, out temp[0]) && int.TryParse(this.textBox12.Text, out temp[1]) &&
                int.TryParse(this.textBox13.Text, out temp[2]) && int.TryParse(this.textBox14.Text, out temp[3]) &&
                int.TryParse(this.textBox15.Text, out temp[4]) && int.TryParse(this.textBox16.Text, out temp[5]) &&
                int.TryParse(this.textBox17.Text, out temp[6]) && int.TryParse(this.textBox18.Text, out temp[7]))
            {
                for (int index = 0; index <= RectanglePointList.GetUpperBound(0); index++)
                {
                    //���� �� x�� �ʱⰪ(-1)�̶�� ���� ���� �� �̱� ������
                    if (RectanglePointList[index, 0].X == -1)
                    {
                        RectanglePointList[index, 0].X = temp[0];
                        RectanglePointList[index, 0].Y = temp[1];
                        RectanglePointList[index, 1].X = temp[2];
                        RectanglePointList[index, 1].Y = temp[3];
                        RectanglePointList[index, 2].X = temp[4];
                        RectanglePointList[index, 2].Y = temp[5];
                        RectanglePointList[index, 3].X = temp[6];
                        RectanglePointList[index, 3].Y = temp[7];
                        break;
                    }
                }
                //���� ���� ��� ������ ������ ���� �ʱⰪ (-1)���̶�� �迭�� ���� ���̱� ������ ���
                if (RectanglePointList[RectanglePointList.GetUpperBound(0), 0].X != -1)
                {
                    MessageBox.Show("�� �̻� ������ �� �����ϴ�", "[System] overflow");
                }
                this.panel1.Refresh();  //ȭ�� ����
            }
            else
            {
                //������ ���� ó��
                MessageBox.Show("�߸��� ���� �����Ͽ����ϴ�.", "[System] �Է� �� ���� ERROR");
            }
        }   //DrawRectangleButton()

        private void DrawAll()  //��� �׸��� �Լ�
        {
            // ���� �� �迭 �ݺ���
            for(int index = 0; index <= LinePointList.GetUpperBound(0); index++)
            {
                //���� �� x�� �ʱⰪ(-1)�� �ƴ϶�� ���� �����Ƿ� �׸���
                if (LinePointList[index, 0].X != -1)
                {
                    graphics_.DrawLine(pen_, LinePointList[index, 0], LinePointList[index, 1]); //���� �׷��ֱ�
                }
                else    //�ʱⰪ�̶��
                {
                    continue;   //�н�
                }
            }

            //�ﰢ�� �� �迭 �ݺ���
            for (int index = 0; index <= TrianglePointList.GetUpperBound(0); index++)
            {
                //���� �� x�� �ʱⰪ(-1)�� �ƴ϶�� ���� �����Ƿ� �׸���
                if (TrianglePointList[index, 0].X != -1)
                {
                    graphics_.DrawLine(pen_, TrianglePointList[index, 0], TrianglePointList[index, 1]); //�ﰢ�� �� 0 -> 1�� ���� �׸���
                    graphics_.DrawLine(pen_, TrianglePointList[index, 1], TrianglePointList[index, 2]); //�ﰢ�� �� 1 -> 2�� ���� �׸���
                    graphics_.DrawLine(pen_, TrianglePointList[index, 2], TrianglePointList[index, 0]); //�ﰢ�� �� 2 -> 0�� ���� �׸���
                }
                else    //�ʱⰪ�̶��
                {
                    continue;   //�н�
                }
            }

            //�簢�� �� �迭 �ݺ���
            for (int index = 0; index <= RectanglePointList.GetUpperBound(0); index++)
            {
                //���� �� x�� �ʱⰪ(-1)�� �ƴ϶�� ���� �����Ƿ� �׸���
                if (RectanglePointList[index, 0].X != -1)
                {
                    graphics_.DrawLine(pen_, RectanglePointList[index, 0], RectanglePointList[index, 1]); //�簢�� �� 0 -> 1�� ���� �׸���
                    graphics_.DrawLine(pen_, RectanglePointList[index, 1], RectanglePointList[index, 2]); //�簢�� �� 1 -> 2�� ���� �׸���
                    graphics_.DrawLine(pen_, RectanglePointList[index, 2], RectanglePointList[index, 3]); //�簢�� �� 2 -> 3�� ���� �׸���
                    graphics_.DrawLine(pen_, RectanglePointList[index, 3], RectanglePointList[index, 0]); //�簢�� �� 3 -> 0�� ���� �׸���
                }
                else    //�ʱⰪ�� �ƴ϶��
                {
                    continue;   //�н�
                }
            }

            if(MoveRect)    //MoveRect�� true (centerposition���� ���É�ٸ�)
            {
                rectSettingAndDraw(100);   //�� �簢�� ���� �׸��� �Լ�(���� �� ��, ����)
            }
        }

        private void DrawAllClean() //��� ����� �� �� �ʱ�ȭ �Լ�
        {
            Point temp = new Point(-1, -1); //�ʱ�ȭ�� ���� �ӽ� ��

            //-1�� ���� �迭 �ʱ�ȭ
            for (int index = 0; index < LinePointList.GetUpperBound(0); index++)
            {
                LinePointList[index, 0].X = temp.X;
                LinePointList[index, 0].Y = temp.Y;
                LinePointList[index, 1].X = temp.X;
                LinePointList[index, 1].Y = temp.Y;
            }
            //-1�� �ﰢ�� �迭 �ʱ�ȭ
            for (int index = 0; index <= TrianglePointList.GetUpperBound(0); index++)
            {
                TrianglePointList[index, 0].X = temp.X;
                TrianglePointList[index, 0].Y = temp.Y;
                TrianglePointList[index, 1].X = temp.X;
                TrianglePointList[index, 1].Y = temp.Y;
                TrianglePointList[index, 2].X = temp.X;
                TrianglePointList[index, 2].Y = temp.Y;
            }
            //-1�� �簢�� �迭 �ʱ�ȭ
            for (int index = 0; index <= RectanglePointList.GetUpperBound(0); index++)
            {
                RectanglePointList[index, 0].X = temp.X;
                RectanglePointList[index, 0].Y = temp.Y;
                RectanglePointList[index, 1].X = temp.X;
                RectanglePointList[index, 1].Y = temp.Y;
                RectanglePointList[index, 2].X = temp.X;
                RectanglePointList[index, 2].Y = temp.Y;
                RectanglePointList[index, 3].X = temp.X;
                RectanglePointList[index, 3].Y = temp.Y;
            }
            MoveRect = false;  //�����̴� �簢�� �ʱ� ���ð� ���� false 
            CenterPoint = temp; //�����̴� �簢�� ���� �� �ʱ�ȭ
            this.panel1.Refresh();  //ȭ�� ���� (�ʱⰪ������ ȭ�鿡�� ��������.)
            isClear = true; //ȭ�� �����
        }

        public void rectSettingAndDraw(int width)    //�����̴� �簢�� ���� �� �׷��ִ� �Լ�
        {
            //ù��° ���� ���� �� 
            Rect_point_[0].X = CenterPoint.X - width / 2;  //CenterPoint�������� ������ ���� x������ ���ش� (ȭ���� x�� -���� ����������)
            Rect_point_[0].Y = CenterPoint.Y - width / 2;  //CenterPoint�������� ������ ���� y������ ���ش� (ȭ���� y�� -���� ����������)

            //�ι�° ���� ������ ��
            Rect_point_[1].X = CenterPoint.X + width / 2;  //CenterPoint�������� ������ ���� x������ �����ش� (ȭ���� x�� +���� ������������)
            Rect_point_[1].Y = CenterPoint.Y - width / 2;  //CenterPoint�������� ������ ���� y������ ���ش� (ȭ���� y�� -���� ����������)

            //����° ���� ������ �Ʒ�
            Rect_point_[2].X = CenterPoint.X + width / 2;  //CenterPoint�������� ������ ���� x������ �����ش� (ȭ���� x�� +���� ������������)
            Rect_point_[2].Y = CenterPoint.Y + width / 2;  //CenterPoint�������� ������ ���� y������ �����ش� (ȭ���� y�� +���� �Ʒ���������)

            //�׹�° ���� ���� �Ʒ�
            Rect_point_[3].X = CenterPoint.X - width / 2;  //CenterPoint�������� ������ ���� x������ ���ش� (ȭ���� x�� -���� ����������)
            Rect_point_[3].Y = CenterPoint.Y + width / 2;  //CenterPoint�������� ������ ���� y������ �����ش� (ȭ���� y�� +���� �Ʒ���������)

            graphics_.DrawLine(pen_, Rect_point_[0], Rect_point_[1]);   //�簢�� ���� �׸��� 0 -> 1
            graphics_.DrawLine(pen_, Rect_point_[1], Rect_point_[2]);   //�簢�� ���� �׸��� 1 -> 2
            graphics_.DrawLine(pen_, Rect_point_[2], Rect_point_[3]);   //�簢�� ���� �׸��� 2 -> 3
            graphics_.DrawLine(pen_, Rect_point_[3], Rect_point_[0]);   //�簢�� ���� �׸��� 3 -> 0
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)   //�Է� Text â�� �ݾ��ִ� �Լ�
        {
            //���� checkBox1�� üũ�� ���¶��
            if (this.checkBox1.Checked)
            {
                //��� textBox�� �б� �������� �ϱ�
                this.textBox1.ReadOnly = true;
                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.textBox4.ReadOnly = true;
                this.textBox5.ReadOnly = true;
                this.textBox6.ReadOnly = true;
                this.textBox7.ReadOnly = true;
                this.textBox8.ReadOnly = true;
                this.textBox9.ReadOnly = true;
                this.textBox10.ReadOnly = true;
                this.textBox11.ReadOnly = true;
                this.textBox12.ReadOnly = true;
                this.textBox13.ReadOnly = true;
                this.textBox14.ReadOnly = true;
                this.textBox15.ReadOnly = true;
                this.textBox16.ReadOnly = true;
                this.textBox17.ReadOnly = true;
                this.textBox18.ReadOnly = true;
            }

            //���� checkBox1�� üũ�� ���°� �ƴ϶��
            if (this.checkBox1.Checked == false)
            {
                //��� textBox�� �б� ���� Ǯ��
                this.textBox1.ReadOnly = false;
                this.textBox2.ReadOnly = false;
                this.textBox3.ReadOnly = false;
                this.textBox4.ReadOnly = false;
                this.textBox5.ReadOnly = false;
                this.textBox6.ReadOnly = false;
                this.textBox7.ReadOnly = false;
                this.textBox8.ReadOnly = false;
                this.textBox9.ReadOnly = false;
                this.textBox10.ReadOnly = false;
                this.textBox11.ReadOnly = false;
                this.textBox12.ReadOnly = false;
                this.textBox13.ReadOnly = false;
                this.textBox14.ReadOnly = false;
                this.textBox15.ReadOnly = false;
                this.textBox16.ReadOnly = false;
                this.textBox17.ReadOnly = false;
                this.textBox18.ReadOnly = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)   //Ű���� �Է¿� ���� �� �Է�
        {
            //���� checkBox1���� üũ�Ǿ��ִٸ�
            if (this.checkBox1.Checked == true)
            {
                Point temp_ = CenterPoint;  //CenterPoint���� �޴� �ӽ� Point��

                if (e.KeyCode == Keys.W)    //W�� ������ ���
                {
                    temp_.Y -= 5;   //���������� y������ ���ش�
                }

                if (e.KeyCode == Keys.S)    //S�� ������ ���
                {
                    temp_.Y += 5;   //�Ʒ��������� y������ �����ش�
                }

                if (e.KeyCode == Keys.A)    //A�� ������ ���
                {
                    temp_.X -= 5;   //���������� x������ ���ش�
                }

                if (e.KeyCode == Keys.D)    //D�� ������ ���
                {
                    temp_.X += 5;   //������������ x������ �����ش�
                }

                CenterPoint = temp_;    //�ӽð��� ��ȯ�� �������� ���� �����̴� CenterPoint ���� �����Ѵ�.

                this.panel1.Refresh();  //ȭ�� ����
            }
        }
    }
}