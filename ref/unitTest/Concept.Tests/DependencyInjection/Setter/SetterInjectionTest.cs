using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.Tests.DependencyInjection.Setter
{
    /// <summary>
    /// ͨ��Setterʵ��ע��
    /// </summary>
    class Client
    {
        public ITimeProvider TimeProvider
        {
            get;
            set;
        }
    }

    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void Test()
        {
            ITimeProvider timeProvider = (new Assembler()).Create<ITimeProvider>();
            Assert.IsNotNull(timeProvider);     // ȷ�Ͽ���������ó�������ʵ��
            Client client = new Client();
            client.TimeProvider = timeProvider; // ͨ��Setterʵ��ע��
        }
    }
}
