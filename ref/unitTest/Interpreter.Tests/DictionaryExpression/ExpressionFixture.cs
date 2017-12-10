using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Interpreter.DictionaryExpression;
namespace MarvellousWorks.PracticalPattern.Interpreter.Tests.DictionaryExpression
{
    [TestClass]
    public class ExpressionFixture
    {
        enum Color { Red, Green, Blue }
        
        IDictionary<string, string> data;
        SimpleDictionaryExpression expression;

        [TestInitialize]
        public void Initialize()
        {
            data = new Dictionary<string, string>()
                       {
                           {"R", "Red"},
                           {"G", "Green"},
                           {"B", "Blue"}
                       };
            expression = new SimpleDictionaryExpression();
        }

        [TestMethod]
        public void Test()
        {
            // ׼������
            expression.Store = new EnumDictionaryStore<Color>();
            // ����Enum��Key��Value�Ľ�������
            var context = new Context() { Key = Color.Red, Operator = 'F' };// from key to value
            expression.Evaluate(context);
            Assert.AreEqual<string>("Red", context.Value as string);

            // ����Enum��Value��Key�Ľ�������
            context = new Context() { Value = "Blue", Operator = 'T' }; // from value to key
            expression.Evaluate(context);
            Assert.AreEqual<Color>(Color.Blue, (Color)(context.Key));

            // ���Զ���һ��DictionaryStore��ܵĽ�������
            expression.Store = new StringDictionaryStore() {Data = data};
            expression.Evaluate(context);
            Assert.AreEqual<string>("B", context.Key as string);
        }
    }
}
