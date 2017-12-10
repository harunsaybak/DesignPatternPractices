namespace MarvellousWorks.PracticalPattern.Interpreter.DictionaryExpression
{
    /// <summary>
    /// �������ֵ���Ϣ��Context����
    /// </summary>
    public class Context
    {
        public object Key{ get; set;}
        public object Value { get; set; }
        /// <summary>
        /// 'T'(to) ����Value���Key
        /// 'F'(from) ����Key���Value
        /// </summary>
        public char Operator { get; set; }
    }
}
