using System;

namespace MarvellousWorks.PracticalPattern.Interpreter.DictionaryExpression
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
