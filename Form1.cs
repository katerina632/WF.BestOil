using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Controls.ComboBox
{
    public partial class Form1 : Form
    {
        decimal price, amountGas, sumGas, sumCafe = 0, totalSum, revenueRerDay=0;
        decimal sumHotDog = 0, sumFri=0, sumCola=0, sumHamb=0;

        Timer timer = new Timer();

        
        public Form1()
        {
            InitializeComponent();
            gasComboBox.SelectedIndex = 0;

            timer.Tick += new EventHandler(ShowTimer); 

        }

        private void ShowTimer(object vObject, EventArgs e)
        {
            timer.Stop();

            DialogResult res= MessageBox.Show("Clear form?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                revenueRerDay += totalSum;

                gasComboBox.SelectedIndex = 0;

                amountRadioButton1.Checked = false;
                sumRadioButton1.Checked = false;

                amountTextBox1.Enabled = false;
                amountTextBox1.Text = "";


                sumTextBox.Enabled = false;
                sumTextBox.Text = "";
                totalSumGasLabel.Text = "0";
                totalSumLabel.Text = "0";

                foreach (CheckBox cb in miniCafeGroupBox.Controls.OfType<CheckBox>())
                {

                    cb.Checked = false;
                }               

            }
            else 
            {                
                timer.Interval = 10 * 1000;
                timer.Start();
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            totalSum = sumGas + sumCafe;
            totalSumLabel.Text = totalSum.ToString();
           

            timer.Interval = 10 * 1000;
            timer.Start();
           
        }
        private void sumRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (sumRadioButton1.Checked)
            {
                amountTextBox1.Text = "";
                amountTextBox1.Enabled = false;
                sumTextBox.Enabled = true;
                groupBox2.Text = "Before issuing";
                label6.Text = "l";
                totalSumGasLabel.Text = "";
            }
        }

        private void amountRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (amountRadioButton1.Checked)
            {
                amountTextBox1.Enabled = true;
                sumTextBox.Text = "";
                sumTextBox.Enabled = false;
                groupBox2.Text = "To pay";
                label6.Text = "UAH";
                totalSumGasLabel.Text = "";
            }
        }
        private void sumTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sumRadioButton1.Checked)
                sumGas = int.Parse(sumTextBox.Text);

            amountGas = sumGas / price;

            totalSumGasLabel.Text = String.Format("{0:f2}", amountGas);
        }

        private void amountTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (amountRadioButton1.Checked)
                amountGas = int.Parse(amountTextBox1.Text);


            sumGas = price * amountGas;

            totalSumGasLabel.Text = sumGas.ToString();

        }

        private void hamburgerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hamburgerCheckBox.Checked)
            {
               hamburgerNumericUpDown2.Enabled = true;
            }
            else
            {
                hamburgerNumericUpDown2.Value = 0;
                hamburgerNumericUpDown2.Enabled = false;
            }
        }

        private void friCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (friCheckBox.Checked)
            {
                friNumericUpDown3.Enabled = true;
            }
            else
            {
                friNumericUpDown3.Value = 0;
                friNumericUpDown3.Enabled = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show($"Revenue per day: {revenueRerDay}", "TOTAL");
        }

        private void colaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (colaCheckBox.Checked)
            {
                colaNumericUpDown4.Enabled = true;
            }
            else
            {
                colaNumericUpDown4.Value = 0;
                colaNumericUpDown4.Enabled = false;
            }
        }

        private void hamburgerNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            sumHamb = Convert.ToDecimal(hamburgerCheckBox.Tag) * hamburgerNumericUpDown2.Value;
            sumCafe = sumCola + sumFri + sumHamb + sumHotDog;
            sumCafeLabel.Text = sumCafe.ToString();
        }

        private void friNumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            sumFri = Convert.ToDecimal(friCheckBox.Tag) * friNumericUpDown3.Value;
            sumCafe = sumCola + sumFri + sumHamb + sumHotDog;
            sumCafeLabel.Text = sumCafe.ToString();
        }

        private void colaNumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            sumCola = Convert.ToDecimal(colaCheckBox.Tag) * colaNumericUpDown4.Value;
            sumCafe = sumCola + sumFri + sumHamb + sumHotDog;
            sumCafeLabel.Text = sumCafe.ToString();
        }                

       

        private void hotDogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hotDogCheckBox.Checked)
            {
                hotDogNumericUpDown1.Enabled = true;
            }
            else
            {
                hotDogNumericUpDown1.Value=0;
                hotDogNumericUpDown1.Enabled = false;
            }
        }

        private void hotDogNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {           
            sumHotDog = Convert.ToDecimal(hotDogCheckBox.Tag) * hotDogNumericUpDown1.Value;
            sumCafe = sumCola + sumFri + sumHamb + sumHotDog;
            sumCafeLabel.Text = sumCafe.ToString();
        }       

        private void gasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (gasComboBox.SelectedIndex)
            {
                case 0:
                    price = 28.13M;

                    ChangeGasPrice(e);
                    break;
                case 1:
                    price = 25.05M;
                    ChangeGasPrice(e);
                    break;
                case 2:
                    price = 25.49M;
                    ChangeGasPrice(e);
                    break;
                case 3:
                    price = 23.14M;
                    ChangeGasPrice(e);
                    break;
                default:
                    break;
            }
        }

        private void ChangeGasPrice(EventArgs e)
        {
            priceTextBox3.Text = price.ToString();
            if (sumRadioButton1.Checked && !string.IsNullOrEmpty(sumTextBox.ToString()))
            {
                sumTextBox_TextChanged(sumRadioButton1, e);
            }
            if (amountRadioButton1.Checked && !string.IsNullOrEmpty(amountTextBox1.ToString()))
            {
                amountTextBox1_TextChanged(amountRadioButton1, e);
            }
        }
        
    }
}
