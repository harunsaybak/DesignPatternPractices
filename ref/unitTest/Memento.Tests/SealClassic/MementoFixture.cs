using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Memento.SealClassic;
namespace MarvellousWorks.PracticalPattern.Memento.Tests.SealClassic
{
    [TestClass]
    public class MementoFixture
    {
        [TestMethod]
        public void Test()
        {
            var originator = new Originator();
            // ���淢���߸ճ�ʼ�����״̬
            originator.SaveCheckpoint();

            // �Է����߽��в�������֤״̬���޸�
            originator.IncreaseY();
            originator.DecreaseX();
            Assert.AreEqual<int>(-1, originator.Current.X);
            Assert.AreEqual<int>(1, originator.Current.Y);

            // ȷ�ϱ���¼�Ļָ�����
            originator.Undo();
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
        }
    }
}
