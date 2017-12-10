namespace MarvellousWorks.PracticalPattern.CoR.NonChain
{
    /// <summary>
    /// ����Ĳ�������
    /// </summary>
    /// <remarks>��Ϊͨ��LINQ��ʽ��֯�������Բ��趨���̽ڵ�(Successor)</remarks>
    public interface IHandler
    {
        /// <summary>
        /// ����ͻ���������
        /// </summary>
        /// <param name="request"></param>
        void HandleRequest(Request request);

        /// <summary>
        /// ���ڵ�ǰHandler����Ĺ�������
        /// </summary>
        PurchaseType Type { get; }

        /// <summary>
        /// ��ǰHandler���õ�ҵ������
        /// </summary>
        RequestOptions Option { get; }
    }
}
