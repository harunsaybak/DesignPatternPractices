using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Interpreter.RegExpression;
namespace MarvellousWorks.PracticalPattern.Interpreter.Tests.RegExpression
{
    [TestClass]
    public class ExpressionFixture
    {
        Context context;

        [TestInitialize]
        public void Initialize()
        {
            context = new Context();
        }

        [TestMethod]
        public void TestEmailExpression()
        {
            context.Content = "zhao@hotmail.com, liu@gmail.com, test";
            context.Operator = 'M'; // ����ƥ����Ϣ
            IRegExpression expression = new EmailRegExpression();
            expression.Evaluate(context);
            // ȷ���Ƿ������а�������Email��Ϣ
            Assert.AreEqual<int>(2, context.Matches.Count);
            Assert.AreEqual<string>("zhao@hotmail.com", context.Matches[0]);
            Assert.AreEqual<string>("liu@gmail.com", context.Matches[1]);
        }

        [TestMethod]
        public void TestChineseExpression()
        {
            context.Content = "����";
            context.Operator = 'M'; // ����ƥ����Ϣ
            IRegExpression expression = new ChineseRegExpression();
            expression.Evaluate(context);
            Assert.AreEqual<int>(1, context.Matches.Count);
            context.Content = "����test";
            expression.Evaluate(context);
            Assert.AreEqual<int>(0, context.Matches.Count);
        }

        [TestMethod]
        public void TestReplacement()
        {
            context.Content = "a   b   c   d";
            context.Operator = 'R'; // ����ƥ����Ϣ
            context.Replacement = ",";
            IRegExpression expression = new StringRegExpression(@"\s+");
            expression.Evaluate(context);
            Assert.AreEqual<string>("a,b,c,d", context.Content);
        }
    }
}
