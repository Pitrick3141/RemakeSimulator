using System;
using System.Resources;
using System.Reflection;
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
        public static WeightedRandom abilityRandom = new WeightedRandom();
        public static int cnt = 0;//计数器，记录当前的能力序号
        public struct Ability
        {
            readonly int _number;//能力序号
            string _name;//能力名称
            string _des;//能力描述
            readonly int _poss;//抽取概率
            readonly Rareness _rare;//能力稀有程度，和颜色有关
            readonly bool _sole;//唯一能力，无法被叠加

            public Ability(int possibility, Rareness rareness, bool sole = false,string abilityName="", string abilityDescription="")
            {
                this._number = cnt++;
                this._name = abilityName;
                this._des = abilityDescription;
                this._poss = possibility;
                this._rare = rareness;
                this._sole = sole;
            }
            //能力结构的构造函数

            public int Possibility
            {
                get { return this._poss; }
                set { }
            }
            //概率属性
            public int Number
            {
                get { return this._number; }
                set { }
            }
            //能力序号属性
            public string AbilityName
            {
                get { return this._name; }
                set { this._name = value; }
            }
            //能力名称属性
            public string AbilityDescription
            {
                get { return this._des; }
                set { this._des = value; }
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
        *   能力抽取概率,
        *   能力稀有度
        *   ),
        *   抽取到某能力的概率 = 该能力抽取概率/所有能力抽取概率之和
        */
       new Ability(
           5,
           Rareness.史诗,
           true
           ),

       new Ability(
           50,
           Rareness.普通
           ),

       new Ability(
           50,
           Rareness.普通
           ),

       new Ability(
           50,
           Rareness.普通
           ),

       new Ability(
           50,
           Rareness.普通
           ),

       new Ability(
           50,
           Rareness.普通
           ),
       new Ability(
           30,
           Rareness.稀有,
           true
           ),
       new Ability(
           15,
           Rareness.稀有,
           true
           ),
       new Ability(
           15,
           Rareness.稀有,
           true
           ),
       new Ability(
           10,
           Rareness.史诗,
           true
           ),
       new Ability(
           1,
           Rareness.传说,
           false
           ),
    };

        public static void AbilityInitialize()
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
            for (int i = 0; i < abilities.Length; i++)
            {
                abilities[i].AbilityName = rm.GetString("abilityName" + abilities[i].Number.ToString());
                abilities[i].AbilityDescription = rm.GetString("abilityDescription" + abilities[i].Number.ToString());
            }
            //从资源文件读取文案
            if (Globle.isDebug == true)
            {
                Console.WriteLine("[info]Event资源文件读取完成");
            }
            
            int[] weightList = new int[cnt];
            foreach(Ability current in abilities)
            {
                weightList[current.Number] = current.Possibility;
            }
            abilityRandom.RandomInitiallize(weightList);
            if (Globle.isDebug == true)
            {
                Console.WriteLine("[info]Ability类初始化完成");
            }
        }
        public static int RandomPickAbility()
        {
                return abilityRandom.GetRandomIndex();
            //2021/12/31已使用Alias算法重构
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
