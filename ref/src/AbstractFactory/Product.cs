namespace MarvellousWorks.PracticalPattern.AbstractFactory
{
    /// <summary>
    /// ���岻ͬ���͵ĳ����Ʒ
    /// </summary>
    public interface IProductA { }
    public interface IProductB { }
    public interface IProductC { }


    /// <summary>
    /// ��������Ʒ����
    /// </summary>
    public class ProductA1 : IProductA { }
    public class ProductA2X : IProductA { }
    public class ProductA2Y : IProductA { }
    public class ProductB1 : IProductB { }
    public class ProductB2 : IProductB { }
    public class ProductC1 : IProductC { }
    public class ProductC2 : IProductC { }
}
