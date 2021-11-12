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
    public partial class FormAchievement : Form
    {
        public FormAchievement(int index)
        {
            InitializeComponent();
            labelTitle.Text = Achievements.achievements[index].AchievementName;
            switch(Achievements.achievements[index].AchievementLevel)
            {
                case 0:
                    labelTitle.ForeColor = Color.Gray;
                    break;
                case 1:
                    labelTitle.ForeColor = Color.Blue;
                    break;
                case 2:
                    labelTitle.ForeColor = Color.Violet;
                    break;
                case 3:
                    labelTitle.ForeColor = Color.Orange;
                    break;
                default:
                    labelTitle.ForeColor = Color.Gray;
                    break;
            }
            
            labelDes.Text = Achievements.achievements[index].AchievementDescription;
            if (Globle.isDebug == true)
            {
                Console.WriteLine("[debug]成就弹窗已生成");
            }
        }

        private void FormAchievement_Load(object sender, EventArgs e)
        {
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) *4 / 5;
            this.Location = (Point)new Size(x, y);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity < 1)
            {
                this.Opacity += 0.1;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(this.Opacity>0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                if(Globle.isDebug == true)
                {
                    Console.WriteLine("[debug]成就弹窗已销毁");
                }
                this.Close();
            }
        }

        private void FormAchievement_Paint(object sender, PaintEventArgs e)
        {
            #region 圆形窗体
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();//创建一条线
            path.AddEllipse(0, -50, Width, Height+100);//画一个椭圆 （x,y,宽,高）
            Graphics g = CreateGraphics();//为窗体创建画布
            g.DrawEllipse(new Pen(Color.Goldenrod, 10), 0, -50, Width, Height + 100);//为画布画一个椭圆(笔,x,y，宽,高)
            g.DrawLine(new Pen(Color.Goldenrod, 10), 0, Height, Width, Height);
            g.DrawLine(new Pen(Color.Goldenrod, 10), 0, 0, Width, 0);
            Region = new Region(path);//设置控件的窗口区域
            #endregion
        }
    }
}
