using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            KeyPreview = true; // Enable KeyPreview
            KeyDown += new KeyEventHandler(Calculator_KeyDown);
        }

        #region KeyPresses
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearInput();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                buttonEnter_Click(sender, e);
            }
            InputBox.Text.Trim();
        }
        #endregion

        private void Calculator_Load(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            InputBox.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputBox.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputBox.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InputBox.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InputBox.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InputBox.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InputBox.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InputBox.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InputBox.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InputBox.Text += "9";
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            //Calculate
            var calculation = InputBox.Text;
            var calcList = new List<string>();
            if(calculation.Contains("+"))
            {
                calcList = calculation.Split('+').ToList();
                calcList.Add("+");
            } 
            else if(calculation.Contains("-"))
            {
                calcList = calculation.Split('-').ToList();
                calcList.Add("-");
            }
            else if(calculation.Contains("*"))
            {
                calcList = calculation.Split('*').ToList();
                calcList.Add("*");
            }
            else if (calculation.Contains("/"))
            {
                calcList = calculation.Split('/').ToList();
                calcList.Add("/");
            }
            else
            {
                InputBox.Clear();
                return;
            }

            var value1 = float.Parse(calcList[0]);
            var value2 = float.Parse(calcList[1]);
            var operation = calcList[2];

            Calculate(value1, operation, value2);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            InputBox.Text += "-";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            InputBox.Text += "*";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            InputBox.Text += "+";
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            InputBox.Text += ".";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            InputBox.Text += "/";
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            RemoveLeadingZeros();
            InputBox.Text.Trim();
        }

        // custom functions
        private void RemoveLeadingZeros()
        {
            if (string.IsNullOrEmpty(InputBox.Text))
                return;

            InputBox.Text = InputBox.Text.TrimStart('0');
        }

        private void Calculate(float value1, string operation, float value2)
        {
            switch (operation)
            {
                case "+":
                {
                    var result = value1 + value2;
                    PrintResult(result.ToString());
                    break;
                }
                case "-":
                {
                    var result = value1 - value2;
                    PrintResult(result.ToString());
                    break;
                }
                case "*":
                {
                    var result = value1 * value2;
                    PrintResult(result.ToString());
                    break;
                }
                case "/":
                {
                    var result = value1 / value2;
                    PrintResult(result.ToString());
                    break;
                }
            }
        }

        private void PrintResult(string result)
        {
            InputBox.Text = result;
        }

        private void ClearInput()
        {
            InputBox.Clear();
        }
    }
}
