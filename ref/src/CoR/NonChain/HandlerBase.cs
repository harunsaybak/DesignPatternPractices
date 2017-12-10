using System;
using System.Diagnostics;

namespace MarvellousWorks.PracticalPattern.CoR.NonChain
{
    /// <summary>
    /// �����ĳ�������
    /// </summary>
    public abstract class HandlerBase : IHandler
    {
        public IHandler Successor { get; set; }
        public PurchaseType Type { get; protected set; }
        public RequestOptions Option { get; protected set; }

        /// <summary>
        /// Handler��Ҫ���������
        /// </summary>
        /// <param name="request"></param>
        public virtual void Process(Request request) { }

        /// <summary>
        /// ������ʽ��ʽ���ΰѵ��ü�����ȥ
        /// </summary>
        /// <param name="request"></param>
        public virtual void HandleRequest(Request request)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            Trace.WriteLine("");
            Trace.Write(GetType().Name);
            if (request.Type == Type)
            {
                Process(request);
                Trace.Write(" has been processed");
            }
        }

    }
}
