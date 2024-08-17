using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharpWin
{
    public enum Operators { Add, Sub, Multi, Div}
    public partial class Calculator : Form
    {
        public double Result = 0;
        public bool isNewNum = true;
        public Operators Opt = Operators.Add;
        public Calculator()
        {
            InitializeComponent();
        }
        public double Add(double number1, double number2) //  더하기 함수
        {
            double sum = number1 + number2;
            return sum;
        }
        public double Sub(double number1, double number2) // 빼기 함수
        {
            double sub = number1 - number2;
            return sub;
        }
        public double Multi(double number1, double number2) // 곱하기 함수
        {
            double Multi = number1 * number2;
            return Multi;
        }
        public double Div(double number1, double number2) // 나누기 함수
        {
            double Div = number1 / number2;
            if(number2.ToString() == "0") // 나누기 0 할 때는 오류로 인한 초기화
            {
                Result = 0;
                isNewNum = true;
                Opt = Operators.Add;

                NumScreen.Text = "0";
            }
            return Div;
        }
        private void NumButton1_Click(object sender, EventArgs e) // 모든 숫자의 클릭 호출
        {
            Button numButton = (Button)sender; // sender를 버튼으로 변환 -> (Button)...
            SetNum(numButton.Text);
        }
        public void SetNum(string num) // 계산기 숫자 함수 생성
        {
            if (isNewNum)
            {
                NumScreen.Text = num;
                isNewNum = false;
            }
            else if (NumScreen.Text == "0")
            {
                NumScreen.Text = num;
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }
        }
        private void NumPlus_Click(object sender, EventArgs e)  // 연산자 버튼 ("="버튼의 클릭 이벤트도 NumPlus_Click 사용) 
        {
            if (isNewNum == false)
            {
                double num = double.Parse(NumScreen.Text);
                if (Opt == Operators.Add)
                    Result = Add(Result, num);
                else if (Opt == Operators.Sub)
                    Result = Sub(Result, num);
                else if (Opt == Operators.Multi)
                    Result = Multi(Result, num);
                else if (Opt == Operators.Div)
                    Result = Div(Result, num);

                NumScreen.Text = Result.ToString();
                isNewNum = true;
            }
            Button optButton = (Button)sender;
            if (optButton.Text == "+")
                Opt = Operators.Add;
            else if (optButton.Text == "-")
                Opt = Operators.Sub;
            if (optButton.Text == "x")
                Opt = Operators.Multi;
            else if (optButton.Text == "/")
                Opt = Operators.Div;
        }

        private void NumClear_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Operators.Add;

            NumScreen.Text = "0";
        }
        private void DotButton_Click(object sender, EventArgs e) // 소수점 처리
        {
            if ((NumScreen.Text.Contains(".") == false))
                NumScreen.Text = NumScreen.Text + ".";
        }
    }
}
