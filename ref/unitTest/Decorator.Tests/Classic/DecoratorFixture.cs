using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Decorator.Classic;
namespace MarvellousWorks.PracticalPattern.Decorator.Tests.Classic
{
    [TestClass]
    public class DecoratorFixture
    {
        [TestMethod]
        public void Test()
        {
            // �������󣬲������������װ��
            IText text = new TextObject();
            text = new BoldDecorator(text);
            text = new ColorDecorator(text);
            Assert.AreEqual<string>("<color><b>hello</b></color>", text.Content);
            text = null;

            // ��������ֻ�������1��װ��
            text = new TextObject();
            text = new ColorDecorator(text);
            Assert.AreEqual<string>("<color>hello</color>", text.Content);

            // ͨ��װ�Σ�����ĳЩ����
            text = new BlockAllDecorator(text);
            Assert.IsTrue(string.IsNullOrEmpty(text.Content));
        }
    }
}
