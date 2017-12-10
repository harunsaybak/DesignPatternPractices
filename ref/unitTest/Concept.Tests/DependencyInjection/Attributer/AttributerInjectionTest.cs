using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
namespace MarvellousWorks.PracticalPattern.Concept.Tests.DependencyInjection.Attributer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    sealed class DecoratorAttribute : Attribute
    {
        /// <summary>
        /// ʵ�ֿͻ�����ʵ����Ҫ�ĳ������͵�ʵ������ʵ��������ע�뵽�ͻ����͵�����
        /// </summary>
        public readonly object Injector;
        readonly Type type;

        public DecoratorAttribute(Type type) 
        {
            if (type == null) throw new ArgumentNullException("type");
            this.type = type;
            Injector = (new Assembler()).Create(this.type);
        }

        /// <summary>
        /// �ͻ�������Ҫ�ĳ����������
        /// </summary>
        public Type Type { get { return this.type; } }
    }

    /// <summary>
    /// �û������ͻ����ͺͿͻ������ȡ��Attribute��������Ҫ�ĳ�������ʵ��
    /// </summary>
    static class AttributeHelper
    {
        public static T Injector<T>(object target)
            where T : class
        {
            if (target == null) throw new ArgumentNullException("target");
            return (T)(((DecoratorAttribute[])
                target.GetType().GetCustomAttributes(typeof(DecoratorAttribute), false))
                .Where(x => x.Type == typeof(T))
                .FirstOrDefault()
                .Injector);
        }
    }

    [Decorator(typeof(ITimeProvider))]
    class Client
    {
        public int GetYear()
        {
            // ��������ʽע�벻ͬ���ǣ�����ʹ�õ�ITimeProvider�����Լ���Attribute
            var provider = AttributeHelper.Injector<ITimeProvider>(this);
            return provider.CurrentDate.Year;
        }
    }

    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(new Client().GetYear() > 0);
        }
    }
}
