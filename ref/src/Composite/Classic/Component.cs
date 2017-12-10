using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Composite.Classic
{
    public abstract class Component
    {
        /// <summary>
        /// �����ӽڵ�
        /// </summary>
        protected IList<Component> children;

        /// <summary>
        /// Leaf��Composite�Ĺ�ͬ����. setter��ʽע������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ʵֻ��Composite���Ͳ�������Ҫʵ�ֵĹ���
        /// </summary>
        /// <param name="child"></param>
        public virtual void Add(Component child){children.Add(child);}
        public virtual void Remove(Component child) { children.Remove(child); }
        public virtual Component this[int index] { get { return children[index]; } }
        
        /// <summary>
        /// ��ʾ�õĲ��䷽����ʵ�ֵ����������Ҷ���������ʵ�����Եݹ�
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetNameList()  
        {
            yield return Name;
            if ((children != null) && (children.Count > 0))
                foreach (Component child in children)
                    foreach (string item in child.GetNameList())
                        yield return item;
        }
    }

}
