using System;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.Builder.Attributed
{
    /// <summary>
    /// ָ��ÿ����������BuildPart����Ŀ�귽����ִ�����������
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
    public sealed class BuildStepAttribute : Attribute
    {
        int sequence;
        int times;

        public BuildStepAttribute(int sequence, int times)
        {
            if((sequence <= 0) || (times <= 0 ))
                throw new ArgumentOutOfRangeException();
            this.sequence = sequence;
            this.times = times;
        }
        public BuildStepAttribute(int sequence) : this(sequence, 1) { }

        /// <summary>
        /// ִ�еĴ���
        /// </summary>
        public int Sequence { get { return this.sequence; } }

        /// <summary>
        /// ִ�еĴ���
        /// </summary>
        public int Times { get { return this.times; } }
    }
}
