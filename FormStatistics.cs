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
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            listView1.Items.Add(new ListViewItem(new string[] {"最长生存时间",Globle.maxLiveSpan.ToString() }));
            listView1.Items.Add(new ListViewItem(new string[] { "最多事件发生数", Globle.maxEventOccur.ToString() }));
            listView1.Items.Add(new ListViewItem(new string[] { "最多新闻浏览数", Globle.maxNewsBrowse.ToString() }));
            listView1.Items.Add(new ListViewItem(new string[] { "最高得分", Globle.maxScore.ToString() }));
            listView1.Items.Add(new ListViewItem(new string[] { "总生存时间", Globle.totalLiveSpan.ToString() }));
            listView1.Items.Add(new ListViewItem(new string[] { "总事件发生数", Globle.totalEventOccur.ToString() }));
            listView1.Items.Add(new ListViewItem(new string[] { "总得分", Globle.totalScore.ToString() }));
            for (int i = 0; i < Achievements.achievements.Length;i++)
            {
                if(Achievements.achievements[i].AchievementObtained == true)
                {
                    string[] achievement = { Achievements.achievements[i].AchievementName, Achievements.achievements[i].AchievementDescription, Achievements.achievements[i].AchievementLevel.ToString(), Achievements.achievements[i].AchievementObtainedTime };
                    ListViewItem listViewItem = new ListViewItem(achievement);
                    listView2.Items.Add(listViewItem);
                }
            }
        }
    }
}
