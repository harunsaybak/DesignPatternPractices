using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Memento.Persistence;
namespace MarvellousWorks.PracticalPattern.Memento.Tests.Persistence
{
    [TestClass]
    public class MementoFixture
    {
        [TestMethod]
        public void Main()
        {
            // �������������ķ�����ʵ�������Ƿֱ��޸�״̬
            var o1 = new Originator();
            o1.IncreaseY(); // x = 0; y = 1;
            o1.SaveCheckpoint(1);
            o1.IncreaseY(); // x = 0; y = 2
            o1.SaveCheckpoint(2);
            var o2 = new Originator();
            o2.UpdateX(3);  // x = 3; y = 0
            o2.SaveCheckpoint(2);

            // ��֤���������Ϳ��Խ����ⲿ�־û��Ʊ�����
            // ���������Ҳ�ͬʵ�����Զ���ʹ�ó־û���
            o1.Undo(1);
            Assert.AreEqual<int>(0, o1.Current.X);
            Assert.AreEqual<int>(1, o1.Current.Y);
            o2.Undo(2);
            Assert.AreEqual<int>(3, o2.Current.X);
            Assert.AreEqual<int>(0, o2.Current.Y);
        }
    }
}
