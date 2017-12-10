using System;
using System.Linq;
namespace MarvellousWorks.PracticalPattern.Decorator.WithBuilder
{
    /// <summary>
    /// ΪĿ����������װ�Ρ��Ĵ�����
    /// </summary>
    public class DecoratorBuilder
    {
        static readonly DecoratorAssembler assembly = new DecoratorAssembler();

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IText BuildUp(IText target) 
        {
            if (target == null) throw new ArgumentNullException("target");
            var types = assembly[target.GetType()];
            if ((types != null) && (types.Count() > 0))
                types.ToList().ForEach(x => target = (IText)Activator.CreateInstance(x, target));
            return target;
        }
    }
}
