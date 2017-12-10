using System;
using System.Collections.Generic;
using System.Linq;
namespace MarvellousWorks.PracticalPattern.Visitor.Delegating
{
    /// <summary>
    /// visitor ��ҪӰ��� Element
    /// </summary>
    public abstract class EmployeeBase
    {
        /// <summary>
        /// �������
        /// </summary>
        public virtual string Name { get; set;}
        public virtual double Income { get; set;}
        public virtual int VacationDays { get; set;}
    }

    /// <summary>
    /// һ�������Element�� Visitable
    /// </summary>
    public class Employee : EmployeeBase { }
    public class Manager : Employee
    {
        public string Department { get; set; }
    }

    /// <summary>
    /// Ϊ�˱��ڶ�HRϵͳ�Ķ�����������������ӵļ�������
    /// </summary>
    public class EmployeeCollection : List<EmployeeBase>{}
}
