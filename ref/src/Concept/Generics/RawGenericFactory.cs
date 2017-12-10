using System;
namespace MarvellousWorks.PracticalPattern.Concept.Generics
{
    #region static impl.
    //public static class RawGenericFactory
    //{
    //    public static T Create<T>(string typeName)
    //    {
    //        return (T)Activator.CreateInstance(Type.GetType(typeName));
    //    }
    //}
    #endregion

    /// <summary>
    /// ԭʼ�ķ��͹�������
    /// </summary>
    /// <typeparam name="T">��������Ŀ�����ͣ�һ��T�ǳ������ͻ�ӿ�</typeparam>
    public class RawGenericFactory<T>
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="typeName">��������</param>
        /// <returns>����ʵ�����</returns>
        public T Create(string typeName)
        {
            if(string.IsNullOrEmpty(typeName)) throw new ArgumentNullException("typeName");
            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }
    }
}
