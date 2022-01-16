using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace CPS_Test
{
    public partial class Form1 : MaterialForm
    {
        int timeLeft;
        int clicks = 0;
        int selectedTime = 5;

        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey900, Primary.Grey700, Accent.LightBlue200, TextShade.WHITE);

            materialLabel1.Left = (this.Width - materialLabel1.Width) / 2;
            materialLabel2.Left = (this.Width - materialLabel2.Width) / 2;
            materialButton1.Left = (this.Width - materialButton1.Width) / 2;
            materialTextBox1.Left = (this.Width - materialTextBox1.Width) / 2;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                materialLabel2.Text = "Time left: " + timeLeft + "s";
            }
            else
            {
                timer1.Stop();
                MaterialMessageBox.Show("Your CPS is: " + (clicks / selectedTime).ToString(), "Time's up!");
                clicks = 0;
                materialLabel1.Text = "Total clicks: " + clicks.ToString();
                materialLabel2.Text = "Time left: Not started";
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (clicks == 0)
            {
                timeLeft = selectedTime;
                timer1.Start();
                materialLabel2.Text = "Time left: " + selectedTime + "s";
            }
            clicks++;

            materialLabel1.Text = "Total clicks: " + clicks.ToString();
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            int x;
            Int32.TryParse(materialTextBox1.Text, out x);

            selectedTime = x;
        }
    }
}
