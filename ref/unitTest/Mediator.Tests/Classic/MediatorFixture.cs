using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Mediator.Classic;
namespace MarvellousWorks.PracticalPattern.Mediator.Tests.Classic
{
    [TestClass]
    public class MediatorFixture
    {
        /// <summary>
        /// provider
        /// </summary>
        class A : ColleagueBase<int> 
        {
            public override int Data
            {
                get { return base.Data; }
                set
                {
                    base.Data = value;
                    Mediator.Change();
                }
            }
        }
        /// <summary>
        /// consumer
        /// </summary>
        class B : ColleagueBase<int> { }
        class C : ColleagueBase<int> { }

        [TestMethod]
        public void Test()
        {
            // ��֤Mediator��Э��������֪ͨ����
            var mA2BC = new Mediator<int>();
            var a = new A();
            var b = new B();
            var c = new C();
            a.Mediator = mA2BC;
            b.Mediator = mA2BC;
            c.Mediator = mA2BC;
            mA2BC.Introduce(a, b, c);
            a.Data = 20;
            Assert.AreEqual<int>(20, b.Data);
            Assert.AreEqual<int>(20, c.Data);

            // ����Э����ϵ
            var mA2B = new Mediator<int>();
            a.Mediator = mA2B;
            b.Mediator = mA2B;
            c.Mediator = mA2B;
            mA2B.Introduce(a, b);
            a.Data = 30;
            Assert.AreEqual<int>(30, b.Data);
            // C ��Ϊ�����µ�Э����ϵ֮�ڣ����Բ��仯
            Assert.AreEqual<int>(20, c.Data);
        }
    }
}
