namespace MarvellousWorks.PracticalPattern.Interpreter.Classic
{
    /// <summary>
    /// ��ʾ���в�����
    /// </summary>
    public class Operator : IExpression
    {
        public char Op { get; set; }
        public virtual void Evaluate(Context context) { context.Operator = Op; }
    }
}
