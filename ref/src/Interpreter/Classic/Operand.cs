using System;

namespace MarvellousWorks.PracticalPattern.Interpreter.Classic
{
    /// <summary>
    /// ��ʾ���в�����
    /// </summary>
    public class Operand : IExpression
    {
        public int Number { get; set; }

        /// <summary>
        /// ���ݲ�����ִ�м���
        /// </summary>
        /// <param name="c"></param>
        public virtual void Evaluate(Context c)
        {
            switch (c.Operator)
            {
                case '\0': c.Value = Number; break;
                case '+': c.Value += Number; break;
                case '-': c.Value -= Number; break;
            }
        }
    }
}
