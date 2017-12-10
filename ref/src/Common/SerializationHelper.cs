using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Remoting.Messaging;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// serialization formatter type
    /// </summary>
    public enum FormatterType
    {
        /// <summary>
        /// SOAP��Ϣ��ʽ����
        /// </summary>
        Soap,

        /// <summary>
        /// ��������Ϣ��ʽ����
        /// </summary>
        Binary
    }

    /// <summary>
    /// Utility for serialization
    /// </summary>
    public static class SerializationHelper
    {
        const FormatterType DefaultFormatterType = FormatterType.Binary;

        /// <summary>
        /// ���մ��л��ı���Ҫ�����ɶ�Ӧ�ı�������
        /// </summary>
        /// <param name="formatterType"></param>
        /// <returns></returns>
        static IRemotingFormatter GetFormatter(FormatterType formatterType)
        {
            switch (formatterType)
            {
                case FormatterType.Binary: return new BinaryFormatter();
                case FormatterType.Soap: return new SoapFormatter();
            }
            throw new NotSupportedException();
        }

        /// <summary>
        /// �Ѷ������л�ת��Ϊ�ַ���
        /// </summary>
        /// <param name="graph">�ɴ��л�����ʵ��</param>
        /// <param name="formatterType">��Ϣ��ʽ�������ͣ�Soap��Binary�ͣ�</param>
        /// <returns>���л�ת�����</returns>
        /// <remarks>
        ///     ����BinaryFormatter��SoapFormatter��Serialize����ʵ����Ҫת�����̡�
        /// </remarks>    
        public static string SerializeObjectToString(object graph, FormatterType formatterType = DefaultFormatterType)
        {
            using (var memoryStream = new MemoryStream())
            {
                var formatter = GetFormatter(formatterType);
                formatter.Serialize(memoryStream, graph);
                var arrGraph = memoryStream.ToArray();
                return Convert.ToBase64String(arrGraph);
            }
        }

        /// <summary>
        /// �������л�Ϊ�ַ������͵Ķ������л�Ϊָ��������
        /// </summary>
        /// <param name="serializedGraph">�����л�Ϊ�ַ������͵Ķ���</param>
        /// <param name="formatterType">��Ϣ��ʽ�������ͣ�Soap��Binary�ͣ�</param>
        /// <typeparam name="T">����ת���������</typeparam>
        /// <returns>���л�ת�����</returns>
        /// <remarks>
        ///     ����BinaryFormatter��SoapFormatter��Deserialize����ʵ����Ҫת�����̡�
        /// </remarks>
        public static T DeserializeStringToObject<T>(string graph, FormatterType formatterType = DefaultFormatterType)
        {
            var arrGraph = Convert.FromBase64String(graph);
            using (var memoryStream = new MemoryStream(arrGraph))
            {
                var formatter = GetFormatter(formatterType);
                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }
}
