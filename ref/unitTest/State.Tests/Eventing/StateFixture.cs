using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.State.Eventing;
namespace MarvellousWorks.PracticalPattern.StatePattern.Test.Eventing
{
    [TestClass]
    public class StateFixture
    {
        [TestMethod]
        public void Test()
        {
            var objA = new ObjectWithName();
            IStateProvider providerA = new RestrictedStateProvider();
            ObjectWithNameAssembler.Assembly(objA, providerA);
            objA.Name = new string('1', 5);
            Assert.AreEqual<string>(objA.Name, new string('1', 5));
            objA.Name = new string('1', 20);
            // ��Ϊ�ܵ�״̬�¼�������
            Assert.AreEqual<string>(objA.Name, new string('1', 10));

            var objB = new ObjectWithName();
            IStateProvider providerB = new UnlimitedStateProvider();
            ObjectWithNameAssembler.Assembly(objB, providerB);
            objB.Name = new string('1', 5);
            Assert.AreEqual<string>(objB.Name, new string('1', 5));
            objB.Name = new string('1', 20);
            // ��Ϊ����״̬�¼���Ҫ��
            Assert.AreEqual<string>(objB.Name, new string('1', 20));

        }
    }
}
