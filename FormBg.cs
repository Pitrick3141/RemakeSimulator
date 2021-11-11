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
    public partial class FormBg : Form
    {
        public FormBg()
        {
            InitializeComponent();
        }
        private void FormBg_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
            Globle.time = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Globle.remakeCnt != 0)
                Globle.formPoints.PointsInitialize();
            Globle.formPoints.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * 颜色使用标准（拟订）
             * 
             * 提升 Color.Gold
             * 降低 Color.BlueViolet
             * 
             * 有利事件 Color.SpringGreen
             * 不利事件 Color.Crimson
             * 
             * 普通 Color.Gray（默认）
             * 稀有 Color.Blue 【稀有】
             * 史诗 Color.Violet 【史诗】
             * 传说 Color.Orange 【传说】
             */
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Globle.difficult = Globle.Difficult.Easy;
                    richTextBox1.Clear();
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "简单难度", Color.SpringGreen);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "适合第一次进行游戏的玩家", Color.Gray);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "几乎不会", Color.BlueViolet,false);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "因为意外而死亡", Color.Gray);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "将会变得比较", Color.Gray,false);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "幸运", Color.SpringGreen);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "突发事件的发生几率", Color.Gray,false);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "降低", Color.BlueViolet);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "历史相关时间发生几率", Color.Gray,false);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "降低", Color.BlueViolet);
                    break;
                case 1:
                    Globle.difficult = Globle.Difficult.Normal;
                    richTextBox1.Clear();
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "普通难度", Color.Gold);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "适合比较有经验的玩家", Color.Gray);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "各种事件发生几率均为默认", Color.Gray);
                    break;
                case 2:
                    Globle.difficult = Globle.Difficult.Difficult;
                    richTextBox1.Clear();
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "困难难度", Color.Orange);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "适合有丰富经验的玩家", Color.Gray);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "有较大几率", Color.Gold, false);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "因为意外而死亡", Color.Gray);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "将会变得比较", Color.Gray, false);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "不幸", Color.Crimson);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "突发事件的发生几率", Color.Gray, false);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "提升", Color.Gold);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "历史相关时间发生几率", Color.Gray, false);
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, "提升", Color.Gold);
                    break;
            }
            button1.Enabled = true;
        }
    }
}
