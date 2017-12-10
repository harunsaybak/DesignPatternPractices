using System;
namespace MarvellousWorks.PracticalPattern.Singleton.Threading
{
    public class Singleton
    {
        Singleton() { }

        [ThreadStatic]  // ˵��ÿ��Instance���ڵ�ǰ�߳��ھ�̬
        static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
    }
}
