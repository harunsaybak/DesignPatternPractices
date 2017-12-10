using System;
using System.Collections.Generic;
using System.Web;
namespace MarvellousWorks.PracticalPattern.Singleton.WebContext
{
    public class Singleton
    {
        /// <summary>
        /// �㹻���ӵ�һ��keyֵ�����ں�HttpContext�е���������������
        /// </summary>
        const string Key = "marvellousWorks.practical.singleton";
        Singleton() { }

        public static Singleton Instance
        {
            get
            {
                // ����HttpContext��Lazyʵ��������
                Singleton instance = (Singleton)HttpContext.Current.Items[Key];
                if (instance == null)
                {
                    instance = new Singleton();
                    HttpContext.Current.Items[Key] = instance;
                }
                return instance;
            }
        }
    }
}
