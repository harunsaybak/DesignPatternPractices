using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Memento.StackMode
{
    /// <summary>
    /// Ϊ�˱��ڶ������״̬����������Ľӿ�
    /// </summary>
    public interface IState { }

    /// <summary>
    /// ������¼����ӿ�
    /// </summary>
    public interface IMemento<T> where T : IState
    {
        T State { get; set;}
    }

    /// <summary>
    /// �����ڲ�����¼���͵ķ����߳�����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OriginatorBase<T>
        where T : IState
    {
        /// <summary>
        /// �����߶����״̬
        /// </summary>
        protected T state;

        /// <summary>
        /// �ѱ���¼����Ϊ�����ߵ��ڲ�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected class InternalMemento : IMemento<T>
        {
            public T State { get; set; }
        }

        protected virtual IMemento<T> CreateMemento()
        {
            return new InternalMemento() {State = this.state};
        }

        /// <summary>
        /// ���ڱ������α�����Ϣ�Ķ�ջ
        /// </summary>
        Stack<IMemento<T>> stack = new Stack<IMemento<T>>();

        /// <summary>
        /// ��״̬���浽����¼
        /// </summary>
        public virtual void SaveCheckpoint() 
        {
            stack.Push(CreateMemento());
        }
        /// <summary>
        /// �ӱ���¼�ָ�֮ǰ��״̬
        /// </summary>
        public virtual void Undo()
        {
            if (stack.Count == 0) return;
            this.state = stack.Pop().State;
        }
    }


    /// <summary>
    /// ����״̬����
    /// </summary>
    public struct Position : IState
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// ���巢��������
    /// </summary>
    public class Originator : OriginatorBase<Position>
    {
        /// <summary>
        /// ���ͻ�����ʹ�õķǱ���¼��ز���
        /// </summary>
        /// <param name="x"></param>
        public void UpdateX(int x) { state.X = x; }
        public void DecreaseX() { state.X--; }
        public void IncreaseY() { state.Y++; }
        public Position Current { get { return state; } }
    }
}
