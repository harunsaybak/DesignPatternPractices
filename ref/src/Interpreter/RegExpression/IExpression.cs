using System;

namespace MarvellousWorks.PracticalPattern.Interpreter.RegExpression
{
    /// <summary>
    /// ���б��ʽ�ĳ���ӿ�
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// ��Context�����м���
        /// </summary>
        Action<Context> Evaluate { get; }
    }
}
