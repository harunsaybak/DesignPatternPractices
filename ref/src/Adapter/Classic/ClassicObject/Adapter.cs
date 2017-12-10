namespace MarvellousWorks.PracticalPattern.Adapter.Classic.ClassicObject
{
    public class Adapter : ITarget
    {
        public Adapter(Adaptee adaptee)
        {
            Adaptee = adaptee;
        }

        public Adaptee Adaptee{ get; private set;}    // Adaptee����

        public void Request()
        {
            // ��������
            Adaptee.SpecifiedRequest();    // ����Adaptee
        }
    }
}
