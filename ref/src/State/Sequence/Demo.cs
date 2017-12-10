namespace MarvellousWorks.PracticalPattern.State.Sequence
{
    /// <summary>
    /// �����״̬�ӿ�
    /// </summary>
    public interface IState
    {
        void Open(IContext context);
        void Close(IContext context);
        void Query(IContext context);
    }

    public interface IContext
    {
        IState State { get; set; }
        IContext Open();
        IContext Close();
        IContext Query();
    }

    /// <summary>
    /// �����Context����
    /// </summary>
    public abstract class ContextBase : IContext
    {
        /// <summary>
        /// ʵ�ʿ��ƴ����״̬����
        /// </summary>
        public virtual IState State { get; set; }

        public virtual IContext Open() 
        {
            State.Open(this);
            return this;
        }
        public virtual IContext Close() 
        {
            State.Close(this);
            return this;
        }
        public virtual IContext Query()
        {
            State.Query(this);
            return this;
        }
    }
}
