using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Mediator.Delegating;
namespace MarvellousWorks.PracticalPattern.Mediator.Tests.Delegating
{
    [TestClass]
    public class MediatorFixture
    {
        public class A : ColleagueBase<int>
        {
            public event EventHandler<DataEventArgs<int>> Changed;
            public override int Data
            {
                get{return base.Data;}
                set
                {
                    base.Data = value;
                    /// ����Ϣ�׸���Ϊ�н��.NET�¼�����
                    Changed(this, new DataEventArgs<int>(value));
                }
            }
        }
        public class B : ColleagueBase<int> { }
        public class C : ColleagueBase<int> { }

        [TestMethod]
        public void Test()
        {
            // ��֤.NET�¼���Э��������֪ͨ����
            // ����.NET�¼�������Ϊ������Mediator�������
            var a = new A();
            var b = new B();
            var c = new C();
            a.Changed += b.OnChanged;
            a.Changed += c.OnChanged;
            a.Data = 20;
            Assert.AreEqual<int>(20, b.Data);
            Assert.AreEqual<int>(20, c.Data);

            // ����Э����ϵ
            a.Changed -= c.OnChanged;
            a.Data = 30;
            Assert.AreEqual<int>(30, b.Data);
            // C ��Ϊ�����µ�Э����ϵ֮�ڣ����Բ��仯
            Assert.AreEqual<int>(20, c.Data);

        }
    }
}
