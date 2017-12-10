using System;
namespace MarvellousWorks.PracticalPattern.Memento.Classic
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
        T State { get; set; }
    }

    public abstract class MementoBase<T> : IMemento<T>
        where T : IState
    {
        public virtual T State { get; set; }
    }

    /// <summary>
    /// ����ķ����߶���ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// /// <typeparam name="M"></typeparam>
    public interface IOriginator<T, M>
        where T : IState
        where M : IMemento<T>, new()
    {
        IMemento<T> Memento { get;}
    }

    public abstract class OriginatorBase<T, M>
        where T : IState
        where M : IMemento<T>, new()
    {
        /// <summary>
        /// �����߶����״̬
        /// </summary>
        protected T state;

        /// <summary>
        /// ��״̬���浽����¼�����ߴӱ���¼�ָ�֮ǰ��״̬
        /// </summary>
        public virtual IMemento<T> Memento
        {
            get { return new M() { State = this.state }; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                state = value.State;
            }
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
    /// ���屸��¼����
    /// </summary>
    public class Memento : MementoBase<Position> { }

    /// <summary>
    /// ���巢��������
    /// </summary>
    public class Originator : OriginatorBase<Position, Memento>
    {
        /// <summary>
        /// ���ͻ�����ʹ�õķǱ���¼��ز���
        /// </summary>
        public void UpdateX(int x){state.X = x;}
        public void DecreaseX(){state.X--;}
        public void IncreaseY(){state.Y++;}
        public Position Current { get { return state; } }
    }
}
