using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remake_Simulator_Csharp
{
    public partial class FormPoints : Form
    {
        readonly Random rd = new Random();
        int appeEx = 0, inteEx = 0, fitEx = 0, wealEx = 0;
        int rollChance = 5;

        private void check()
        {
            int usedPoints = 0;
            try
            {
                usedPoints = Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox6.Text) + Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox8.Text);
            }
            catch
            {
                
            }
            if (usedPoints == Globle.points || Globle.isDebug == true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            label11.Text = (Globle.points - usedPoints).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Globle.appearance += appeEx;
            Globle.intelligence += inteEx;
            Globle.fitness += fitEx;
            Globle.wealth += wealEx;
            if(Globle.remakeCnt != 0)
            {
                Globle.formMain.Remake();
            }
            Globle.formMain.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBox5.Text);
                if (value >= 0 && value <= 10 || Globle.isDebug == true)
                {
                    appeEx = value;
                    check();
                }
                    
                else
                    textBox5.Text = "0";
            }
            catch
            {
                textBox5.Text = "0";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBox6.Text);
                if (value >= 0 && value <= 10 || Globle.isDebug == true)
                {
                    inteEx = value;
                    check();
                }    
                else
                    textBox6.Text = "0";
            }
            catch
            {
                textBox6.Text = "0";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBox7.Text);
                if (value >= 0 && value <= 10 || Globle.isDebug == true)
                {
                    fitEx = value;
                    check();
                }
                else
                    textBox7.Text = "0";
            }
            catch
            {
                textBox7.Text = "0";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBox8.Text);
                if (value >= 0 && value <= 10 || Globle.isDebug == true)
                {
                    wealEx = value;
                    check();
                }
                else
                    textBox8.Text = "0";
            }
            catch
            {
                textBox8.Text = "0";
            }
        }

        public FormPoints()
        {
            InitializeComponent();
        }
        public void PointsInitialize()
        {
            System.Console.WriteLine("[info]加点模块已重置！");
            rollChance = 5;
            label11.Text = Globle.points.ToString();
            textBox1.Text = Globle.appearance.ToString();
            textBox2.Text = Globle.intelligence.ToString();
            textBox3.Text = Globle.fitness.ToString();
            textBox4.Text = Globle.wealth.ToString();
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            button2.Text = "随机分配点数";
            button2.Enabled = true;
            if (Globle.isManualDistEnabled)
            {
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                label12.Visible = true;
                button2.Enabled = false;
            }
            else
            {
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                label12.Visible = false;
                button2.Enabled = true;
            }
        }
        private void FormPoints_Load(object sender, EventArgs e)
        {
            if(Globle.remakeCnt == 0)
            {
                PointsInitialize();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label11.Text = "0";
            int chance = Globle.points;
            appeEx = inteEx = fitEx = wealEx = 0;
            rollChance--;
            if(rollChance > 0)
            {
                button2.Text = "剩余重新分配次数：" + rollChance.ToString();
            }
            else
            {
                button2.Text = "重新分配次数已用完！";
                button2.Enabled = false;
            }
            while (chance > 0)
            {
                chance--;
                int r = rd.Next(4);
                switch (r)
                {
                    case 0:
                        appeEx++;
                        break;
                    case 1:
                        inteEx++;
                        break;
                    case 2:
                        fitEx++;
                        break;
                    case 3:
                        wealEx++;
                        break;
                }
            }
            textBox5.Text = appeEx.ToString();
            textBox6.Text = inteEx.ToString();
            textBox7.Text = fitEx.ToString();
            textBox8.Text = wealEx.ToString();
        }
    }
}
