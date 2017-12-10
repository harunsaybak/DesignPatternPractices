using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Memento.Classic;
namespace MarvellousWorks.PracticalPattern.Memento.Tests.Classic
{
    [TestClass]
    public class MementoFixture
    {
        [TestMethod]
        public void Test()
        {
            var originator = new Originator();
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
            // ���淢���߸ճ�ʼ�����״̬
            var m1 = originator.Memento;

            // �Է����߽��в�������֤״̬���޸�
            originator.IncreaseY();
            originator.DecreaseX();
            Assert.AreEqual<int>(1, originator.Current.Y);
            Assert.AreEqual<int>(-1, originator.Current.X);

            // ȷ�ϱ���¼�Ļָ�����
            originator.Memento = m1;
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
        }
    }
}
