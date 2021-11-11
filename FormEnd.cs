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
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "仙龄", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 1:
                    switch (Globle.appearance)
                    {
                        case int n when (n < 3):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "不堪入目", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 6):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "平平无奇", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 10):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "相貌出众", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 15):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "倾国倾城", Color.Orange);
                            score += 10;
                            break;
                        default:
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "天仙下凡", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 2:
                    switch (Globle.intelligence)
                    {
                        case int n when (n < 3):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "愚昧无知", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 6):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "泯然众人", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 10):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "天资聪慧", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 15):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "颖悟绝人", Color.Orange);
                            score += 10;
                            break;
                        default:
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "慧眼秋毫", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 3:
                    switch (Globle.fitness)
                    {
                        case int n when (n < 3):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "体弱多病", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 6):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "常人体魄", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 10):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "身强力壮", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 15):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "百毒不侵", Color.Orange);
                            score += 10;
                            break;
                        default:
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "金身罗汉", Color.Crimson);
                            score += 20;
                            break;
                    }
                    break;
                case 4:
                    switch (Globle.wealth)
                    {
                        case int n when (n < 3):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "家徒四壁", Color.Gray);
                            score += 1;
                            break;
                        case int n when (n < 6):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "小康家庭", Color.Blue);
                            score += 3;
                            break;
                        case int n when (n < 10):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "家底殷实", Color.Violet);
                            score += 5;
                            break;
                        case int n when (n < 15):
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "富可敌国", Color.Orange);
                            score += 10;
                            break;
                        default:
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, "财倾天下", Color.Crimson);
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
                    break;
                case Globle.Difficult.Normal:
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "普通", Color.Gold);
                    break;
                case Globle.Difficult.Difficult:
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "困难", Color.Orange);
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
            
        }
        private void FormEnd_Load(object sender, EventArgs e)
        {
            if(Globle.remakeCnt == 0)
            {
                EndInitialize();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗？", "退出游戏", MessageBoxButtons.YesNo) == DialogResult.Yes)
                System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globle.remakeCnt++;
            Globle.Initialize();
            Globle.formStart.Show();
            this.Hide();
        }
    }
}
