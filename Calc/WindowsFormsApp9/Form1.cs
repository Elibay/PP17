using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public static double FirstN = 0, SecondN = 0, MS = 0;
        public static char lastOperation = '1', lastOperation2 = '1';
        public static bool LastO = false;
        void Add_M ()
        {
            for (int i = 0; i <= 4; ++i)
            {
                Button b = new Button();
                b.BackColor = System.Drawing.Color.NavajoWhite;
                b.Font = new Font("Arial", 10, FontStyle.Italic);
                b.Size = new Size(60, 60);
                b.Location = new Point(i * 60, 60);
                if (i == 0)
                    b.Text = "MR";
                if (i == 1)
                    b.Text = "MC";
                if (i == 2)
                    b.Text = "M+";
                if (i == 3)
                    b.Text = "M-";
                if (i == 4)
                    b.Text = "MS";
                b.Click += new EventHandler(ButtonClick);
                this.Controls.Add(b);
            }
        }
        void Add_Functions ()
        {
            for (int i = 0; i < 4; ++ i)
            {
                Button b = new Button();
                b.Font = new Font("Arial", 15, FontStyle.Italic);
                b.Size = new Size(75, 60);
                b.Location = new Point(i * 75, 120);
                if (i == 0)
                    b.Text = "√";
                if (i == 1)
                    b.Text = "1/x";
                if (i == 2)
                    b.Text = "x^2";
                if (i == 3)
                    b.Text = "%";
                b.Click += new EventHandler(ButtonClick);
                this.Controls.Add(b);
            }
        }
        void Add_C ()
        {
            for (int i = 0; i < 3; ++i)
            {
                Button b = new Button();
                b.Font = new Font("Arial", 15, FontStyle.Italic);
                b.Size = new Size(75, 60);
                b.Location = new Point(i * 75, 180);
                if (i == 0)
                    b.Text = "CE";
                if (i == 1)
                    b.Text = "C";
                if (i == 2)
                    b.Text = "←";
                b.Click += new EventHandler(ButtonClick);
                this.Controls.Add(b);
            }
        }
        void Add_Numbers ()
        {
            int x = 10;
            for (int i = 4; i <= 6; ++ i)
            {
                for (int j = 2; j >= 0; -- j)
                {
                    x--;
                    Button b = new Button();
                    b.Font = new Font("Arial", 15, FontStyle.Italic);
                    b.Size = new Size(75, 60);
                    b.Location = new Point(j * 75, i * 60);
                    b.Text = x.ToString();
                    b.Click += new EventHandler(ButtonClick);
                    this.Controls.Add(b);
                }
            }
            for (int i = 0; i < 3; ++ i)
            {
                Button b = new Button();
                b.Font = new Font("Arial", 15, FontStyle.Italic);
                b.Size = new Size(75, 60);
                b.Location = new Point(i * 75, 420);
                if (i == 0)
                    b.Text = "+/-";
                if (i == 1)
                    b.Text = "0";
                if (i == 2)
                    b.Text = ".";
                b.Click += new EventHandler(ButtonClick);
                this.Controls.Add(b);
            }
        }
        void Add_Oper()
        {
            for (int i = 3; i <= 7; ++ i)
            {
                Button b = new Button();
                b.Font = new Font("Arial", 15, FontStyle.Italic);
                b.Size = new Size(75, 60);
                b.Location = new Point(3 * 75, i * 60);
                if (i == 3)
                    b.Text = "/";
                if (i == 4)
                    b.Text = "*";
                if (i == 5)
                    b.Text = "-";
                if (i == 6)
                    b.Text = "+";
                if (i == 7)
                    b.Text = "=";
                b.Click += new EventHandler(ButtonClick);
                this.Controls.Add(b);
            }
        }
        public Form1()
        {
            InitializeComponent();
            //this.BackColor = System.Drawing.Color.White;
            Add_M();
            Add_Functions();
            Add_Numbers();
            Add_C();
            Add_Oper();
        }
        bool Check (Button button)
        {
            if (button.Text == "CE")
            {
                FirstN = 0;
                SecondN = 0;
                lastOperation = '1';
                lastOperation2 = '1';
                textBox1.Text = "0";
                MS = 0;
            }
            else if (button.Text == "C")
            {
                textBox1.Text = "0";
            }
            else if (button.Text == "←")
            {
                string s = textBox1.Text;
                if (s.Length <= 1)
                {
                    s = "0";
                }
                else
                {
                    string S = "";
                    for (int i = 0; i < s.Length - 1; ++i)
                        S += s[i];
                    s = S;
                }
                textBox1.Text = s;
            }
            else if (button.Text == "+")
            {
                if (LastO != true)
                    SecondN = double.Parse(textBox1.Text);
                else
                    SecondN = 0;
                if (lastOperation != '+' && LastO != true)
                {
                    if (lastOperation == '-')
                        FirstN -= SecondN;
                    if (lastOperation == '*')
                        FirstN *= SecondN;
                    if (lastOperation == '/')
                        FirstN /= SecondN;
                }
                else
                    FirstN += SecondN;
                lastOperation = '+';
                lastOperation2 = '+';
                textBox1.Text = FirstN.ToString();
            }
            else if (button.Text == "-")
            {
                if (LastO != true)
                    SecondN = double.Parse(textBox1.Text);
                else
                    SecondN = 0;
                if (lastOperation == '1')
                    FirstN = SecondN;
                else if (lastOperation != '-' && LastO != true)
                {
                    if (lastOperation == '+')
                        FirstN += SecondN;
                    if (lastOperation == '*')
                        FirstN *= SecondN;
                    if (lastOperation == '/')
                        FirstN /= SecondN;
                }
                else
                    FirstN -= SecondN;
                lastOperation = '-';
                lastOperation2 = '-';
                textBox1.Text = FirstN.ToString();
            }
            else if (button.Text == "*")
            {
                SecondN = double.Parse(textBox1.Text);
                if (LastO != true)
                    SecondN = double.Parse(textBox1.Text);
                else
                    SecondN = 1;
               // MessageBox.Show(FirstN.ToString());
                if (lastOperation == '1')
                    FirstN = SecondN;
                else if (lastOperation != '*' && LastO != true)
                {
                    if (lastOperation == '+')
                        FirstN += SecondN;
                    if (lastOperation == '-')
                        FirstN -= SecondN;
                    if (lastOperation == '/')
                        FirstN /= SecondN;
                }
                else
                    FirstN *= SecondN;
                lastOperation = '*';
                lastOperation2 = '*';
                textBox1.Text = FirstN.ToString();
            }
            else if (button.Text == "/")
            {
                SecondN = double.Parse(textBox1.Text);
                if (LastO != true)
                    SecondN = double.Parse(textBox1.Text);
                else
                    SecondN = 1;

                if (lastOperation == '1')
                    FirstN = SecondN;
                else if (lastOperation != '/' && LastO != true)
                {
                    if (lastOperation == '+')
                        FirstN += SecondN;
                    if (lastOperation == '-')
                        FirstN -= SecondN;
                    if (lastOperation == '*')
                        FirstN *= SecondN;
                }
                else
                    FirstN /= SecondN;
                lastOperation = '/';
                lastOperation2 = '/';
                textBox1.Text = FirstN.ToString();
            }
            else if (button.Text == "=")
            {
                if (LastO != true)
                    SecondN = double.Parse(textBox1.Text);
                else
                    lastOperation = lastOperation2;
                if (lastOperation == '+')
                    FirstN += SecondN;
                else if (lastOperation == '-')
                    FirstN -= SecondN;
                else if (lastOperation == '*')
                    FirstN *= SecondN;
                else if (lastOperation == '/')
                    FirstN /= SecondN;
                else
                    FirstN = SecondN;
                textBox1.Text = FirstN.ToString();
                lastOperation = '=';
            }
            else if (button.Text == "√")
            {
                FirstN = double.Parse(textBox1.Text);
                FirstN = Math.Sqrt(FirstN);
                textBox1.Text = FirstN.ToString();
            }
            else if (button.Text == "1/x")
            {
                FirstN = double.Parse(textBox1.Text);
                FirstN = 1/FirstN;
                textBox1.Text = FirstN.ToString();
            }
            else if (button.Text == "x^2")
            {
                FirstN = double.Parse(textBox1.Text);
                FirstN = FirstN * FirstN;
                textBox1.Text = FirstN.ToString();
            }
            else if (button.Text == "%")
            {

            }
            else if (button.Text == "x^3")
            {
                FirstN = double.Parse(textBox1.Text);
                FirstN = FirstN * FirstN * FirstN;
                textBox1.Text = FirstN.ToString();
            }
            else
                return false;
            return true;
        }
        void ButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (Check(button))
                LastO = true;
            else
            {
                if (button.Text[0] == 'M')
                {
                    if (button.Text == "MS")
                    {
                        MS = double.Parse(textBox1.Text);
                        textBox1.Text = "0";
                    }
                    else if (button.Text == "M+")
                    {
                        MS += double.Parse(textBox1.Text);
                    }
                    else if (button.Text == "M-")
                    {
                        MS -= double.Parse(textBox1.Text);
                    }
                    else if (button.Text == "MR")
                    {
                        textBox1.Text = MS.ToString();
                    }
                    else if (button.Text == "MC")
                    {
                        MS = 0;
                    }
                }
                else if (button.Text == "+/-")
                {
                    string s = textBox1.Text;
                    if (s[0] == '-')
                    {
                        string S = "";
                        for (int i = 1; i < s.Length; ++i)
                            S += s[i];
                        s = S;
                    }
                    else if (s[0] != '0')
                    {
                        s = "-" + s;
                    }
                    textBox1.Text = s;
                }
                else
                {
                    if (LastO == true)
                        textBox1.Text = "";
                    if (lastOperation == '=')
                    {
                        lastOperation = '1';
                        lastOperation2 = '1';
                        textBox1.Text = "0";
                        FirstN = 0;
                        SecondN = 0;
                    }
                    if (textBox1.Text == "0")
                        textBox1.Text = "";
                    if (button.Text == ".")
                    {
                        if (textBox1.Text[textBox1.Text.Length - 1] != ',')
                            textBox1.Text += ',';
                    }
                    else
                        textBox1.Text += button.Text;
                }
                LastO = false;
            }
        }
    }
}
