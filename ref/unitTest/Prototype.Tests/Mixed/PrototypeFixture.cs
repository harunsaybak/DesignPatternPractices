using System;
using System.Text;
using MarvellousWorks.PracticalPattern.Common;
using MarvellousWorks.PracticalPattern.Prototype.Mixed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
namespace MarvellousWorks.PracticalPattern.Prototype.Tests.Mixed
{
    //// <summary>
    /// ���԰�ȫ������
    /// </summary>
    [TestClass]
    public class SecurityContextFixture
    {
        //// <summary>
        /// Prepare
        /// </summary>
        /// <returns></returns>
        private SecurityContext CreateContext()
        {
            var context = new SecurityContext();
            context["hello"] = "world";
            context["1"] = "first";
            return context;
        }

        //// <summary>
        /// ����SecurityContext
        /// </summary>
        [TestMethod]
        public void TestContextAccess()
        {
            SecurityContext context = CreateContext();

            Assert.AreEqual<string>("world", context["hello"]);
            Assert.AreEqual<string>("first", context["1"]);
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));

            context["1"] = "First";
            Assert.AreEqual<string>("First", context["1"]);
        }

        //// <summary>
        /// ��Ҫȷ���Ƿ���Ա�Binary���л�������������Զ�̵���
        /// </summary>
        [TestMethod]
        public void TestBinarySerializeContext()
        {
            // �������л�
            var temp = CreateContext();
            var tempGraph = SerializationHelper.SerializeObjectToString(temp, FormatterType.Binary);
            var context = SerializationHelper.DeserializeStringToObject<SecurityContext>(tempGraph, FormatterType.Binary);

            Assert.AreEqual<string>("world", context["hello"]);
            Assert.AreEqual<string>("first", context["1"]);
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));

            string graph = SerializationHelper.SerializeObjectToString(context, FormatterType.Binary);
            Assert.AreEqual<string>(tempGraph, graph);

            // �������л��Ľṹ��������ȫ��ͬ��ʵ��
            temp["2"] = "Second";
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));
            context["2"] = "��";
            Assert.AreNotEqual<string>(context["2"], temp["2"]);
        }

        //// <summary>
        /// ��Ҫȷ���Ƿ���Ա�Soap���л�������������Զ�̵���
        /// </summary>
        [TestMethod]
        public void TestSoapSerializeContext()
        {
            // �������л�
            var temp = CreateContext();
            var tempGraph = SerializationHelper.SerializeObjectToString(temp, FormatterType.Soap);
            var context = SerializationHelper.DeserializeStringToObject<SecurityContext>(tempGraph, FormatterType.Soap);

            Assert.AreEqual<string>("world", context["hello"]);
            Assert.AreEqual<string>("first", context["1"]);
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));

            string graph = SerializationHelper.SerializeObjectToString(context, FormatterType.Soap);
            Assert.AreEqual<string>(tempGraph, graph);
            byte[] buffer = Convert.FromBase64String(graph);
            string soap = Encoding.Default.GetString(buffer);


            // �������л��Ľṹ��������ȫ��ͬ��ʵ��
            temp["2"] = "Second";
            Assert.IsTrue(string.IsNullOrEmpty(context["2"]));
            context["2"] = "��";
            Assert.AreNotEqual<string>(context["2"], temp["2"]);
        }
    }
}
