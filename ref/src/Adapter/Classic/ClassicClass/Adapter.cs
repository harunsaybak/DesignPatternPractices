namespace MarvellousWorks.PracticalPattern.Adapter.Classic.ClassicClass
{
    public class Adapter : Adaptee, ITarget
    {
        public void Request()
        {
            // ��������
            base.SpecifiedRequest();    // ����Adaptee
        }
    }
}
