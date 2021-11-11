using System;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Remake_Simulator_Csharp
{
    static class RandomEvents
    {
        static int seed = Guid.NewGuid().GetHashCode();
        static System.Random rd = new System.Random(seed);//初始化随机数生成器
        public static int cumulation = 0;//累计概率
        public static int cnt = 0;//计数器，记录当前的事件序号
        
        public struct Event
        {
            readonly int _number;//事件序号
            string _name;//事件名称
            string _des;//事件描述
            string[] _res;//事件结果
            readonly int _minage;//事件发生的最小年龄
            readonly int _maxage;//事件发生的最大年龄
            readonly bool _sole;//唯一新闻
            int _occur;//发生次数
            /*
             * 最小最大均为0则是不会自然发生
             * 最小最大均为-1则是没有年龄限制，随时都可以发生
            */
            readonly int _cumuposs;//事件发生的累计概率

            public Event(int eventResults,int eventMinAge,int eventMaxAge,int eventPossibility,bool sole = false, string eventName = "",string eventDescription = "")
            {
                this._number = cnt++;
                this._name = eventName;
                this._des = eventDescription;
                this._res = new string[eventResults];
                this._minage = eventMinAge;
                this._maxage = eventMaxAge;
                this._cumuposs = cumulation - eventPossibility;
                cumulation -= eventPossibility;
                this._sole = sole;
                this._occur = 0;
            }//事件结构的构造函数

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
            public string EventName
            {
                get { return this._name; }
                set { this._name = value; }
            }
            public string EventDescription
            {
                get { return this._des; }
                set { this._des = value; }
            }
            public int EventMinAge
            {
                get { return this._minage; }
                set { }
            }
            public int EventMaxAge
            {
                get { return this._maxage; }
                set { }
            }
            public void SetEventResult(int index,string value) 
            {
                this._res[index] = value;
                return;
            }
            public string EventResult(int index)
            {
                return this._res[index];
            }

            public int EventPossibleResultNumber
            {
                get { return this._res.Length; }
                set { }
            }
            public bool IsSoleEvent()
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
        
        public static Event[] events =
        {
            //new Event(结果数量,最小出现年龄,最大出现年龄,出现概率)
            new Event(3,1,8,1),//0
            new Event(4,4,12,1),//1
            new Event(0,2,5,10),//2
            new Event(1,4,10,10),//3
            new Event(0,3,10,10),//4
            new Event(4,0,0, 0),//5
            new Event(3,0,0,0),//6
            new Event(3,0,0,0),//7,上学事件的变体，财富不足4时触发
            new Event(3,0,0,0),//8,上学事件的变体，财富不足4时触发
            new Event(0,-1,-1,5),//9
            new Event(1,0,0,0),//10,看新闻的变体，在1982年前触发
        };
        public static void EventsInitiallize()
        {
            string scriptName;
            switch(Globle.lang)//根据语言选择资源文件
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
            for (int i = 0;i<events.Length;i++)
            {
                events[i].EventName = rm.GetString("eventName" + events[i].Number.ToString());
                events[i].EventDescription = rm.GetString("eventDescription" + events[i].Number.ToString());
                for(int j = 0;j<events[i].EventPossibleResultNumber;j++)
                {
                    events[i].SetEventResult(j, rm.GetString("eventResult" + events[i].Number.ToString() + "-" + j.ToString()));
                }
            }
        }
        public static int RandomPickEvent(int age)
        {
            int eventNo = -1;//初始化抽到的事件序号      
            while(eventNo == -1 ||events[eventNo].IsSoleEvent() == false || events[eventNo].EventMinAge > age || events[eventNo].EventMaxAge < age && events[eventNo].EventMinAge != -1 && events[eventNo].EventMaxAge != -1)
            {
                int randomRes = rd.Next(System.Math.Abs(cumulation));
                randomRes *= -1;
                foreach (Event ev in events)
                {
                    if (ev.CumulationPossibility <= randomRes)
                    {
                        eventNo = ev.Number;
                        break;
                    }
                }
            }
            if (Globle.isDebug == true)
                System.Console.WriteLine("[debug]选中了序号为{0}的事件\"{1}\"", eventNo, events[eventNo].EventName);
            events[eventNo].Occur();
            return eventNo;
        }
        public static bool Check(int checkType,int checkRequ)
        {
            switch(checkType)
            {
                case 0:
                    if (Globle.appearance >= checkRequ)
                    {
                        System.Console.WriteLine("[check]进行一个容貌判定：【成功】" + Globle.appearance.ToString() + "/" + checkRequ.ToString());
                        return true;
                    }   
                    else
                    {
                        System.Console.WriteLine("[check]进行一个容貌判定：【失败】" + Globle.appearance.ToString() + "/" + checkRequ.ToString());
                        return false;
                    }
                case 1:
                    if (Globle.intelligence >= checkRequ)
                    {
                        System.Console.WriteLine("[check]进行一个智力判定：【成功】" + Globle.intelligence.ToString() + "/" + checkRequ.ToString());
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("[check]进行一个智力判定：【失败】" + Globle.intelligence.ToString() + "/" + checkRequ.ToString());
                        return false;
                    }
                case 2:
                    if (Globle.fitness >= checkRequ)
                    {
                        System.Console.WriteLine("[check]进行一个体质判定：【成功】" + Globle.fitness.ToString() + "/" + checkRequ.ToString());
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("[check]进行一个体质判定：【失败】" + Globle.fitness.ToString() + "/" + checkRequ.ToString());
                        return false;
                    }
                case 3:
                    if (Globle.wealth >= checkRequ)
                    {
                        System.Console.WriteLine("[check]进行一个财富判定：【成功】" + Globle.wealth.ToString() + "/" + checkRequ.ToString());
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("[check]进行一个财富判定：【失败】" + Globle.wealth.ToString() + "/" + checkRequ.ToString());
                        return false;
                    }
                case 4:
                    int chance = rd.Next(10);
                    if (Globle.fortunate + chance >= checkRequ)
                    {
                        System.Console.WriteLine("[check]进行一个幸运判定：【成功】" + Globle.fortunate.ToString() + "+" + chance.ToString() + "/" + checkRequ.ToString());
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("[check]进行一个幸运判定：【失败】" + Globle.fortunate.ToString() + "+" + chance.ToString() + "/" + checkRequ.ToString());
                        return false;
                    }
                default:
                    return true;
            }
        }
        //Check判定(0容貌/1智力/2体质/3财富/4幸运,需要值)
        public static string EventOccur(int index)
        {
            int requ = 0;
            switch(Globle.difficult)
            {
                case Globle.Difficult.Easy:
                    requ = 1;
                    break;
                case Globle.Difficult.Normal:
                    requ = 3;
                    break;
                case Globle.Difficult.Difficult:
                    requ = 5;
                    break;
            }
            switch(index)
            {
                case 0:
                    if(Check(2,requ+3))//体质判定
                    {
                        return events[index].EventDescription + events[index].EventResult(0);
                    }
                    else if(Check(4,requ+2))//幸运判定
                    {
                        return events[index].EventDescription + events[index].EventResult(1);
                    }
                    else
                    {
                        Globle.isAlive = false;
                        return events[index].EventDescription + events[index].EventResult(2);
                    }
                case 1:
                    if (Globle.time < 1960)
                        index = 5;//时间变体：马车
                    if (Check(2,requ+5))//体质判定
                    {
                        return events[index].EventDescription + events[index].EventResult(0);
                    }
                    else if (Check(4,requ+3))//幸运判定
                    {
                        return events[index].EventDescription + events[index].EventResult(1);
                    }
                    else if(Globle.isMagicLearned)
                    {
                        return events[index].EventDescription + events[index].EventResult(3);
                    }
                    else
                    {
                        Globle.isAlive = false;
                        return events[index].EventDescription + events[index].EventResult(2);
                    }
                case 2:
                    Globle.happiness += 1;
                    return events[index].EventDescription;
                case 3:
                    Globle.happiness -= 1;
                    if (Globle.time == 1904)
                    {
                        return events[index].EventDescription + events[index].EventResult(0);
                        //1904年，科举考试被正式废除
                    }
                    return events[index].EventDescription;
                case 4:
                    Globle.happiness += 2;
                    return events[index].EventDescription;
                case 6:
                    if (Globle.wealth < 4)
                        index = 7;//变体：破旧的学校
                    else if (Globle.gender == Globle.Gender.兼性 || Globle.gender == Globle.Gender.无性)
                    {
                        index = 8;//变体：身体的秘密
                        if(Check(0,requ+3))
                        {
                            Globle.happiness += 3;
                            return events[index].EventDescription + events[index].EventResult(0);
                        }
                        else if(Check(4,requ+2))
                        {
                            Globle.happiness += 2;
                            return events[index].EventDescription + events[index].EventResult(1);
                        }
                        else
                        {
                            Globle.happiness -= 2;
                            return events[index].EventDescription + events[index].EventResult(2);
                        }

                    } 
                    if(Check(1,requ+3))
                    {
                        Globle.happiness += 3;
                        return events[index].EventDescription + events[index].EventResult(0);
                    }
                    else if(Check(4,requ+2))
                    {
                        Globle.happiness += 2;
                        return events[index].EventDescription + events[index].EventResult(1);
                    }
                    else
                    {
                        return events[index].EventDescription + events[index].EventResult(2);
                    }
                case 9:
                    {
                        //新闻
                        if(Globle.time<=1982)
                        {
                            index = 10;//变体：报纸
                            if (Globle.age > 8||Check(1,5))
                                return events[index].EventDescription + RandomNews.NewsOccur(RandomNews.RandomPickNews());
                            else
                                return events[index].EventDescription + events[index].EventResult(0);

                        }
                        return events[index].EventDescription + RandomNews.NewsOccur(RandomNews.RandomPickNews());
                    }
                default:
                    {
                        return events[index].EventDescription;
                    }
            }
        }
    }
}
