using System.Linq;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Observer.Concept2
{
    /// <summary>
    /// ������A/B/C�������Ľӿ�
    /// </summary>
    public interface IUpdatableObject
    {
        int Data { get;}
        void Update(int newData);
    }

    /// <summary>
    /// ����Ĵ���������
    /// </summary>
    public class A : IUpdatableObject
    {
        int data;
        public int Data{get { return this.data;}}
        public void Update(int newData) { this.data = newData; }
    }
    public class B : IUpdatableObject
    {
        int count;
        public int Data { get { return this.count; } }
        public void Update(int newData) { this.count = newData; }

    }
    public class C : IUpdatableObject
    {
        int n;
        public int Data { get { return this.n; } }
        public void Update(int newData) { this.n = newData; }
    }


    public class X : List<IUpdatableObject>
    {
        int data;
        public void Update(int newData)
        {
            this.data = newData;
            ForEach(x => x.Update(newData));
        }
    }
}
