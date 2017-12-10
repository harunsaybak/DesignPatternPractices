using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.FactoryMethod;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Tests.Classic
{
    public class Assembler
    {
        /// <summary>
        /// ���ý�����
        /// </summary>
        const string SectionName = "factoryMethod.customFactories";

        /// <summary>
        /// ���桰��������/ʵ�����͡���Ӧ��ϵ���ֵ�
        /// </summary>
        static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            // ͨ�������ļ�������ء������Ʒ���͡�/ ��ʵ���Ʒ���͡�ӳ���ϵ
            NameValueCollection collection =
                (NameValueCollection)ConfigurationManager.GetSection(SectionName);
            for (int i = 0; i < collection.Count; i++)
            {
                string target = collection.GetKey(i);
                string source = collection[i];
                dictionary.Add(Type.GetType(target), Type.GetType(source));
            }
        }

        /// <summary>
        /// ���ݿͻ�������Ҫ�ĳ�������ѡ����Ӧ��ʵ�����ͣ�����������ʵ��
        /// </summary>
        /// <typeparam name="T">�������ͣ�������/�ӿ�/����ĳ�ֻ��ࣩ</typeparam>
        /// <returns>ʵ������ʵ��</returns>
        public object Create(Type type)     // ��Ҫ���ڷǷ��ͷ�ʽ����
        {
            if ((type == null) || !dictionary.ContainsKey(type)) throw new NullReferenceException();
            return Activator.CreateInstance(dictionary[type]);
        }

        /// <typeparam name="T">�������ͣ�������/�ӿ�/����ĳ�ֻ��ࣩ</typeparam>
        public T Create<T>()    // ��Ҫ���ڷ��ͷ�ʽ����
        {
            return (T)Create(typeof(T));
        }

        public void Assembly(Client client)
        {
            client.Factory = Create<IFactory>();
        }
    }

    /// <summary>
    /// ����Ĺ���������������
    /// </summary>
    public interface IFactory
    {
        IProduct Create();  //  ÿ�����������еĹ��ܡ��������Ʒ
    }

    /// <summary>
    /// ���幤������
    /// </summary>
    public class FactoryA : IFactory
    {
        public IProduct Create()
        {
            return new ProductA();
        }
    }

    /// <summary>
    /// ���幤������
    /// </summary>
    public class FactoryB : IFactory
    {
        public IProduct Create()
        {
            return new ProductB();
        }
    }


    [TestClass]
    public class Client
    {
        public IFactory Factory { get; set; }   // setter injection
        public IProduct Product { get { return Factory.Create(); } }

        [TestMethod]
        public void FactoryWithAssembler()
        {
            var client = new Client();
            new Assembler().Assembly(client);
            Assert.IsInstanceOfType(client.Factory, typeof(FactoryA));
            Assert.IsInstanceOfType(client.Product, typeof(ProductA));
        }
    }

}
