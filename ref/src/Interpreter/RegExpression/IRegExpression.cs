using System;
using System.Text.RegularExpressions;
namespace MarvellousWorks.PracticalPattern.Interpreter.RegExpression
{
    /// <summary>
    /// ����������ʽ��ʽ��ʾ�ĳ���ӿ�
    /// </summary>
    public interface IRegExpression : IExpression
    {
        /// <summary>
        /// �Ƿ�ƥ��
        /// </summary>
        Func<string, bool> IsMatch { get; }
    }

    /// <summary>
    /// ����������ʽ��ʽ��ʾ�ĳ������
    /// </summary>
    public abstract class RegExpressionBase : IRegExpression
    {
        protected Regex regex;
        protected RegExpressionBase(string expression)
        {
            regex = new Regex(expression, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            IsMatch = regex.IsMatch;
            Evaluate = EvaluateInternal;
        }

        public virtual Func<string, bool> IsMatch { get; private set; }
        public Action<Context> Evaluate{ get; private set;}


        /// <summary>
        /// �������ʽ
        /// </summary>
        /// <param name="context"></param>
        protected void EvaluateInternal(Context context)
        {
            if (context == null) throw new ArgumentNullException("context");
            switch (context.Operator)
            {
                case 'M':
                    EvaluateMatch(context);
                    break;
                case 'R':
                    EvaluateReplace(context);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// ͨ��Match��ʽ�������ʽ�����Ա����า��
        /// </summary>
        /// <param name="context"></param>
        protected virtual void EvaluateMatch(Context context)
        {
            context.Matches.Clear();
            var coll = regex.Matches(context.Content);
            if (coll.Count == 0) return;
            foreach (Match match in coll)
                context.Matches.Add(match.Value);
        }

        /// <summary>
        /// ͨ��Replace�����滻���ݣ����Ա����า��
        /// </summary>
        /// <param name="context"></param>
        protected virtual void EvaluateReplace(Context context)
        {
            context.Content = regex.Replace(context.Content, context.Replacement);
        }

    }
}
