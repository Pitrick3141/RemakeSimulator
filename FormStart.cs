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
    public partial class FormStart : Form
    {

        public int abilityIndex1, abilityIndex2, abilityIndex3;
        public void AbilityChooseInitiallize(bool start)
        {
            if(start)
            {
                ButtonSelect1.Enabled = true;
                ButtonSelect2.Enabled = true;
                ButtonSelect3.Enabled = true;
                ButtonRoll.Enabled = false;
                richTextBox1.Clear();
                richTextBox2.Clear();
                richTextBox3.Clear();
                richTextBox4.Clear();
                richTextBox5.Clear();
                richTextBox6.Clear();
                ButtonSelect1.Text = "选择";
                ButtonSelect2.Text = "选择";
                ButtonSelect3.Text = "选择";
                //开始能力选择
                //设置抽取按钮不可交互，直到选中能力后才可交互,设置选择能力按钮可交互
            }
            else
            {
                ButtonSelect1.Enabled = false;
                ButtonSelect2.Enabled = false;
                ButtonSelect3.Enabled = false;
                if(Globle.rollChance > 0)
                {
                    ButtonRoll.Enabled = true;
                    //只有还有抽取次数的时候才激活抽取按钮
                }
                //结束能力选择
                //初始化选择界面，防止多个能力被选中，同时开始下一次能力抽取
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            Abilities.AbilitySelect(abilityIndex1);
            AbilityChooseInitiallize(false);
            ButtonSelect1.Text = "已选择";
            //选中第一个能力
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Abilities.AbilitySelect(abilityIndex2);
            AbilityChooseInitiallize(false);
            ButtonSelect2.Text = "已选择";
            //选中第二个能力
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Abilities.AbilitySelect(abilityIndex3);
            AbilityChooseInitiallize(false);
            ButtonSelect3.Text = "已选择";
            //选中第三个能力
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globle.formBg.Show();
            this.Hide();
        }

        public void StartInitialize()
        {
            if(Globle.isDebug == true)
            {
                System.Console.WriteLine("[debug]能力选择模块已重置");
            }
            ButtonRoll.Text = "抽取能力";
            ButtonRoll.Enabled = true;
        }
        private void FormStart_Load(object sender, EventArgs e)
        {
            if(Globle.remakeCnt == 0)
            {
                RandomEvents.EventsInitiallize();
                Achievements.AchievementsInitiallize();
                Abilities.AbilityInitialize();
                RandomNews.NewsInitialize();
            }
            Globle.ReadGame();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Globle.isDebug == true && MenuDebug.Visible == false)
            {
                System.Console.WriteLine("[debug]已开启debug模式");
                MenuDebug.Visible = true;
            }
        }

        private void MenuSkipAbility_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("[debug]已跳过能力选择");
            if (Globle.remakeCnt != 0)
                Globle.formPoints.PointsInitialize();
            Globle.formPoints.Show();
            this.Hide();
        }

        private void MenuEnableManualDist_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("[debug]已开启手动分配点数");
            Globle.isManualDistEnabled = true;
        }

        private void MenuAchievementTest_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("[debug]已生成测试成就");
            Achievements.AchievementsObtain(0);
        }

        private void ButtonStatistics_Click(object sender, EventArgs e)
        {
            FormStatistics formStatistics = new FormStatistics();
            formStatistics.Show();
        }

        public FormStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            abilityIndex1 = Abilities.RandomPickAbility();
            abilityIndex2 = Abilities.RandomPickAbility();
            abilityIndex3 = Abilities.RandomPickAbility();
            //初始抽取能力

            while (abilityIndex2 == abilityIndex1)
            {
                abilityIndex2 = Abilities.RandomPickAbility();
            }
            while (abilityIndex3 == abilityIndex1 || abilityIndex3 == abilityIndex2)
            {
                abilityIndex3 = Abilities.RandomPickAbility();
            }
            //防止抽出相同能力

            Globle.rollChance--;
            //减少一次重抽机会

            AbilityChooseInitiallize(true);
            //初始化

            Abilities.AbilityNameDisplay(richTextBox1, abilityIndex1);
            Abilities.AbilityNameDisplay(richTextBox2, abilityIndex2);
            Abilities.AbilityNameDisplay(richTextBox3, abilityIndex3);
            Abilities.AbilityDescriptionDisplay(richTextBox4, abilityIndex1);
            Abilities.AbilityDescriptionDisplay(richTextBox5, abilityIndex2);
            Abilities.AbilityDescriptionDisplay(richTextBox6, abilityIndex3);
            //将技能名称与描述添加到按钮上

            if (Globle.rollChance > 0)
            {
                ButtonRoll.Text = "剩余" + Globle.rollChance + "次抽取机会";
                //更改按钮名称，显示剩余次数
            }
            else
            {
                ButtonRoll.Text = "抽取次数已用完！";
                ButtonNext.Enabled = true;
                //抽取次数用完，开放下一阶段
            }
        }

    }
}
