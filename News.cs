using System;

namespace Remake_Simulator_Csharp
{
    static class RandomNews
    {
        static int seed = Guid.NewGuid().GetHashCode();
        static System.Random rd = new System.Random(seed);//初始化随机数生成器
        public static int cumulation = 0;//累计概率
        public static int cnt = 0;//计数器，记录当前的新闻序号

        public struct News
        {
            readonly int _number;//新闻序号
            readonly string _name;//新闻名称
            readonly string _des;//新闻描述
            readonly string[] _res;//新闻结果
            readonly int _minyear;//新闻发生的最早年份
            readonly int _maxyear;//新闻发生的最晚年份
            readonly bool _sole;//唯一新闻
            int _occur;//发生次数
            /*
             * 最小最大均为0则是不会自然发生
             * 最小最大均为-1则是没有年份限制，随时都可以发生
            */
            readonly int _cumuposs;//新闻发生的累计概率

            public News(string newsName, string newsDescription, string[] newsResults, int newsMinYear, int newsMaxYear, int newsPossibility,bool sole = false)
            {
                this._number = cnt++;
                this._name = newsName;
                this._des = newsDescription;
                this._res = newsResults;
                this._minyear = newsMinYear;
                this._maxyear = newsMaxYear;
                this._cumuposs = cumulation - newsPossibility;
                cumulation -= newsPossibility;
                this._sole = sole;
                this._occur = 0;
            }//新闻结构的构造函数

            public int CumulationPossibility
            {
                get { return this._cumuposs; }
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
                set { }
            }
            public string NewsDescription
            {
                get { return this._des; }
                set { }
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
            new News(
                "蒙古上单",//0
                "今日哔哩哔哩CEO陈睿母亲逝世",
                new string[] {},
                2020,
                2040,
                5,
                true),
            new News(
                "法国暴乱",//1
                "今日法国发生一起暴乱事件",
                new string[] {},
                -1,
                -1,
                5),
            new News(
                "打入八强",//2
                "在本届世界杯中，中国男足成功打入八强",
                new string[] {},
                1976,
                2100,
                5),
            new News(
                "辛丑条约",//3
                "光绪二十七年，清政府签订辛丑条约",
                new string[] {},
                1901,
                1901,
                25),
            new News(
                "日俄战争",//4
                "日本与俄国在中国东北地区以及朝鲜半岛地区开战，俄国战败",
                new string[] {},
                1904,
                1904,
                25),
            new News(
                "同盟会成立",//5
                "中国同盟会在日本东京成立,选举孙中山为总理",
                new string[] {},
                1905,
                1905,
                25),
            new News(
                "武昌起义",//6
                "武昌起义打响，辛亥革命开始",
                new string[] {},
                1911,
                1911,
                25),
            new News(
                "中华民国成立",//7
                "中华民国临时大总统孙中山在南京就职，宣告中华民国成立",
                new string[] {},
                1912,
                1912,
                25),
            new News(
                "二次革命",//8
                "二次革命失败，袁世凯当任大总统",
                new string[] {},
                1913,
                1913,
                25),
            new News(
                "第一次世界大战",//9
                "斐迪南大公夫妇在萨拉热窝遇刺，第一次世界大战爆发",
                new string[] {},
                1914,
                1914,
                25),
            new News(
                "护国运动",//10
                "蔡锷在云南起义，组织护国军，讨伐袁世凯",
                new string[] {},
                1915,
                1915,
                25),
            new News(
                "护国运动结束",//11
                "袁世凯去世，黎元洪继任总统",
                new string[] {},
                1916,
                1916,
                25),
            new News(
                "护法运动",//12
                "孙中山在广州发动护法运动",
                new string[] {},
                1917,
                1917,
                25),
            new News(
                "第一次世界大战结束",//13
                "德国投降，一战以同盟国的失败为告终",
                new string[] {},
                1918,
                1918,
                25),

        };
        public static int RandomPickNews()
        {
            int time = Globle.time;
            int newsNo = -1;//初始化抽到的新闻序号      
            while ( newsNo == -1 || news[newsNo].IsSoleNews() == false || news[newsNo].NewsMinYear > time || news[newsNo].NewsMaxYear < time && news[newsNo].NewsMinYear != -1 && news[newsNo].NewsMaxYear != -1)
            {
                int randomRes = rd.Next(System.Math.Abs(cumulation));
                randomRes *= -1;
                if (Globle.isDebug == true)
                    System.Console.WriteLine("[debug]随机新闻累计概率为{0}", randomRes);
                foreach (News ne in news)
                {
                    if (ne.CumulationPossibility <= randomRes)
                    {
                        newsNo = ne.Number;
                        break;
                    }
                }
            }
            if(Globle.isDebug == true)
                System.Console.WriteLine("[debug]选中了序号为{0}的新闻\"{1}\"",newsNo,news[newsNo].NewsName);
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
