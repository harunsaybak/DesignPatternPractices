using System;
using System.Collections.Generic;

namespace MarvellousWorks.PracticalPattern.Memento.Persistence
{
    /// <summary>
    /// Ϊ�˱��ڶ������״̬����������Ľӿ�
    /// </summary>
    public interface IState { }

    /// <summary>
    /// ���屣�汸����Ϣ�ĳ־ö������ӿ�
    /// ���ڳ־ö�������������ڶ�������߶���
    /// ���Ϊ�����ֲ�ͬʵ���ı������ݣ������ʱ����Ҫ�ṩ��
    /// 1�������߶����ʶ
    /// 2��������Ϣ�汾
    /// 3��״̬��Ϣ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPersistenceStore<T>
        where T : IState
    {
        void Store(string originatorID, int version, T target);
        T Find(string originatorID, int version);
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
        /// ���ڱ�ʾ�����߶���ı�ʶ
        /// </summary>
        protected string key;
        public OriginatorBase() { key = (new Guid()).ToString(); }

        /// <summary>
        /// ��ע��ĳ־û�����
        /// </summary>
        protected IPersistenceStore<T> store;

        /// <summary>
        /// ��״̬���浽����¼
        /// </summary>
        public virtual void SaveCheckpoint(int version)
        {
            store.Store(key, version, state);
        }

        /// <summary>
        /// �ӱ���¼�ָ�֮ǰ��״̬
        /// </summary>
        public virtual void Undo(int version)
        {
            state = store.Find(key, version);
        }
    }

    /// <summary>
    /// ����״̬����
    /// </summary>
    [Serializable]
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
        public Originator() 
        {
            store = new MementoPersistenceStore<Position>(); 
        }

        /// <summary>
        /// ���ͻ�����ʹ�õķǱ���¼��ز���
        /// </summary>
        /// <param name="x"></param>
        public void UpdateX(int x) { base.state.X = x; }
        public void DecreaseX() { base.state.X--; }
        public void IncreaseY() { base.state.Y++; }
        public Position Current { get { return base.state; } }
    }
}
