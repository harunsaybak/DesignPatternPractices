namespace MarvellousWorks.PracticalPattern.CoR.Classic
{
    #region �����������

    /// <summary>
    /// ֻ���ڡ��ڲ��۸񡱵Ĳ���
    /// </summary>
    public class InternalHandler : HandlerBase
    {
        public InternalHandler() { Type = PurchaseType.Internal; }
        public override void Process(Request request) { request.Price *= 0.6; }
    }

    /// <summary>
    /// ֻ���ڡ��ʹ��۸񡱵Ĳ���
    /// </summary>
    public class MailHandler : HandlerBase
    {
        public MailHandler() { Type = PurchaseType.Mail; }
        public override void Process(Request request) { request.Price *= 1.3; }
    }

    /// <summary>
    /// ֻ���ڡ��ۿۼۡ��Ĳ���
    /// </summary>
    public class DiscountHandler : HandlerBase
    {
        public DiscountHandler() { Type = PurchaseType.Discount; }
        public override void Process(Request request) { request.Price *= 0.9; }
    }

    /// <summary>
    /// ֻ���ڡ�ƽ�ۡ��Ĳ���
    /// </summary>
    public class RegularHandler : HandlerBase
    {
        public RegularHandler() { Type = PurchaseType.Regular; }
    }

    #endregion

}
