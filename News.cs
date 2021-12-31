using System;
using System.Resources;
using System.Reflection;

namespace Remake_Simulator_Csharp
{
    static class RandomNews
    {
        public static WeightedRandom newsRandom = new WeightedRandom();
        static int seed = Guid.NewGuid().GetHashCode();
        static System.Random rd = new System.Random(seed);//初始化随机数生成器
        public static int cnt = 0;//计数器，记录当前的新闻序号

        public struct News
        {
            readonly int _number;//新闻序号
            string _name;//新闻名称
            string _des;//新闻描述
            string[] _res;//新闻结果
            readonly int _minyear;//新闻发生的最早年份
            readonly int _maxyear;//新闻发生的最晚年份
            readonly bool _sole;//唯一新闻
            int _occur;//发生次数
            /*
             * 最小最大均为0则是不会自然发生
             * 最小最大均为-1则是没有年份限制，随时都可以发生
            */
            readonly int _poss;//新闻发生的概率

            public News(int newsResults, int newsMinYear, int newsMaxYear, int newsPossibility,bool sole = false,string newsName = "",string newsDescription = "")
            {
                this._number = cnt++;
                this._name = newsName;
                this._des = newsDescription;
                this._res = new string[newsResults];
                this._minyear = newsMinYear;
                this._maxyear = newsMaxYear;
                this._poss = newsPossibility;
                this._sole = sole;
                this._occur = 0;
            }//新闻结构的构造函数

            public int Possibility
            {
                get { return this._poss; }
                set { }
            }
            public int Number
            {
                get { return this._number; }
                set { }
            }
            public string NewsName
            {
                get { return this._name; }
                set { this._name = value; }
            }
            public string NewsDescription
            {
                get { return this._des; }
                set { this._des = value; }
            }
            public int NewsMinYear
            {
                get { return this._minyear; }
                set { }
            }
            public int NewsMaxYear
            {
                get { return this._maxyear; }
                set { }
            }
            public void SetNewsResult(int index, string value)
            {
                this._res[index] = value;
                return;
            }
            public string NewsResult(int index)
            {
                return this._res[index];
            }

            public int NewsPossibleResultNumber
            {
                get { return this._res.Length; }
                set { }
            }
            public bool IsSoleNews()
            {
                if (this._sole && this._occur != 0)
                    return false;
                return true;
            }
            public void Occur()
            {
                this._occur++;
            }

        };
        public static News[] news =
        {
            new News(0,2020,2040,5,true),//0
            new News(0,-1,-1,5),//1
            new News(0,1976,2100,5),//2
            new News(0,1901,1901,25),//3
            new News(0,1904,1904,25),//4
            new News(0,1905,1905,25),//5
            new News(0,1911,1911,25),//6
            new News(0,1912,1912,25),//7
            new News(0,1913,1913,25),//8
            new News(0,1914,1914,25),//9
            new News(0,1915,1915,25),//10
            new News(0,1916,1916,25),//11
            new News(0,1917,1917,25),//12
            new News(0,1918,1918,25),//13

        };
        public static void NewsInitialize()
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
            if (Globle.isDebug == true)
            {
                Console.WriteLine("[info]News资源文件读取完成");
            }
            //从资源文件读取文案
            for (int i = 0; i < news.Length; i++)
            {
                news[i].NewsName = rm.GetString("newsName" + news[i].Number.ToString());
                news[i].NewsDescription = rm.GetString("newsDescription" + news[i].Number.ToString());
                for (int j = 0; j < news[i].NewsPossibleResultNumber; j++)
                {
                    news[i].SetNewsResult(j, rm.GetString("newsResult" + news[i].Number.ToString() + "-" + j.ToString()));
                }
            }
            int[] weightList = new int[cnt];
            foreach (News current in news)
            {
                weightList[current.Number] = current.Possibility;
            }
            newsRandom.RandomInitiallize(weightList);
            if (Globle.isDebug == true)
            {
                Console.WriteLine("[info]News类初始化完成");
            }
        }
        public static void PossibilityAdjust()
        {
            int[] weightList = new int[cnt];
            foreach (News current in news)
            {
                weightList[current.Number] = current.Possibility;
            }
            newsRandom.RandomInitiallize(weightList);
            if (Globle.isDebug == true)
            {
                Console.WriteLine("[info]News概率修改已生效");
            }
        }
        public static int RandomPickNews()
        {
            int time = Globle.time;
            int newsNo = -1;//初始化抽到的新闻序号      
            while ( newsNo == -1 || news[newsNo].IsSoleNews() == false || news[newsNo].NewsMinYear > time || news[newsNo].NewsMaxYear < time && news[newsNo].NewsMinYear != -1 && news[newsNo].NewsMaxYear != -1)
            {
                newsNo = newsRandom.GetRandomIndex();
            }
            if(Globle.isDebug == true)
                System.Console.WriteLine("[info]选中了序号为{0}的新闻\"{1}\"",newsNo,news[newsNo].NewsName);
            news[newsNo].Occur();
            return newsNo;
        }
        public static string NewsOccur(int index)
        {
            Globle.newsBrowse++;
            switch(index)
            {
                default:
                    return news[index].NewsDescription;
            }
        }
    }
}
