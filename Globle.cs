namespace Remake_Simulator_Csharp
{
    class Globle
    {
        public static FormStart formStart = new FormStart();
        public static FormBg formBg = new FormBg();
        public static FormPoints formPoints = new FormPoints();
        public static FormMain formMain = new FormMain();
        public static FormEnd formEnd = new FormEnd();

        public static void Initialize()
        {
            time = 1900;
            difficult = Difficult.Easy;
            isAlive = true;
            age = intelligence = fitness = wealth = appearance = fortunate = 0;
            gender = Gender.男性;
            birth = BirthPlace.城市;
            isMagicLearned = isManualDistEnabled = isAsexual = isIntersexual = isRevivable = false;
            rollChance = 3;
            points = 20;
            eventIndex = -1;
            //formPoints.PointsInitialize();
            //formMain.Remake();
            formStart.StartInitialize();
            System.Console.WriteLine("[info]全局变量已重置,准备/remake!");
        }//重新开始游戏时的初始化
        public enum Gender
        {
            男性,
            女性,
            兼性,
            无性
        }
        public enum Difficult
        {
            Easy,
            Normal,
            Difficult
        }
        public enum BirthPlace
        {
            城市,
            乡村,
        }

        public enum Language
        {
            Zh_CN,
            En_US,
        }

        public static bool isDebug = true;//是否启用调试
        public static Language lang = Language.Zh_CN;//语言

        //背景设置
        public static int time = 1900;//当前时间
        public static Difficult difficult = Difficult.Easy;//难度
        public static int remakeCnt = 0;

        //人物基础属性
        public static bool isAlive = true;//是否活着
        public static int age = 0;//年龄
        public static int intelligence = 0;//智力
        public static int fitness = 0;//体质
        public static int wealth = 0;//财富
        public static int appearance = 0;//容貌
        public static int fortunate = 0;//幸运
        public static Gender gender = Gender.男性;//性别
        public static BirthPlace birth = BirthPlace.城市;//出生地
        public static int happiness = 10;//幸福指数

        //人物能力属性
        public static bool isMagicLearned = false;//能否使用魔法
        public static bool isManualDistEnabled = false;//能否手动分配点数
        public static bool isAsexual = false;//是否锁定无性
        public static bool isIntersexual = false;//是否锁定兼性
        public static bool isRevivable = false;//能否复活

        //剩余抽取能力次数
        public static int rollChance = 3;

        //剩余可分配点数
        public static int points = 20;

        //当前事件id
        public static int eventIndex = -1;
    }
}
