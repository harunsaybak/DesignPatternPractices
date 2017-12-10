using System;

namespace MarvellousWorks.PracticalPattern.CoR.NonChain
{
    #region �����������

    /// <summary>
    /// ���ڡ��ڲ��۸񡱵Ĺ�����˻�����
    /// </summary>
    public class InternalHandler : HandlerBase
    {
        public InternalHandler() 
        {
            Type = PurchaseType.Internal;
            Option = RequestOptions.Purchase | RequestOptions.Return;
        }
        public override void Process(Request request) { request.Price *= 0.6; }
    }

    /// <summary>
    /// ���ڡ��ʹ��۸񡱹������
    /// </summary>
    public class MailPurchaseHandler : HandlerBase
    {
        public MailPurchaseHandler() 
        { 
            Type = PurchaseType.Mail;
            Option = RequestOptions.Purchase; 
        }
        public override void Process(Request request) { request.Price *= 1.3; }
    }

    /// <summary>
    /// ���ڡ��ʹ��۸��˻�����
    /// </summary>
    public class MailReturnHandler : HandlerBase
    {
        public MailReturnHandler()
        {
            Type = PurchaseType.Mail;
            Option = RequestOptions.Return;
        }
    }


    /// <summary>
    /// ���ڡ��ۿۼۡ��������
    /// </summary>
    public class DiscountPurchaseHandler : HandlerBase
    {
        public DiscountPurchaseHandler() 
        { 
            Type = PurchaseType.Discount;
            Option = RequestOptions.Purchase; 
        }
        public override void Process(Request request) { request.Price *= 0.9; }
    }

    /// <summary>
    /// ���ڡ��ۿۼۡ��˻�����
    /// </summary>
    public class DiscountReturnHandler : HandlerBase
    {
        public DiscountReturnHandler()
        {
            Type = PurchaseType.Discount;
            Option = RequestOptions.Return;
        }
        /// <summary>
        /// �ۿۼ۴�����Ʒ���˲���
        /// </summary>
        /// <param name="request"></param>
        public override void Process(Request request){throw new NotSupportedException();}
    }

    /// <summary>
    /// ���ڡ�ƽ�ۡ�������˻�����
    /// </summary>
    public class RegularHandler : HandlerBase
    {
        public RegularHandler()
        {
            Type = PurchaseType.Regular;
            Option = RequestOptions.Purchase | RequestOptions.Return;
        }
    }

    #endregion

}
