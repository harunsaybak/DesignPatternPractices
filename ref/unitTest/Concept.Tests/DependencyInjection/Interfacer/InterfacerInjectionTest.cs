using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.Tests.DependencyInjection.Interfacer
{
    /// <summary>
    /// 定义需要注入ITimeProvider的类型
    /// </summary>
    interface IObjectWithTimeProvider
    {
        ITimeProvider TimeProvider { get;set;}
    }

    /// <summary>
    /// 通过接口方式注入
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
            Assert.IsNotNull(timeProvider);     // 确认可以正常获得抽象类型实例
            IObjectWithTimeProvider objectWithTimeProvider = new Client();
            objectWithTimeProvider.TimeProvider = timeProvider; // 通过接口方式注入
        }
    }
}
