using System;

namespace MarvellousWorks.PracticalPattern.Interpreter.DictionaryExpression
{
    /// <summary>
    /// �����ֵ���Ϣ�洢���ʶ���
    /// </summary>
    public interface IDictionaryStore
    {
        /// <summary>
        /// ���ڻ������á����ݿ����Ϣ��Store�������ͨ���÷������¼�����Ӧ�Ļ�����Ϣ
        /// </summary>
        void Refersh();
        /// <summary>
        /// ����Context�����Key/Value�Լ����ʷ�����ȡ��Ϣ
        /// </summary>
        /// <param name="context"></param>
        void Find(Context context);
    }

    /// <summary>
    /// �����ֵ���Ϣ�ı��ʽ����ӿ�
    /// </summary>
    public interface IDictionaryExpression : IExpression
    {
        IDictionaryStore Store { get; set; }
    }

    public class SimpleDictionaryExpression : IDictionaryExpression
    {
        public virtual IDictionaryStore Store{ get; set; }
        public Action<Context> Evaluate { get { return Store.Find; } }
    }
}
