namespace MarvellousWorks.PracticalPattern.Singleton.Classic
{
    /// <summary>
    /// ����������ģʽ�������ʵ�ַ�ʽ
    /// </summary>
    public class Singleton
    {
        static Singleton instance;   // Ψһʵ��
        protected Singleton() { }   // ��տͻ������ֱ��ʵ����

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
