using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            var count = await Task<int>.Factory.StartNew(()=>
            {
                int year = (DateTime.Now.Date.Year - dateTimePicker1.Value.Date.Year);
                return year;
            });
            

            

            if (count > -1 && count < 135)
                textBox1.Text = count.ToString();
            else
            {
                MessageBoxButtons button = MessageBoxButtons.OK;
                string message = "Необхідно ввести вік, що не перевищує 135 років";
                string caption = "Помилка вводу віку";
                DialogResult result = MessageBox.Show(message, caption, button);
                if (result == System.Windows.Forms.DialogResult.OK)
                    dateTimePicker1.Value = DateTime.Now.AddDays(-1);
            }

            var zodiac1 = await Task<string>.Factory.StartNew(() =>
            {
                int day = dateTimePicker1.Value.Day;
                int month = dateTimePicker1.Value.Month;
                string sign;
                switch (month)
                {
                    case 1: sign = (day <= 20) ? "Козеріг" : "Водолій"; break;
                    case 2: sign = (day <= 19) ? "Водолій" : "Риби"; break;
                    case 3: sign = (day <= 20) ? "Риби" : "Овен"; break;
                    case 4: sign = (day <= 20) ? "Овен" : "Телець"; break;
                    case 5: sign = (day <= 21) ? "Телець" : "Близнюки"; break;
                    case 6: sign = (day <= 21) ? "Близнюки" : "Рак"; break;
                    case 7: sign = (day <= 22) ? "Рак" : "Лев"; break;
                    case 8: sign = (day <= 23) ? "Лев" : "Діва"; break;
                    case 9: sign = (day <= 23) ? "Діва" : "Терези"; break;
                    case 10: sign = (day <= 23) ? "Терези" : "Скорпіон"; break;
                    case 11: sign = (day <= 22) ? "Скорпіон" : "Стрілець"; break;
                    case 12: sign = (day <= 23) ? "Стрілець" : "Козеріг"; break;
                    default: sign = ""; break;
                }

                return sign;
            });

            var zodiac2 = await Task<string>.Factory.StartNew(() =>
            {
                int ch_year = dateTimePicker1.Value.Year % 12;
                string output;
                switch (ch_year)
                {
                    case 0:  output = "Мавпа"; break;
                    case 1: output = "Півень"; break;
                    case 2: output = "Собака"; break;
                    case 3: output = "Свиня"; break;
                    case 4: output = "Пацюк"; break;
                    case 5: output = "Бик"; break;
                    case 6: output = "Тигр"; break;
                    case 7: output = "Кролик"; break;
                    case 8: output = "Дракон"; break;
                    case 9: output = "Змія"; break;
                    case 10: output = "Кінь"; break;
                    case 11: output = "Коза"; break;
                    default: output = ""; break;
                }
                return output;
            });

            textBox2.Text = zodiac1;
            textBox3.Text = zodiac2;




            dateTimePicker1.Enabled = true;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
