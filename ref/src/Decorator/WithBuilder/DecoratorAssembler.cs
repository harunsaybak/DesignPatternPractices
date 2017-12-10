using System;
using System.Linq;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Decorator.WithBuilder
{
    /// <summary>
    /// װ�����͵�װ����
    /// </summary>
    public class DecoratorAssembler
    {
        /// <summary>
        /// �Ǽ�װ�β�ͬ������Ҫʹ�õ�һ��Concrete Decorator����
        /// </summary>
        static IDictionary<Type, IEnumerable<Type>> dictionary =
            new Dictionary<Type, IEnumerable<Type>>();

        /// <summary>
        /// ʵ����Ŀ��������ع��̿����������
        /// </summary>
        static DecoratorAssembler()
        {
            #region ������ص�װ������
            var types = new List<Type>()
                            {
                                typeof (BoldDecorator),
                                typeof (ColorDecorator)
                            };
            dictionary.Add(typeof(TextObject), types);
            #endregion
        }

        /// <summary>
        /// ������Ҫ����Ŀͻ�����ѡ����Ӧ��Decorator�б�
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<Type> this[Type type]
        {
            get
            {
                if (type == null) throw new ArgumentNullException("type");
                IEnumerable<Type> result;
                return dictionary.TryGetValue(type, out result) ? result : null;
            }
        }
    }
}
