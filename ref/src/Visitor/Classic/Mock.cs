using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Visitor.Classic
{
    /// <summary>
    /// visitor ��ҪӰ��� Element
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// ������Է���
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
        void VisitEmployee(Employee employee);
        void VisitManager(Manager manager);
    }   

    /// <summary>
    /// һ�������Element
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
            visitor.VisitEmployee(this);
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
            visitor.VisitManager(this);
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

    /// <summary>
    /// �����Visitor, �����ݼ�����
    /// </summary>
    public class ExtraVacationVisitor : IVisitor
    {
        public void VisitEmployee(Employee employee)
        {
            employee.VacationDays += 1;
        }

        public void VisitManager(Manager manager)
        {
            manager.VacationDays += 2;
        }
    }
    /// <summary>
    /// �����Visitor, ��н
    /// </summary>
    public class RaiseSalaryVisitor : IVisitor
    {
        public void VisitEmployee(Employee employee)
        {
            employee.Income *= 1.1;
        }

        public void VisitManager(Manager manager)
        {
            manager.Income *= 1.2;
        }
    }
}
