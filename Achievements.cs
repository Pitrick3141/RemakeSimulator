using System;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace Remake_Simulator_Csharp
{
    class Achievements
    {
        public struct Achievement
        {
            string _name;//成就名称
            string _des;//成就描述
            bool _obtained;//是否已经获得
            int _level;//成就等级
            string _time;//获取时间

            public Achievement(int achievementLevel)
            {
                this._name = "";
                this._des = "";
                this._obtained = false;
                this._level = achievementLevel;
                this._time = "";
            }//成就结构的构造函数
            public string AchievementName
            {
                get { return this._name; }
                set { this._name = value; }
            }
            public string AchievementDescription
            {
                get { return this._des; }
                set { this._des = value; }
            }
            public bool AchievementObtained
            {
                get { return this._obtained; }
                set { this._obtained = value; }
            }
            public int AchievementLevel
            {
                get { return this._level; }
                set { }
            }public string AchievementObtainedTime
            {
                get { return this._time; }
                set { this._time = value; }
            }
        };

        public static Achievement[] achievements =
        {
            new Achievement(0),//测试成就
            new Achievement(1),//Hello World!
            new Achievement(1),//寄!
            new Achievement(2),//仙寿
            new Achievement(2),//天仙下凡
            new Achievement(2),//慧眼秋毫
            new Achievement(2),//金身罗汉
            new Achievement(2),//财倾天下
            new Achievement(2),//博古通今
            new Achievement(2),//枕典席文
            new Achievement(3),
        };
        public static void AchievementsInitiallize()
        {
            string scriptName;
            switch (Globle.lang)//根据语言选择资源文件
            {
                case Globle.Language.Zh_CN:
                    scriptName = "Remake_Simulator_Csharp.Scripts.ScriptsZh_CN";
                    break;
                default:
                    scriptName = "Remake_Simulator_Csharp.Scripts.ScriptsZh_CN";
                    break;
            }
            ResourceManager rm = new ResourceManager(scriptName, Assembly.GetExecutingAssembly());
            //从资源文件读取文案
            for (int i = 0; i < achievements.Length; i++)
            {
                achievements[i].AchievementName = rm.GetString("achievementName" + i.ToString());
                achievements[i].AchievementDescription = rm.GetString("achievementDescription" + i.ToString());
            }
        }
        public static void AchievementsObtain(int index)
        {   
            if(achievements[index].AchievementObtained == true && index != 0)
            {
                return;
            }
            if(Globle.isDebug == true)
            {
                Console.WriteLine("[debug]已获得成就" + achievements[index].AchievementName + ":" + achievements[index].AchievementDescription);
            }
            achievements[index].AchievementObtained = true;
            achievements[index].AchievementObtainedTime = DateTime.Now.ToString("yyyy-MM-dd");
            FormAchievement formAchievement = new FormAchievement(index);
            formAchievement.Show();
        }
    }
}
