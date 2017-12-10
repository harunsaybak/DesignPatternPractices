using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.State.Classic
{
    /// <summary>
    /// �����״̬�ӿ�
    /// </summary>
    public interface IState
    {
        void Open();
        void Close();
        void Query();
    }

    /// <summary>
    /// �����Context����
    /// </summary>
    public abstract class ContextBase
    {
        /// <summary>
        /// ʵ�ʿ��ƴ����״̬����
        /// </summary>
        public virtual IState State{get; set;}

        #region state object controlled logic
        public virtual void Open() { State.Open(); }
        public virtual void Close() { State.Close(); }
        public virtual void Query() { State.Query(); }
        #endregion
    }
}
