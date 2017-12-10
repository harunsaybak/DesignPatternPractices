using System.Configuration;
namespace MarvellousWorks.PracticalPattern.Concept.Configurating
{
    // ������� name �� description ���Ե�����Ԫ��
    // name ������Ϊ ConfigurationElementCollection����Ӧ�� key
    public abstract class NamedConfigurationElementBase : ConfigurationElement
    {
        const string NameItem = "name";
        const string DescriptionItem = "description";

        [ConfigurationProperty(NameItem, IsKey = true, IsRequired = true)]
        public virtual string Name { get { return base[NameItem] as string; } }

        [ConfigurationProperty(DescriptionItem, IsRequired = false)]
        public virtual string Description { get { return base[DescriptionItem] as string; } }
    }

    public class ExampleConfigurationElement : NamedConfigurationElementBase { }
    public class DiagramConfigurationElement : NamedConfigurationElementBase { }
    public class PictureConfigurationElement : NamedConfigurationElementBase
    {
        const string ColorizedItem = "colorized";

        [ConfigurationProperty(ColorizedItem, IsRequired = true)]
        public bool Colorized { get { return (bool)base[ColorizedItem]; } }
    }
}