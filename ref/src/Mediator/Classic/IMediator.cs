using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Mediator.Classic
{
    /// <summary>
    /// �����н��߽ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMediator<T>
    {
        /// <summary>
        /// �ṩ��IColleague�Ĵ�������
        /// </summary>
        void Change();

        /// <summary>
        /// ����Э����ϵ�ķ���
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="consumers"></param>
        void Introduce(IColleague<T> provider, IEnumerable<IColleague<T>> consumers);
        void Introduce(IColleague<T> provider, IColleague<T> consumer);
        void Introduce(IColleague<T> provider, params IColleague<T>[] consumers);
    }
}
