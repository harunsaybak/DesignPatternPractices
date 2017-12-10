namespace MarvellousWorks.PracticalPattern.CoR.Classic
{
    /// <summary>
    /// ����Ĳ�������
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// ����ͻ���������
        /// </summary>
        /// <param name="request"></param>
        void HandleRequest(Request request);

        /// <summary>
        /// ��̽��
        /// </summary>
        IHandler Successor { get; set; }

        /// <summary>
        /// ���ڵ�ǰHandler����Ĺ�������
        /// </summary>
        PurchaseType Type { get; }
    }
}
