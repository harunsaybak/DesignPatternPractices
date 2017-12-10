using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Observer.ObserverCollection.Simple
{
    /// <summary>
    /// ���ڱ��漯�ϲ����в�����Ŀ��Ϣ��ʱ�����
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DictionaryEventArgs<TKey, TValue> : EventArgs
    {
        public TKey Key{get;set;}
        public TValue Value { get; set; }
    }

    /// <summary>
    /// ���в����¼���IDictionary<TKey, TValue>�ӿ�
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IObserverableDictionary<TKey, TValue> :
        IDictionary<TKey, TValue>
    {
        EventHandler<DictionaryEventArgs<TKey, TValue>> NewItemAdded { get; set;}
    }

    /// <summary>
    /// һ�ֱȽϼ򵥵�ʵ�ַ�ʽ
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class ObserverableDictionary<TKey, TValue> : 
        Dictionary<TKey, TValue>, IObserverableDictionary<TKey, TValue>
    {
        public EventHandler<DictionaryEventArgs<TKey, TValue>> NewItemAdded{get; set;}

        /// <summary>
        /// Ϊ���в��������¼�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            if (NewItemAdded != null)
                NewItemAdded(this, new DictionaryEventArgs<TKey, TValue> {Key = key, Value = value});
        }
    }
}
