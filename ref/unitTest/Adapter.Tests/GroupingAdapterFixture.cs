using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Adapter.Grouping;
namespace MarvellousWorks.PracticalPattern.Adapter.Test
{
    [TestClass]
    public class TestAdapter
    {
        [TestMethod]
        public void Test()
        {
            var factory = new FactoryMethod.Factory()
                .RegisterType<IDatabaseAdapter, OracleAdapter>("ora")
                .RegisterType<IDatabaseAdapter, SqlServerAdapter>("sql");

            var oracleAdapter = factory.Create<IDatabaseAdapter>("ora");
            var sqlAdapter = factory.Create<IDatabaseAdapter>("sql");

            // ȷ��֮ǰ��ȫ��ͬ��adaptee��ͳһ����Ϊtarget������Ľӿ�����
            Assert.AreEqual<string>("oracle", oracleAdapter.ProviderName);
            Assert.AreEqual<string>("SQL Server", sqlAdapter.ProviderName);
        }
    }
}
