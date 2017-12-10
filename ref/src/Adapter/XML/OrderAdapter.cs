using System.Xml;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.Adapter.XML
{
    
    /// <summary>
    /// ����XSLT��ͨ������������
    /// </summary>
    public abstract class XsltAdapterBase
    {
        protected string xslt;
        public virtual XmlDocument Transform(XmlDocument source)
        {
            return XmlHelper.Transform(xslt, source);
        }
    }

    /// <summary>
    /// һ���Ĳ���XSLT��ʽ�����ʾ������������
    /// </summary>
    public class OrderAdapter : XsltAdapterBase
    {
        public OrderAdapter() { base.xslt = "Order.xslt"; }
    }
}
