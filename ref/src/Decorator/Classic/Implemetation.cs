namespace MarvellousWorks.PracticalPattern.Decorator.Classic
{
    /// <summary>
    /// ����װ����
    /// ���ڡ���ס�
    /// </summary>
    public class BoldDecorator : DecoratorBase
    {
        public BoldDecorator(IText target) : base(target) { }
        public override string Content
        {
            get { return ChangeToBoldFont(target.Content); }
        }

        public string ChangeToBoldFont(string content)
        {
            return "<b>" + content + "</b>";
        }
    }

    /// <summary>
    /// ����װ����
    /// ���ڡ���ס�
    /// </summary>
    public class ColorDecorator : DecoratorBase
    {
        public ColorDecorator(IText target) : base(target) { }
        public override string Content
        {
            get { return AddColorTag(target.Content); }
        }

        public string AddColorTag(string content)
        {
            return "<color>" + target.Content + "</color>"; 
        }
    }

    /// <summary>
    /// ����װ����
    /// ���ڡ����֡�
    /// </summary>
    public class BlockAllDecorator : DecoratorBase
    {
        public BlockAllDecorator(IText target) : base(target) { }
        public override string Content
        {
            get { return string.Empty; }
        }
    }

    /// <summary>
    /// ʵ���������
    /// </summary>
    public class TextObject : IText 
    {
        public string Content { get { return "hello"; } }
    }
}
