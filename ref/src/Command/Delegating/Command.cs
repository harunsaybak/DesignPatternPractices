using System;
using System.Linq;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Command.Delegating
{
    /// <summary>
    /// ��ͬ�Ľ���������
    /// </summary>
    public class Receiver1 { public void A() { } }
    public class Receiver2 { public void B() { } }
    public class Receiver3 { public static void C() { } }

    /// <summary>
    /// ������
    /// </summary>
    public class Invoker
    {
        List<Action> handlers = new List<Action>();
        public void AddHandler(Action handler) { handlers.Add(handler); }

        public void Run()
        {
            handlers.ForEach(x=>x());
        }
    }
}
