namespace MarvellousWorks.PracticalPattern.Interpreter.RegExpression
{
    /// <summary>
    /// �����ʼ�
    /// </summary>
    public class EmailRegExpression : RegExpressionBase
    {
        public EmailRegExpression()
            : base(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") { }
    }

    /// <summary>
    /// ����
    /// </summary>
    public class ChineseRegExpression : RegExpressionBase
    {
        public ChineseRegExpression()
            :base(@"^[\u4e00-\u9fa5]{0,}$") { }
    }

    /// <summary>
    /// ��ͨ���ַ���
    /// </summary>
    public class StringRegExpression : RegExpressionBase
    {
        public StringRegExpression(string expression) : base(expression) { }
    }
}
