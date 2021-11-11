using System;
using System.Drawing;
using System.Windows.Forms;

namespace Remake_Simulator_Csharp
{
    enum Rareness
    {
        普通,
        稀有,
        史诗,
        传说
    }
    static class Abilities
    {
        static int seed = Guid.NewGuid().GetHashCode();
        static System.Random rd = new System.Random(seed);//初始化随机数生成器
        public static int cumulation = 0;//累计概率
        public static int cnt = 0;//计数器，记录当前的能力序号
        public struct Ability
        {
            readonly int _number;//能力序号
            readonly string _name;//能力名称
            readonly string _des;//能力描述
            readonly int _cumuPoss;//累计抽取概率(所有之前的抽取概率之和)
            readonly Rareness _rare;//能力稀有程度，和颜色有关
            readonly bool _sole;//唯一能力，无法被叠加

            public Ability(string abilityName, string abilityDescription, int possibility, Rareness rareness, bool sole = false)
            {
                this._number = cnt++;
                this._name = abilityName;
                this._des = abilityDescription;
                this._cumuPoss = cumulation - possibility;
                cumulation -= possibility;
                this._rare = rareness;
                this._sole = sole;
            }
            //能力结构的构造函数

            public int CumulationPossibility
            {
                get { return this._cumuPoss; }
                set { }
            }
            //累计概率属性
            public int Number
            {
                get { return this._number; }
                set { }
            }
            //能力序号属性
            public string AbilityName
            {
                get { return this._name; }
                set { }
            }
            //能力名称属性
            public string AbilityDescription
            {
                get { return this._des; }
                set { }
            }
            //能力描述属性
            public Rareness AbilityRareness
            {
                get { return this._rare; }
                set { }
            }
            //能力稀有度属性
            public bool Sole
            {
                get { return this._sole; }
                set { }
            }
            //唯一能力属性
        }
        public static Ability[] abilities =
        {
       /*
        * 添加新能力的模板
        * new Ability(
        *   "能力名称",
        *   "能力描述",
        *   能力抽取概率,
        *   能力稀有度
        *   ),
        *   抽取到某能力的概率 = 该能力抽取概率/所有能力抽取概率之和
        */
       new Ability(
           "【史诗】魔法",
           "未知的力量在你手中流动...\n" +
           "你被赐予了使用魔法的能力",
           5,
           Rareness.史诗,
           true
           ),

       new Ability(
           "强身健体",
           "体质+3",
           50,
           Rareness.普通
           ),

       new Ability(
           "智慧",
           "智力+3",
           50,
           Rareness.普通
           ),

       new Ability(
           "幸运",
           "变得更加幸运",
           50,
           Rareness.普通
           ),

       new Ability(
           "什么也没有",
           "Nothing at all",
           50,
           Rareness.普通
           ),

       new Ability(
           "腰缠万贯",
           "财富+3",
           50,
           Rareness.普通
           ),
       new Ability(
           "【稀有】我命由我",
           "获得自由分配点数的能力",
           30,
           Rareness.稀有,
           true
           ),
       new Ability(
           "【稀有】人中龙凤",
           "锁定性别为兼性\n" +
           "该能力将覆盖不食烟火",
           15,
           Rareness.稀有,
           true
           ),
       new Ability(
           "【稀有】不食烟火",
           "锁定性别为无性\n" +
           "该能力将被人中龙凤覆盖",
           15,
           Rareness.稀有,
           true
           ),
       new Ability(
           "【史诗】超越生死",
           "将你从死亡的边缘带回\n" +
           "\"什么？不死图腾？!\"",
           10,
           Rareness.史诗,
           true
           ),
       new Ability(
           "【传说】循环嵌套",
           "能力重抽次数+3\n" +
           "\"我的愿望就是...再来三个愿望！\"",
           1,
           Rareness.传说,
           false
           ),
    };
        public static int RandomPickAbility()
        {
            int abilityNo = -1;//初始化抽到的能力序号
            int randomRes = rd.Next(System.Math.Abs(cumulation));
            /*
             * 能力抽取机制：随机一个0~cumulation的值
             * 选中累计概率大于等于这个值中累计概率最小的那个能力
             * 因为foreach函数使用了迭代器，无法从后向前遍历，所以我将所有概率取相反数，大于和小于互换，原理没变
             * 如果重构的话改用for函数可更加直白
             * 2021/9/4 Yichen
             */
            randomRes *= -1;
            foreach (Ability ab in abilities)
            {
                if (ab.CumulationPossibility <= randomRes)
                {
                    abilityNo = ab.Number;
                    break;
                }
            }
            return abilityNo;
        }

        public static void AbilitySelect(int index)
        {
            switch (index)
            {
                case 0:
                    Globle.isMagicLearned = true;
                    break;
                case 1:
                    Globle.fitness += 3;
                    break;
                case 2:
                    Globle.intelligence += 3;
                    break;
                case 3:
                    Globle.fortunate += 2;
                    break;
                case 4:
                    break;
                case 5:
                    Globle.wealth += 3;
                    break;
                case 6:
                    Globle.isManualDistEnabled = true;
                    break;
                case 7:
                    Globle.isIntersexual = true;
                    break;
                case 8:
                    Globle.isAsexual = true;
                    break;
                case 9:
                    Globle.isRevivable = true;
                    break;
                case 10:
                    Globle.rollChance += 3;
                    break;
            }//根据选择的能力调整数值
        }

        public static void AbilityNameDisplay(this RichTextBox rtBox, int abilityIndex)
        {
            switch (abilities[abilityIndex].AbilityRareness)
            {
                case Rareness.普通:
                    RichTextBoxExtension.AppendTextColorful(rtBox, abilities[abilityIndex].AbilityName, Color.Gray);
                    break;
                case Rareness.稀有:
                    RichTextBoxExtension.AppendTextColorful(rtBox, abilities[abilityIndex].AbilityName, Color.Blue);
                    break;
                case Rareness.史诗:
                    RichTextBoxExtension.AppendTextColorful(rtBox, abilities[abilityIndex].AbilityName, Color.Violet);
                    break;
                case Rareness.传说:
                    RichTextBoxExtension.AppendTextColorful(rtBox, abilities[abilityIndex].AbilityName, Color.Orange);
                    break;
            }
            //向富文本框添加能力名称
        }

        public static void AbilityDescriptionDisplay(this RichTextBox rtBox, int abilityIndex)
        {
            switch (abilities[abilityIndex].AbilityRareness)
            {
                case Rareness.普通:
                    RichTextBoxExtension.AppendTextColorful(rtBox, abilities[abilityIndex].AbilityDescription, Color.Gray);
                    break;
                case Rareness.稀有:
                    RichTextBoxExtension.AppendTextColorful(rtBox, abilities[abilityIndex].AbilityDescription, Color.Blue);
                    break;
                case Rareness.史诗:
                    RichTextBoxExtension.AppendTextColorful(rtBox, abilities[abilityIndex].AbilityDescription, Color.Violet);
                    break;
                case Rareness.传说:
                    RichTextBoxExtension.AppendTextColorful(rtBox, abilities[abilityIndex].AbilityDescription, Color.Orange);
                    break;
            }
            //向富文本框添加能力描述
            if (abilities[abilityIndex].Sole)
            {
                RichTextBoxExtension.AppendTextColorful(rtBox, "唯一能力：该能力无法被叠加", Color.Crimson);
            }
        }
    }
}
