using System;
using System.Collections.Generic;
using System.Linq;
namespace MarvellousWorks.PracticalPattern.Visitor.ReflectionAndDynamic
{
    /// <summary>
    /// visitor ��ҪӰ��� Element
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// �������
        /// </summary>
        string Name { get; set;}
        double Income { get; set;}
        int VacationDays { get; set;}

        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// ����Visitor�ӿ�
    /// </summary>
    public interface IVisitor
    {
        void Visit(IEmployee employee);
    }   

    /// <summary>
    /// һ�������Element�� Visitable
    /// </summary>
    public class Employee : IEmployee
    {
        public Employee(string name, double income, int vacationDays)
        {
            Name = name;
            Income = income;
            VacationDays = vacationDays;
        }

        public string Name { get; set; }
        public double Income { get; set; }
        public int VacationDays { get; set; }

        /// <summary>
        /// ����Visitor������Ĳ���
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// ��һ�������Element
    /// </summary>
    public class Manager : Employee
    {
        public string Department { get; private set; }

        public Manager(string name, double income, int vacationDays, string department)
            : base(name, income, vacationDays)
        {
            Department = department;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Ϊ�˱��ڶ�HRϵͳ�Ķ�����������������ӵļ�������
    /// </summary>
    public class EmployeeCollection : List<IEmployee>
    {
        /// <summary>
        /// �������������Accept����
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IVisitor visitor)
        {
            if(visitor == null) 
                throw new ArgumentNullException("visitor");
            ForEach(x=>x.Accept(visitor));
        }
    }
}
