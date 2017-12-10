using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
namespace MarvellousWorks.PracticalPattern.Decorator.Tests.Interception
{
    [TestClass]
    public class MsilDecoratorInjectionFixture
    {
        /// <summary>
        /// ��װ�ε�Ŀ�����ͽӿ�
        /// </summary>
        public interface IBizObject
        {
            /// <summary>
            /// ��װ�ε�����ֻҪ�����ڽӿڼ��ɣ��������������ÿ��ʵ������
            /// </summary>
            /// <returns></returns>
            [Log]
            [Security]
            int GetValue();

            int GetYear();
        }

        /// <summary>
        /// ��װ�ε�Ŀ������
        /// </summary>
        public class BizObject : IBizObject
        {
            public static readonly int Value = new Random().Next();

            /// <summary>
            /// �ӿ����Ѿ�����עΪ��Ҫװ�εķ���
            /// </summary>
            /// <returns></returns>
            public int GetValue(){return Value;}

            /// <summary>
            /// �ӿ�������Ϊ����װ�εķ���
            /// </summary>
            /// <returns></returns>
            public int GetYear()
            {
                return DateTime.Now.Year;    
            }
        }

        #region �Զ����װ������

        public class LogAttribute : HandlerAttribute, ICallHandler
        {
            public override ICallHandler CreateHandler(IUnityContainer container){return this;}
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                Trace.WriteLine("log...");
                return getNext()(input, getNext);
            }
        }

        public class SecurityAttribute : HandlerAttribute, ICallHandler
        {
            public override ICallHandler CreateHandler(IUnityContainer container) { return this; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                Trace.WriteLine("machine name");
                Trace.WriteLine("domain name");
                return getNext()(input, getNext);
            }
        }

        #endregion

        [TestMethod]
        public void TestInjectionType()
        {
            var container =
                new UnityContainer().AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();

            //  Unity��̬���벢����װ������
            container.RegisterType<IBizObject, BizObject>().
                Configure<Microsoft.Practices.Unity.InterceptionExtension.Interception>().
                SetInterceptorFor<IBizObject>(new InterfaceInterceptor());

            var bizObject = container.Resolve<IBizObject>();

            //  ����װ�κ�ķ���
            Trace.WriteLine("\nInvoke GetValue()\n-----------------");
            Assert.AreEqual<int>(BizObject.Value, bizObject.GetValue());

            //  ����δװ�εķ���
            Trace.WriteLine("\nInvoke GetValue()\n-----------------");
            Assert.AreEqual<int>(DateTime.Now.Year, bizObject.GetYear());
        }
    }
}
