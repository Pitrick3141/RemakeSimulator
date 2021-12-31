using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remake_Simulator_Csharp
{
    class WeightedRandom
    {
        public (float, int)[] preparedWeightList;//使用权重填充空桶，float为小权重的占比，int为大权重的索引
        Random random = new Random();
        /*
         * 2021/12/31创建 带权重随机类
         * 参考算法 Alias
         * Ref: https://www.jianshu.com/p/457a75c6fae3
         */
        public void RandomInitiallize(int[] weightList)
        {
            var weightSum = weightList.Sum();
            int length = weightList.Length;
            var averageWeight = 1f * weightSum / length;
            List<(float, int)> smallAverage = new List<(float, int)>();//存储小于平均值的权重
            List<(float, int)> bigAverage = new List<(float, int)>();//存储大于平均值的权重
            for (int i = 0; i < length; i++)
            {
                (weightList[i] > averageWeight ? bigAverage : smallAverage).Add((weightList[i], i));
                //将weightList中数据分为大权重和小权重
            }
            preparedWeightList = new (float, int)[weightList.Length];
            for (int i = 0; i < length; i++)
            {
                if (smallAverage.Count > 0)
                {
                    if (bigAverage.Count > 0)
                    {
                        //大小权重都存在
                        preparedWeightList[smallAverage[0].Item2] = (smallAverage[0].Item1 / averageWeight, bigAverage[0].Item2);
                        //将小权重存入桶内，不足部分由大权重补齐，使得每个桶内权重都为平均权重
                        bigAverage[0] = (bigAverage[0].Item1 - averageWeight + smallAverage[0].Item1, bigAverage[0].Item2);
                        //更新大权重的剩余权重
                        if (averageWeight - bigAverage[0].Item1 > 0.0000001f)
                        {
                            smallAverage.Add(bigAverage[0]);
                            bigAverage.RemoveAt(0);
                            //如果大权重减去桶内部分后小于平均权重则将其变为小权重
                        }
                    }
                    else
                    {
                        //只剩下小权重
                        preparedWeightList[smallAverage[0].Item2] = (smallAverage[0].Item1 / averageWeight, smallAverage[0].Item2);
                    }
                    smallAverage.RemoveAt(0);
                }
                else
                {
                    //只剩下大权重
                    preparedWeightList[bigAverage[0].Item2] = (bigAverage[0].Item1 / averageWeight, bigAverage[0].Item2);
                    bigAverage.RemoveAt(0);
                }
            }
        }
        public int GetRandomIndex()
        {
            var randomNumber = random.NextDouble() * preparedWeightList.Length;//在桶中选取一个
            int intRandom = (int)Math.Floor(randomNumber);//向下取整得桶的序号
            var current = preparedWeightList[intRandom];
            if(current.Item1 > randomNumber - intRandom)//如果桶中小权重占的比例大于随机数小数部分则返回小权重序号，否则返回大权重
            {
                return intRandom;
            }
            else
            {
                return current.Item2;
            }
        }
    }
}
