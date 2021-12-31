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
    public partial class FormEnd : Form
    {
        public int score = 0;
        public double scoreCoef = 1;//得分系数
        public FormEnd()
        {
            InitializeComponent();
        }

        private void AddComment(int commentType)
        {
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "  评价：", Color.Gray,false);
            switch (commentType)
            {
                case 0:
                    switch (Globle.age)
                    {
                        case int n when (n < 10):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "夭折", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 40):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "短命", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 100):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "正寝", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 150):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "长寿", Color.Orange);
                            score += 10;
                            break;
                        default:
                            Achievements.AchievementsObtain(3);
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "仙龄", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 1:
                    switch (Globle.appearance)
                    {
                        case int n when (n < 4):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "不堪入目", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 7):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "平平无奇", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 12):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "相貌出众", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 20):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "倾国倾城", Color.Orange);
                            score += 10;
                            break;
                        default:
                            Achievements.AchievementsObtain(4);
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "天仙下凡", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 2:
                    switch (Globle.intelligence)
                    {
                        case int n when (n < 4):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "愚昧无知", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 7):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "泯然众人", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 12):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "天资聪慧", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 20):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "颖悟绝人", Color.Orange);
                            score += 10;
                            break;
                        default:
                            Achievements.AchievementsObtain(5);
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "慧眼秋毫", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 3:
                    switch (Globle.fitness)
                    {
                        case int n when (n < 4):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "体弱多病", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 7):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "常人体魄", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 12):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "身强力壮", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 20):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "百毒不侵", Color.Orange);
                            score += 10;
                            break;
                        default:
                            Achievements.AchievementsObtain(6);
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "金身罗汉", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 4:
                    switch (Globle.wealth)
                    {
                        case int n when (n < 4):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "家徒四壁", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 7):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "小康家庭", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 12):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "家底殷实", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 20):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "富可敌国", Color.Orange);
                            score += 10;
                            break;
                        default:
                            Achievements.AchievementsObtain(7);
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "财倾天下", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 5:
                    switch (Globle.eventOccur)
                    {
                        case int n when (n < 15):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "不经世故", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 30):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "初出茅庐", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 45):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "走南闯北", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 60):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "轻车熟路", Color.Orange);
                            score += 10;
                            break;
                        default:
                            Achievements.AchievementsObtain(8);
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "博古通今", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 6:
                    switch (Globle.newsBrowse)
                    {
                        case int n when (n < 10):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "耳目闭塞", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 20):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "独学寡闻", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 35):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "手不释卷", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 50):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "博览群书", Color.Orange);
                            score += 10;
                            break;
                        default:
                            Achievements.AchievementsObtain(9);
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "枕典席文", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
            }
        }
        public void EndInitialize()
        {
            System.Console.WriteLine("[info]人生总结模块已重置！");
            richTextBox1.Clear();

            RichTextBoxExtension.AppendTextColorful(richTextBox1, "你的一生结束了...", Color.Crimson);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "本次游戏难度：", Color.Black, false);
            switch (Globle.difficult)
            {
                case Globle.Difficult.Easy:
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "简单", Color.SpringGreen);
                    scoreCoef = 0.7;
                    break;
                case Globle.Difficult.Normal:
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "普通", Color.Gold);
                    scoreCoef = 1;
                    break;
                case Globle.Difficult.Difficult:
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "困难", Color.Orange);
                    scoreCoef = 1.3;
                    break;
            }

            RichTextBoxExtension.AppendTextColorful(richTextBox1, "你享年", Color.Black, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, Globle.age.ToString(), Color.CornflowerBlue, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "岁(" + (Globle.time - Globle.age).ToString() + " - " + Globle.time.ToString() + ")", Color.Black, false);
            AddComment(0);
            
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "容貌：", Color.Black, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, Globle.appearance.ToString(), Color.CornflowerBlue,false);
            AddComment(1);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "智力：", Color.Black, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, Globle.intelligence.ToString(), Color.CornflowerBlue,false);
            AddComment(2);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "体质：", Color.Black, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, Globle.fitness.ToString(), Color.CornflowerBlue,false);
            AddComment(3);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "财富：", Color.Black, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, Globle.wealth.ToString(), Color.CornflowerBlue,false);
            AddComment(4);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "事件发生次数：", Color.Black, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, Globle.eventOccur.ToString(), Color.CornflowerBlue, false);
            AddComment(5);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "新闻浏览次数：", Color.Black, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, Globle.newsBrowse.ToString(), Color.CornflowerBlue, false);
            AddComment(6);
            score = (int)(scoreCoef*score);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, "总计得分：", Color.Black, false);
            RichTextBoxExtension.AppendTextColorful(richTextBox1, (score).ToString(), Color.CornflowerBlue, false);
            if (score > 125)
            {
                Achievements.AchievementsObtain(10);
            }
            if(score > Globle.maxScore)
            {
                Globle.maxScore = score;
            }
            Globle.totalScore += score;
        }
        private void FormEnd_Load(object sender, EventArgs e)
        {
                EndInitialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗？", "退出游戏", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Globle.SaveGame();
                System.Environment.Exit(0);
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globle.remakeCnt++;
            Globle.Initialize();
            Globle.formStart.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormStatistics formStatistics = new FormStatistics();
            formStatistics.Show();
        }
    }
}
