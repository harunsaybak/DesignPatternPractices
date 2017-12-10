using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.Tests.DependencyInjection.Interfacer
{
    /// <summary>
    /// ������Ҫע��ITimeProvider������
    /// </summary>
    interface IObjectWithTimeProvider
    {
        ITimeProvider TimeProvider { get;set;}
    }

    /// <summary>
    /// ͨ���ӿڷ�ʽע��
    /// </summary>
    class Client : IObjectWithTimeProvider
    {
        /// <summary>
        /// IObjectWithTimeProvider Members
        /// </summary>
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
            IObjectWithTimeProvider objectWithTimeProvider = new Client();
            objectWithTimeProvider.TimeProvider = timeProvider; // ͨ���ӿڷ�ʽע��
        }
    }
}
