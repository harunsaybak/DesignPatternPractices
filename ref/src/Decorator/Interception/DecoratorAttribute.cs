using System;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.Decorator.Interception
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property |
        AttributeTargets.Interface, Inherited = true)]
    public abstract class DecoratorAttribute : Attribute
    {
        public abstract void Process(object target, MethodBase method, object[] parameters);
    }

    /// <summary>
    /// ����ִ��ǰ��ִ�к��ⲿ�����С����Ƶĳ������
    /// </summary>
    public abstract class BeforeDecoratorAttribute : DecoratorAttribute { }
    public abstract class AfterDecoratorAttribute : DecoratorAttribute { }
}
