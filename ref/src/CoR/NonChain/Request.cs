using System;

namespace MarvellousWorks.PracticalPattern.CoR.NonChain
{

    /// <summary>
    /// �����ߵ�Request����
    /// </summary>
    [Flags]
    public enum RequestOptions
    {
        /// <summary>
        /// ����
        /// </summary>
        Purchase = 0x1,

        /// <summary>
        /// �˻�
        /// </summary>
        Return = 0x2,

        /// <summary>
        /// ����
        /// </summary>
        Damaged = 0x4
    }

    /// <summary>
    /// ������
    /// </summary>
    public class Request
    {
        public double Price { get; set; }
        public PurchaseType Type { get; set; }
        public RequestOptions Option { get; set; }
    }
}
