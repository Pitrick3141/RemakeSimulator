using System;
using System.Windows.Forms;

namespace Remake_Simulator_Csharp
{
    public partial class FormMain : Form
    {
        public Random rd = new Random();
        public void Info(string content)
        {
            string strSplit = "";
            int strMaxLength = 100;//每行最大允许长度
            bool isStrTooLong = false;
            if(content.Length > strMaxLength)
            {
                strSplit = content.Substring(strMaxLength);
                content = content.Substring(0,strMaxLength);
                isStrTooLong = true;
                //分割超出最大长度部分
            }
            bool scroll = false;
            if (this.listBox1.TopIndex == this.listBox1.Items.Count - (int)(this.listBox1.Height / this.listBox1.ItemHeight))
                scroll = true;//自动判断是否需要滚动
            listBox1.Items.Add(content);//向listbox添加项目
            if (scroll)
                this.listBox1.TopIndex = this.listBox1.Items.Count - (int)(this.listBox1.Height / this.listBox1.ItemHeight);//自动滚动
            if(isStrTooLong)
            {
                Info(strSplit);
                //对超长部分进行递归输出
            }
        }
        public void Remake()
        {
            //初始化
            if(Globle.isDebug == true)
            {
                System.Console.WriteLine("[debug]主界面初始化成功");
            }
            Achievements.AchievementsObtain(1);//获得成就：Hello World!
            listBox1.Items.Clear();
            button3.Visible = false;
            button1.Enabled = true;
            int gend = rd.Next(100);
            switch (gend)
            {
                case int n when (n < 1):
                    Globle.gender = Globle.Gender.兼性;
                    break;
                case int n when (n < 2):
                    Globle.gender = Globle.Gender.无性;
                    break;
                case int n when (n < 51):
                    Globle.gender = Globle.Gender.男性;
                    break;
                case int n when (n < 100):
                    Globle.gender = Globle.Gender.女性;
                    break;
            }
            if (Globle.isIntersexual)
                Globle.gender = Globle.Gender.兼性;
            else if(Globle.isAsexual)
                 Globle.gender = Globle.Gender.无性;
            int bir = rd.Next(10);
            if (Globle.wealth >= 6 && bir > 3 || bir > 7)
            {
                Globle.birth = Globle.BirthPlace.城市;
            }
            else
            {
                Globle.birth = Globle.BirthPlace.乡村;
            }
            Info(Globle.time.ToString() + "年的某一天，随着一声啼哭，你出生在了某国家的" + Globle.birth.ToString());
            Info("随后，医生发现你是" + Globle.gender.ToString());
        }
        public FormMain()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Globle.remakeCnt != 0)
            {
                Globle.formEnd.EndInitialize();
            }
            Globle.formEnd.Show();
            this.Hide();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(Globle.remakeCnt == 0)
            {
                Remake();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globle.time++;
            Globle.age++;
            switch(Globle.age)
            {
                default:
                    Info(Globle.age.ToString() + "岁时，" + RandomEvents.EventOccur(RandomEvents.RandomPickEvent(Globle.age)));
                    break;
                case 6:
                    Info(Globle.age.ToString() + "岁时，" + RandomEvents.EventOccur(6));//固定事件：入学
                    break;

            }
            if(!Globle.isAlive)
            {
                if(Globle.isRevivable)
                {
                    Info("超越生死能力发动！");
                    Info("你从死亡的边缘归来...");
                    Globle.isRevivable = false;
                    Globle.isAlive = true;
                }
                else
                {
                    Achievements.AchievementsObtain(2);//获得成就：寄！
                    Info("你寄了...点击人生总结按钮查看得分");
                    button1.Enabled = false;
                    button3.Visible = true;
                }
                //死亡结算
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //查询当前状态
            Info("当前是" + Globle.time + "年");
            Info("你现在" + Globle.age + "岁");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormStatistics formStatistics = new FormStatistics();
            formStatistics.Show();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Globle.isDebug == true)
            {
                MenuDebug.Visible = true;
            }
        }

        private void MenuSuicide_Click(object sender, EventArgs e)
        {
            Achievements.AchievementsObtain(2);
            Info("你寄了...点击人生总结按钮查看得分");
            button1.Enabled = false;
            button3.Visible = true;
        }
    }
}
