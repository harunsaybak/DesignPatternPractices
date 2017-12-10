using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Memento.StackMode;
namespace MarvellousWorks.PracticalPattern.Memento.Tests.StackMode
{
    [TestClass]
    public class MementoFixture
    {
        [TestMethod]
        public void Test()
        {
            var originator = new Originator();
            // ���淢���߸ճ�ʼ�����״̬
            originator.SaveCheckpoint();    // x = 0, y = 0 ��ջ

            // �Է����߽����޸� 1
            originator.IncreaseY();
            originator.DecreaseX();
            originator.SaveCheckpoint();    // x = -1, y = 1 ��ջ

            // �Է����߽����޸� 2
            originator.UpdateX(2);
            originator.SaveCheckpoint();    // x = 2, y = 1 ��ջ

            // �Է����߽����޸� 3
            originator.UpdateX(3);
            originator.IncreaseY();         // x = 3, y = 2
            

            // ȷ��Undoǰ��״̬
            Assert.AreEqual<int>(3, originator.Current.X);
            Assert.AreEqual<int>(2, originator.Current.Y);
            

            // ȷ�ϱ���¼��ջʽ�ָ����á����ָ����޸�
            originator.Undo();  //  ��ջ
            Assert.AreEqual<int>(2, originator.Current.X);
            Assert.AreEqual<int>(1, originator.Current.Y);

            // ȷ�ϱ���¼��ջʽ�ָ����á����ָ����޸�1
            originator.Undo();  //  ��ջ
            Assert.AreEqual<int>(-1, originator.Current.X);
            Assert.AreEqual<int>(1, originator.Current.Y);
        }
    }
}
