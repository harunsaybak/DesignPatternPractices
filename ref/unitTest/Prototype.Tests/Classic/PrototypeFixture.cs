using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Prototype.Classic;
namespace MarvellousWorks.PracticalPattern.Prototype.Tests.Classic
{
    [TestClass]
    public class PrototypeFixture
    {
        IPrototype sample;

        [TestInitialize]
        public void Initialize()
        {
            sample = new ConcretePrototype();
        }

        [TestMethod]
        public void Test()
        {
            var image = sample.Clone();
            Assert.IsNull(sample.Name);                 //  ������������ʱ������һ��
            Assert.IsNull(image.Name);

            sample.Name = "A";                          //  �޸���������
            image = sample.Clone();
            Assert.AreEqual<string>("A", image.Name);   // ������������ʱ������һ��
            Assert.IsInstanceOfType(image, typeof(ConcretePrototype));
            image.Name = "B";                           // �����޸ĸ���������
            Assert.IsTrue(sample.Name != image.Name);   // ֤���������������������ĸ���
        }

        [TestMethod]
        public void TestReferenceType()
        {
            var image = sample.Clone();
            Assert.AreEqual<int>(image.Signal.GetHashCode(), sample.Signal.GetHashCode());
        }
    }
}
