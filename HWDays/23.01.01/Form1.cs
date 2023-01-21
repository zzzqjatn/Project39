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
        private const int MAXINDEX = 10;    //배열 MAX 값 (최대 그릴 수 있는 갯수)
        private Point[,] LinePointList = new Point[MAXINDEX, 2];    //직선 10개 배열 [순번, 점 + 점은 직선임으로 2개만]
        private Point[,] TrianglePointList = new Point[MAXINDEX, 3];    //삼각형 10개 배열 [순번, 삼각형은 3개의 점이기 때문에 3개]
        private Point[,] RectanglePointList = new Point[MAXINDEX, 4];   //사각형 10개 배열 [순번, 사각형은 4개의 점이기 때문에 4개]

        private Point[] Rect_point_ = new Point[4];     //움직이는 사각형의 4개의 점
        private Point CenterPoint;      //  움직이는 사각형 센터 점 값

        private Graphics graphics_;     //GDI+ 를 사용하기위한 클래스
        private Pen pen_;               //선을 그려줄 펜 클래스

        private bool MoveRect = false;  //움직이는 사각형 값 설정 정상 확인 bool 값
        private bool isClear = false;   //화면 지우기 이전 값정리 확인 여부 값

        public Form1()
        {
            InitializeComponent();

            Point temp = new Point(-1,-1);  //초기화를 위한 임시 temp 값
            //-1로 라인 초기화
            for (int index = 0; index <= LinePointList.GetUpperBound(0); index++)
            {
                LinePointList[index, 0].X = temp.X;
                LinePointList[index, 0].Y = temp.Y;
                LinePointList[index, 1].X = temp.X;
                LinePointList[index, 1].Y = temp.Y;
            }
            //-1로 삼각형 초기화
            for (int index = 0; index <= TrianglePointList.GetUpperBound(0); index++)
            {
                TrianglePointList[index, 0].X = temp.X;
                TrianglePointList[index, 0].Y = temp.Y;
                TrianglePointList[index, 1].X = temp.X;
                TrianglePointList[index, 1].Y = temp.Y;
                TrianglePointList[index, 2].X = temp.X;
                TrianglePointList[index, 2].Y = temp.Y;
            }
            //-1로 사각형 초기화
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

            //움직이는 사각형 초기화
            CenterPoint = temp;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            graphics_ = e.Graphics; //전역변수 graphics_ 을 PaintEventArgs의 Graphics로 대입
            pen_ = new Pen(Color.Black);    //전역변수 pen_ 을 인스턴스화 & 생성자로 검정색으로 생성

            DrawAll();  //최종 결과를 Graphics개체들을 그려주는 함수

            if (isClear)    //화면 지우기 이전 값정리 확인 여부 값
            {
                graphics_.Clear(Color.White);   //Graphics개체들을 지워주는 clear 메서드 하얀색으로 없애준다. (실제로 값 지우기)
                isClear = false;    //지우기 완료 및 다시 재우기 방지
            }

            pen_.Dispose(); //pen_의 값 (메모리) 지우기 메서드
            graphics_.Dispose();    //graphics_ 의 값(메모리) 지우기 메서드
        }

        private void button1_Click(object sender, EventArgs e)        //직선그리기 버튼 클릭시 함수
        {
            //직선 그리기 함수
            DrawLineButton();
        }
        private void button2_Click(object sender, EventArgs e)       //삼각형 그리기 버튼 클릭시 함수
        {
            //삼각형 그리기 함수
            DrawTriangleButton();
        }
        private void button3_Click(object sender, EventArgs e)      //사각형 그리기 버튼 클릭시 함수
        {
            //사각형 그리기 함수
            DrawRectangleButton();
        }
        private void button4_Click(object sender, EventArgs e)      //사각형 생성 버튼 클릭시 함수
        {
            MoveRect = true;        //초기값 설정 여부값 false -> true 
            CenterPoint.X = 200;    //초기값 고정( X : 200)
            CenterPoint.Y = 200;    //초기값 고정( Y : 200)
            this.panel1.Refresh();  //화면을 즉시 다시 그려주는 Refresh 메서드 (panel1의 아래 개체들을 다시 그려준다.)
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //모두 지우기 전 초기값 되돌리는 함수
            DrawAllClean();
        }
        private void DrawLineButton()   //직선을 그리는 함수
        {
            int[] temp = new int[4];    // 시작점 x, y 2개 , 끝점 x, y 2개 총 4개의 int값을 받기 위한 정수배열 임시값

            //int.tryparse는 정수값이 아니라면 false를 반환하기 때문에 4개의 값이 모두 정수값이라면 true 반환
            if (int.TryParse(this.textBox1.Text, out temp[0]) && int.TryParse(this.textBox2.Text, out temp[1]) &&
                int.TryParse(this.textBox3.Text, out temp[2]) && int.TryParse(this.textBox4.Text, out temp[3]))
            {
                for (int index = 0; index <= LinePointList.GetUpperBound(0); index++)
                {
                    //선은 점2개의 값 모두 있어야 하기 때문에 앞의 값 x가 초기값(-1)이라면 값이 없는 것 이기 때문에
                    if (LinePointList[index, 0].X == -1)
                    {
                        // 값 대입 후 반복문 탈출
                        LinePointList[index, 0].X = temp[0];
                        LinePointList[index, 0].Y = temp[1];
                        LinePointList[index, 1].X = temp[2];
                        LinePointList[index, 1].Y = temp[3];
                        break;
                    }
                }
                //만약 값을 모두 기입후 마지막 값이 초기값 (-1)값이라면 배열이 꽉찬 것이기 때문에 경고문
                if (LinePointList[LinePointList.GetUpperBound(0),0].X != -1)
                {
                    MessageBox.Show("더 이상 기입할 수 없습니다", "[System] overflow");
                }
                this.panel1.Refresh();  //화면 갱신
            }
            else
            {
                //나머지 예외 처리
                MessageBox.Show("잘못된 값을 기입하였습니다.", "[System] 입력 값 예외 ERROR");
            }
        }   //DrawLineButton()
        private void DrawTriangleButton()   //삼각형을 그리는 함수
        {
            int[] temp = new int[6];    //삼각형 점1 x,y 점2 x,y 점3 x,y 의 값 총 6개의 값을 위한 정수배열 임시값

            //int.tryparse는 정수값이 아니라면 false를 반환하기 때문에 6개의 값이 모두 정수값이라면 true 반환
            if (int.TryParse(this.textBox6.Text, out temp[0]) && int.TryParse(this.textBox5.Text, out temp[1]) &&
                int.TryParse(this.textBox7.Text, out temp[2]) && int.TryParse(this.textBox8.Text, out temp[3]) &&
                int.TryParse(this.textBox9.Text, out temp[4]) && int.TryParse(this.textBox10.Text, out temp[5]))
            {
                for (int index = 0; index <= TrianglePointList.GetUpperBound(0); index++)
                {
                    //앞의 값 x가 초기값(-1)이라면 값이 없는 것 이기 때문에
                    if (TrianglePointList[index, 0].X == -1)
                    {
                        // 값 대입 후 반복문 탈출
                        TrianglePointList[index, 0].X = temp[0];
                        TrianglePointList[index, 0].Y = temp[1];
                        TrianglePointList[index, 1].X = temp[2];
                        TrianglePointList[index, 1].Y = temp[3];
                        TrianglePointList[index, 2].X = temp[4];
                        TrianglePointList[index, 2].Y = temp[5];
                        break;
                    }
                }
                //만약 값을 모두 기입후 마지막 값이 초기값 (-1)값이라면 배열이 꽉찬 것이기 때문에 경고문
                if (TrianglePointList[TrianglePointList.GetUpperBound(0), 0].X != -1)
                {
                    MessageBox.Show("더 이상 기입할 수 없습니다", "[System] overflow");
                }
                this.panel1.Refresh(); //화면 갱신
            }
            else
            {                
                //나머지 예외 처리
                MessageBox.Show("잘못된 값을 기입하였습니다.", "[System] 입력 값 예외 ERROR");
            }
        }   //DrawTriangleButton()
        private void DrawRectangleButton()  //사각형을 그리는 함수
        {
            int[] temp = new int[8];    //사각형 점1 x,y 점2 x,y 점3 x,y 점4 x,y 값 총 8개의 정수형 임시배열

            //int.tryparse는 정수값이 아니라면 false를 반환하기 때문에 8개의 값이 모두 정수값이라면 true 반환
            if (int.TryParse(this.textBox11.Text, out temp[0]) && int.TryParse(this.textBox12.Text, out temp[1]) &&
                int.TryParse(this.textBox13.Text, out temp[2]) && int.TryParse(this.textBox14.Text, out temp[3]) &&
                int.TryParse(this.textBox15.Text, out temp[4]) && int.TryParse(this.textBox16.Text, out temp[5]) &&
                int.TryParse(this.textBox17.Text, out temp[6]) && int.TryParse(this.textBox18.Text, out temp[7]))
            {
                for (int index = 0; index <= RectanglePointList.GetUpperBound(0); index++)
                {
                    //앞의 값 x가 초기값(-1)이라면 값이 없는 것 이기 때문에
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
                //만약 값을 모두 기입후 마지막 값이 초기값 (-1)값이라면 배열이 꽉찬 것이기 때문에 경고문
                if (RectanglePointList[RectanglePointList.GetUpperBound(0), 0].X != -1)
                {
                    MessageBox.Show("더 이상 기입할 수 없습니다", "[System] overflow");
                }
                this.panel1.Refresh();  //화면 갱신
            }
            else
            {
                //나머지 예외 처리
                MessageBox.Show("잘못된 값을 기입하였습니다.", "[System] 입력 값 예외 ERROR");
            }
        }   //DrawRectangleButton()

        private void DrawAll()  //모두 그리는 함수
        {
            // 직선 값 배열 반복문
            for(int index = 0; index <= LinePointList.GetUpperBound(0); index++)
            {
                //앞의 값 x가 초기값(-1)이 아니라면 값이 있으므로 그리기
                if (LinePointList[index, 0].X != -1)
                {
                    graphics_.DrawLine(pen_, LinePointList[index, 0], LinePointList[index, 1]); //라인 그려주기
                }
                else    //초기값이라면
                {
                    continue;   //패스
                }
            }

            //삼각형 값 배열 반복문
            for (int index = 0; index <= TrianglePointList.GetUpperBound(0); index++)
            {
                //앞의 값 x가 초기값(-1)이 아니라면 값이 있으므로 그리기
                if (TrianglePointList[index, 0].X != -1)
                {
                    graphics_.DrawLine(pen_, TrianglePointList[index, 0], TrianglePointList[index, 1]); //삼각형 점 0 -> 1로 라인 그리기
                    graphics_.DrawLine(pen_, TrianglePointList[index, 1], TrianglePointList[index, 2]); //삼각형 점 1 -> 2로 라인 그리기
                    graphics_.DrawLine(pen_, TrianglePointList[index, 2], TrianglePointList[index, 0]); //삼각형 점 2 -> 0로 라인 그리기
                }
                else    //초기값이라면
                {
                    continue;   //패스
                }
            }

            //사각형 값 배열 반복문
            for (int index = 0; index <= RectanglePointList.GetUpperBound(0); index++)
            {
                //앞의 값 x가 초기값(-1)이 아니라면 값이 있으므로 그리기
                if (RectanglePointList[index, 0].X != -1)
                {
                    graphics_.DrawLine(pen_, RectanglePointList[index, 0], RectanglePointList[index, 1]); //사각형 점 0 -> 1로 라인 그리기
                    graphics_.DrawLine(pen_, RectanglePointList[index, 1], RectanglePointList[index, 2]); //사각형 점 1 -> 2로 라인 그리기
                    graphics_.DrawLine(pen_, RectanglePointList[index, 2], RectanglePointList[index, 3]); //사각형 점 2 -> 3로 라인 그리기
                    graphics_.DrawLine(pen_, RectanglePointList[index, 3], RectanglePointList[index, 0]); //사각형 점 3 -> 0로 라인 그리기
                }
                else    //초기값이 아니라면
                {
                    continue;   //패스
                }
            }

            if(MoveRect)    //MoveRect이 true (centerposition값이 세팅됬다면)
            {
                rectSettingAndDraw(100);   //정 사각형 세팅 그리기 함수(센터 점 값, 길이)
            }
        }

        private void DrawAllClean() //모두 지우기 전 값 초기화 함수
        {
            Point temp = new Point(-1, -1); //초기화를 위한 임시 값

            //-1로 직선 배열 초기화
            for (int index = 0; index < LinePointList.GetUpperBound(0); index++)
            {
                LinePointList[index, 0].X = temp.X;
                LinePointList[index, 0].Y = temp.Y;
                LinePointList[index, 1].X = temp.X;
                LinePointList[index, 1].Y = temp.Y;
            }
            //-1로 삼각형 배열 초기화
            for (int index = 0; index <= TrianglePointList.GetUpperBound(0); index++)
            {
                TrianglePointList[index, 0].X = temp.X;
                TrianglePointList[index, 0].Y = temp.Y;
                TrianglePointList[index, 1].X = temp.X;
                TrianglePointList[index, 1].Y = temp.Y;
                TrianglePointList[index, 2].X = temp.X;
                TrianglePointList[index, 2].Y = temp.Y;
            }
            //-1로 사각형 배열 초기화
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
            MoveRect = false;  //움직이는 사각형 초기 세팅값 여부 false 
            CenterPoint = temp; //움직이는 사각형 센터 값 초기화
            this.panel1.Refresh();  //화면 갱신 (초기값임으로 화면에서 없어진다.)
            isClear = true; //화면 지우기
        }

        public void rectSettingAndDraw(int width)    //움직이는 사각형 세팅 및 그려주는 함수
        {
            //첫번째 점은 왼쪽 위 
            Rect_point_[0].X = CenterPoint.X - width / 2;  //CenterPoint기준으로 길이의 반을 x축으로 빼준다 (화면의 x축 -값은 왼쪽임으로)
            Rect_point_[0].Y = CenterPoint.Y - width / 2;  //CenterPoint기준으로 길이의 반을 y축으로 빼준다 (화면의 y축 -값은 위쪽임으로)

            //두번째 점은 오른쪽 위
            Rect_point_[1].X = CenterPoint.X + width / 2;  //CenterPoint기준으로 길이의 반을 x축으로 더해준다 (화면의 x축 +값은 오른쪽임으로)
            Rect_point_[1].Y = CenterPoint.Y - width / 2;  //CenterPoint기준으로 길이의 반을 y축으로 빼준다 (화면의 y축 -값은 위쪽임으로)

            //세번째 점은 오른쪽 아래
            Rect_point_[2].X = CenterPoint.X + width / 2;  //CenterPoint기준으로 길이의 반을 x축으로 더해준다 (화면의 x축 +값은 오른쪽임으로)
            Rect_point_[2].Y = CenterPoint.Y + width / 2;  //CenterPoint기준으로 길이의 반을 y축으로 더해준다 (화면의 y축 +값은 아래쪽임으로)

            //네번째 점은 왼쪽 아래
            Rect_point_[3].X = CenterPoint.X - width / 2;  //CenterPoint기준으로 길이의 반을 x축으로 빼준다 (화면의 x축 -값은 왼쪽임으로)
            Rect_point_[3].Y = CenterPoint.Y + width / 2;  //CenterPoint기준으로 길이의 반을 y축으로 더해준다 (화면의 y축 +값은 아래쪽임으로)

            graphics_.DrawLine(pen_, Rect_point_[0], Rect_point_[1]);   //사각형 라인 그리기 0 -> 1
            graphics_.DrawLine(pen_, Rect_point_[1], Rect_point_[2]);   //사각형 라인 그리기 1 -> 2
            graphics_.DrawLine(pen_, Rect_point_[2], Rect_point_[3]);   //사각형 라인 그리기 2 -> 3
            graphics_.DrawLine(pen_, Rect_point_[3], Rect_point_[0]);   //사각형 라인 그리기 3 -> 0
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)   //입력 Text 창을 닫아주는 함수
        {
            //만약 checkBox1이 체크된 상태라면
            if (this.checkBox1.Checked)
            {
                //모든 textBox를 읽기 전용으로 하기
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

            //만약 checkBox1이 체크된 상태가 아니라면
            if (this.checkBox1.Checked == false)
            {
                //모든 textBox를 읽기 전용 풀기
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)   //키보드 입력에 관한 값 입력
        {
            //만약 checkBox1값이 체크되어있다면
            if (this.checkBox1.Checked == true)
            {
                Point temp_ = CenterPoint;  //CenterPoint값을 받는 임시 Point값

                if (e.KeyCode == Keys.W)    //W를 눌렀을 경우
                {
                    temp_.Y -= 5;   //위쪽임으로 y축으로 빼준다
                }

                if (e.KeyCode == Keys.S)    //S를 눌렀을 경우
                {
                    temp_.Y += 5;   //아래쪽임으로 y축으로 더해준다
                }

                if (e.KeyCode == Keys.A)    //A를 눌렀을 경우
                {
                    temp_.X -= 5;   //왼쪽임으로 x축으로 빼준다
                }

                if (e.KeyCode == Keys.D)    //D를 눌렀을 경우
                {
                    temp_.X += 5;   //오른쪽임으로 x축으로 더해준다
                }

                CenterPoint = temp_;    //임시값에 반환한 최종값을 실제 움직이는 CenterPoint 값에 대입한다.

                this.panel1.Refresh();  //화면 갱신
            }
        }
    }
}