using System.Linq.Expressions;
using ConnectionStringCreator.Helpers;
using ConnectionStringCreator.Test.DummyClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringCreator.Test.Helpers
{
    [TestClass]
    public class ReflectionHelperShould
    {
        [TestMethod]
        public void generate_string_memberExpression_from_expresion()
        {
            MemberExpression member = ReflectionHelper.GetMemberExpression<Foo>(c => c.Bar);

            Assert.AreEqual("Bar", member.Member.Name);
        }

        [TestMethod]
        public void generate_bool_memberExpression_from_expresion()
        {
            MemberExpression member = ReflectionHelper.GetMemberExpression<Foo>(c => c.Dummy);

            Assert.AreEqual("Dummy", member.Member.Name);
        }


        [TestMethod]
        public void generate_name_of_string_expression()
        {
            string memberName = ReflectionHelper.GetMemberName<Foo>(c => c.Bar);

            Assert.AreEqual("Bar", memberName);
        }

        [TestMethod]
        public void generate_name_of_bool_expression()
        {
            string memberName = ReflectionHelper.GetMemberName<Foo>(c => c.Dummy);

            Assert.AreEqual("Dummy", memberName);
        }


        [TestMethod]
        public void get_memberName_from_memberExpression()
        {
            MemberExpression member = ReflectionHelper.GetMemberExpression<Foo>(c => c.Dummy);

            string memberName = ReflectionHelper.GetMemberName(member);

            Assert.AreEqual("Dummy", memberName);
        }


        [TestMethod]
        public void get_empty_memberName_from_null()
        {
            string memberName = ReflectionHelper.GetMemberName(null);

            Assert.AreEqual(string.Empty, memberName);
        }


        [TestMethod]
        public void get_propertyValue_from_propertyName()
        {
            Foo foo = new Foo() { Bar = "BarValue" };

            var value = ReflectionHelper.GetPropertyValue<Foo>(foo, "Bar");

            Assert.AreEqual("BarValue", value);
        }

        [TestMethod]
        public void get_propertyStringValue_from_memberExpression()
        {
            Foo foo = new Foo() { Bar = "BarValue" };
            MemberExpression member = ReflectionHelper.GetMemberExpression<Foo>(c => c.Bar);

            string value = ReflectionHelper.GetPropertyStringValue<Foo>(foo, member);

            Assert.AreEqual("BarValue", value);
        }


    }
}
