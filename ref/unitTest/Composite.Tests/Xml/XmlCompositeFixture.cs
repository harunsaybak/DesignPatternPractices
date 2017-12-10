using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.XPath;
using System.Linq;
using System.Xml.Linq;
using MarvellousWorks.PracticalPattern.Composite.Tests.Properties;

namespace MarvellousWorks.PracticalPattern.Composite.Tests.Xml
{
    [TestClass]
    public class TestXmlComposite
    {
        class Department : Composite.Iterating.Composite { }

        class Corporate : Composite.Iterating.Composite
        {
            const string DepartmentPath = "/corporate/department";
            const string NameItem = "name";
            const string DepartmentItem = "department";

            /// <summary>
            /// ͨ��XPath����XML��ʽ���������
            /// </summary>
            /// <returns></returns>
            public IEnumerable<Department> GetDepartments()
            {
                return from node in XDocument.Parse(Resource.CorporateV1)
                           .XPathSelectElements(DepartmentPath)
                       select new Department()
                                  {
                                      Name = node.Attribute(NameItem).Value
                                  };
            }
        }

        const string XmlFileName = "Corporate.xml";

        [TestMethod]
        public void Test()
        {
            var departments = new Corporate().GetDepartments();

            //  ��֤ͨ��XPath����XML��ʽ���������
            //  ͬʱ��ȷ���Ƿ��ܹ����б�Ҫ��ɸѡ
            Assert.AreEqual<int>(2, departments.Count());
            Assert.AreEqual<string>("market", departments.ElementAt(0).Name);
            Assert.AreEqual<string>("sales", departments.ElementAt(1).Name);
        }
    }
}
