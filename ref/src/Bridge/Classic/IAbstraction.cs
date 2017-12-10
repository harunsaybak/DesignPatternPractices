namespace MarvellousWorks.PracticalPattern.Bridge.Classic
{
    public interface IImpl
    {
        void OperationImpl();
    }

    public interface IAbstraction
    {
        /// <summary>
        /// ��һ���ܹؼ�
        /// ��������N���任���ص�������ɶ��� ��1������ + N-1���仯���ء���������ϵ
        /// �Ա仯�ĸ���������һ�ΰ���
        /// </summary>
        IImpl Implementor { get; set;}
        void Operation();
    }

    public class ConcreteImplementatorA : IImpl
    {
        public void OperationImpl() { }
    }
    public class ConcreteImplementatorB : IImpl
    {
        public void OperationImpl() { }
    }

    public class RefinedAbstraction : IAbstraction
    {
        /// <summary>
        /// setter��ʽ����ע��
        /// </summary>
        public IImpl Implementor { get; set; }

        public void Operation()
        {
            // ��������
            Implementor.OperationImpl();
        }
    }
}
