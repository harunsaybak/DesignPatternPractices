using System;
using System.Collections.Generic;
using System.Web;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// ͨ�õ��Զ��������Ķ���
    /// </summary>
    public class GenericContext
    {
        /// <summary>
        /// �����ڲ������ϣ����е��������;�Ϊ Dictionary<string, object>
        /// ���Զ���һ���̶����������ơ�
        /// </summary>
        class NameBasedDictionary : Dictionary<string, object> { }


        /// <summary>
        /// ���� Windows Ӧ�õ��̼߳������ĳ�Ա����
        /// </summary>
        [ThreadStatic]
        static NameBasedDictionary threadCache;
        /// <summary>
        /// ��ʶ��ǰӦ���Ƿ�Ϊ Web Ӧ��
        /// </summary>
        public static readonly bool IsWeb = CheckWhetherIsWeb();
        /// <summary>
        /// Web Ӧ���� Context ����ļ�ֵ
        /// </summary>
        const string ContextKey = "marvellousWorks.context.web";


        /// <summary>
        /// ���� Web Ӧ�ã����HttpContext��Ӧ����Ԫ��û�г�ʼ���������һ����������
        /// ���� Windows Ӧ�ã����� threadCache Ϊ [ThreadStatic]������ù��̡�
        /// </summary>
        public GenericContext()
        {
            if (IsWeb && (HttpContext.Current.Items[ContextKey] == null))
                    HttpContext.Current.Items[ContextKey] = new NameBasedDictionary();
        }



        /// <summary>
        /// ���������ĳ�Ա���ƣ����ض�Ӧ���ݵġ�
        /// </summary>
        /// <param name="name">�����ĳ�Ա��ֵ��</param>
        /// <returns>��Ӧ����</returns>
        /// <remarks>
        /// ���� threadCache �� HttpContext �еĻ�����󶼻��ڹ�������д���
        //  ��ˣ�����û�ж� cache == null ���жϡ�
        /// </remarks>
        public object this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name)) return null;
                NameBasedDictionary cache = GetCache();
                if (cache.Count <= 0) return null;
                object result;
                if (cache.TryGetValue(name, out result))
                    return result;
                else
                    return null;
            }
            set
            {
                if (string.IsNullOrEmpty(name)) return;
                NameBasedDictionary cache = GetCache();
                object temp;
                if (cache.TryGetValue(name, out temp))
                    cache[name] = value;
                else
                    cache.Add(name, value);
            }
        }



        /// <summary>
        /// ����Ӧ�����ͻ�ȡ��Ӧ�����Ļ������
        /// </summary>
        /// <returns>�������</returns>
        static NameBasedDictionary GetCache()
        {
            NameBasedDictionary cache;
            if (IsWeb)
                cache = (NameBasedDictionary)HttpContext.Current.Items[ContextKey];
            else
                cache = threadCache;
            if (cache == null)
                cache = new NameBasedDictionary();
            if (IsWeb)
                HttpContext.Current.Items[ContextKey] = cache;
            else
                threadCache = cache;
            return cache;
        }

        /// <summary>
        /// �жϵ�ǰӦ���Ƿ�Ϊ Web Ӧ�õ� Helper ���� ���ǹٷ�������
        /// </summary>
        /// <returns></returns>
        static bool CheckWhetherIsWeb()
        {
            bool result = false;
            var domain = AppDomain.CurrentDomain;
            try
            {
                if (domain.ShadowCopyFiles)
                    result = (HttpContext.Current.GetType() != null);
            }
            catch (System.Exception){}
            return result;
        }
    }
}
