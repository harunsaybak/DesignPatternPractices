using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Decorator.WithBuilder;
namespace MarvellousWorks.PracticalPattern.Decorator.Tests.WithBuilder
{
    [TestClass]
    public class DecoratorFixture
    {
        [TestMethod]
        public void Test()
        {
            // �޸ĺ��IText����������һ��Builder����
            IText text = new TextObject();
            text = (new DecoratorBuilder()).BuildUp(text);
            Assert.AreEqual<string>("<color><b>hello</b></color>", text.Content);
        }
    }
}
