using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator {
    public partial class Default : System.Web.UI.Page {

        private const int mantissaLimit = 16;

        private static double decimalResult;
        private static string binaryResult;

        private string DecimalToBinary(double x) {
            string integral = Convert.ToString(Convert.ToInt32(Math.Floor(x)), 2);
            string fractional = String.Empty;

            if (x - Math.Floor(x) != 0) {
                fractional += ".";
                for (int i = 0; i < mantissaLimit; i++) {
                    x = (x - Math.Floor(x)) * 2;
                    if (x == 0) {
                        break;
                    }
                    fractional += Convert.ToString(Convert.ToInt32(Math.Floor(x)));
                }
            }

            return integral + fractional;
        }

        protected void Page_Load(object sender, EventArgs e) {}

        protected void CalculateButton_Click(object sender, EventArgs e) {
            double x = Double.TryParse(FirstValueTextBox.Text, out x) ? x : x = 0;
            double y = Double.TryParse(SecondValueTextBox.Text, out y) ? y : y = 0;

            switch (OperatorDropDownList.Text) {
                case "+": decimalResult = x + y; break;
                case "-": decimalResult = x - y; break;
                case "*": decimalResult = x * y; break;
                case "/": decimalResult = x / y; break;
            }

            binaryResult = DecimalToBinary(decimalResult);
            DecimalTextBox.Text = decimalResult.ToString();
            BinaryTextBox.Text = binaryResult;
            ZeroCountTextBox.Text = String.Empty;
            OneCountTextBox.Text = String.Empty;
        }

        protected void CountButton_Click(object sender, EventArgs e) {
            ZeroCountTextBox.Text = binaryResult.Count(x => x == '0').ToString();
            OneCountTextBox.Text = binaryResult.Count(x => x == '1').ToString();
        }
    }
}