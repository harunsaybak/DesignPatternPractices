using System.Xml;
using System.Xml.Xsl;
using System.Collections.Generic;
using System.IO;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// ���һ��XML�����Ĺ�������
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// �������б����ز������ XSLT ʵ������
        /// </summary>
        static Dictionary<string, XslCompiledTransform> transforms =
            new Dictionary<string, XslCompiledTransform>();

        /// <summary>
        /// ���� XSLT �Ķ������ XML �ļ���ת��
        /// </summary>
        /// <param name="xsltFile"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static XmlDocument Transform(string xsltFile, XmlDocument source)
        {
            var tranform = GetTransform(xsltFile);
            using (var stream = new MemoryStream())
            {
                tranform.Transform(source, null, stream);
                stream.Position = 0;
                var target = new XmlDocument();
                target.Load(stream);
                return target;
            }
        }

        static XslCompiledTransform GetTransform(string xsltFile)
        {
            // ���ݻ��������ȡ XSLT ʵ��
            XslCompiledTransform transform;
            if (!transforms.TryGetValue(xsltFile, out transform))
            {
                transform = new XslCompiledTransform();
                transform.Load(xsltFile);
                transforms.Add(xsltFile, transform);
            }
            return transform;
        }
    }
}
