using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Strategy.Classic;
namespace MarvellousWorks.PracticalPattern.Strategy.Tests.Classic
{
    [TestClass]
    public class StrategyFixture
    {
        /// <summary>
        /// �����������
        /// </summary>
        class GetMinSortStrategy : IStrategy
        {
            public int PickUp(int[] data)
            {
                if(data == null) throw new ArgumentNullException("data");
                return data.Min();
            }
        }
        class FirstDataStrategy : IStrategy
        {
            public int PickUp(int[] data)
            {
                if (data == null) throw new ArgumentNullException("data");
                return data.First();
            }
        }
        class GetMaxStrategy : IStrategy
        {
            public int PickUp(int[] data)
            {
                if (data == null) throw new ArgumentNullException("data");
                return data.Max();
            }
        }

        /// <summary>
        /// ��Ҫ���ÿ��滻����ִ�еĶ���
        /// </summary>
        public class Context : IContext
        {
            public IStrategy Strategy { get; set; }

            /// <summary>
            /// ִ�ж��������ڲ��Զ���Ĳ�������
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public int GetData(int[] data)
            {
                if (Strategy == null) throw new NullReferenceException("Strategy");
                if (data == null) throw new ArgumentNullException("data");
                return Strategy.PickUp(data);
            }
    }

        int[] data = new int[] { 5, 3, 7, 9, 1 };

        [TestMethod]
        public void Test()
        {
            var context = new Context() {Strategy = new GetMaxStrategy()};
            Assert.AreEqual<int>(context.GetData(data), 9);

            // �л��㷨
            context.Strategy = new GetMinSortStrategy();
            Assert.AreEqual<int>(context.GetData(data), 1);

            // �л��㷨
            context.Strategy = new FirstDataStrategy();
            Assert.AreEqual<int>(context.GetData(data), 5);
        }
    }

    
}
