using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.Memento.Persistence
{

    /// <summary>
    /// һ������ģ��ľ���־ö���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MementoPersistenceStore<T>
        : IPersistenceStore<T>
        where T : IState
    {
        /// <summary>
        /// ģ��һ�����з��������͹���ĳ־û���
        /// </summary>
        static IDictionary<KeyValuePair<string, int>, string>
            store = new Dictionary<KeyValuePair<string, int>, string>();

        /// <summary>
        /// �ѱ�����Ϣ������ģ��ĳ־ò������
        /// </summary>
        /// <param name="originatorId"></param>
        /// <param name="version"></param>
        /// <param name="target"></param>
        public void Store(string originatorId, int version, T target)
        {
            if (target == null) throw new ArgumentNullException("target");
            var key = new KeyValuePair<string, int>(originatorId, version);
            string value = SerializationHelper.SerializeObjectToString(target);
            if (store.ContainsKey(key))
                store[key] = value;     // ���¼��а汾��������
            else
                store.Add(key, value);  // ����һ���°汾�ı�������
        }

        /// <summary>
        /// �ӳ־ö����ñ�����Ϣ
        /// </summary>
        /// <param name="originatorId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public T Find(string originatorId, int version)
        {
            string value;
            if (!store.TryGetValue(new KeyValuePair<string, int>(originatorId, version), out value))
                throw new NullReferenceException();
            return SerializationHelper.DeserializeStringToObject<T>(value);
        }
    }

}
