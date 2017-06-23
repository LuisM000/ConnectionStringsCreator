using System;
using ConnectionStringCreator.Descriptors;
using ConnectionStringCreator.Helpers;
using ConnectionStringCreator.Test.DummyClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringCreator.Test.Descriptors
{
    [TestClass]
    public class MemberDescriptorShould
    {
        [TestMethod]
        public void ignore_string_value()
        {
            Foo foo = new Foo()
            {
                Bar = "value that is ignored"
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName", "value that is ignored");

            bool isIgnored = memberDescriptor.ShouldBeIgnored(foo);

            Assert.IsTrue(isIgnored);
        }

        [TestMethod]
        public void ignore_null_value()
        {
            Foo foo = new Foo()
            {
                Bar = null
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName", null);

            bool isIgnored = memberDescriptor.ShouldBeIgnored(foo);

            Assert.IsTrue(isIgnored);
        }

        [TestMethod]
        public void no_ignore_similar_string_value()
        {
            Foo foo = new Foo()
            {
                Bar = "value that is ignored"
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName", "value9 that is ignored");

            bool isIgnored = memberDescriptor.ShouldBeIgnored(foo);

            Assert.IsFalse(isIgnored);
        }

        [TestMethod]
        public void ignore_only_selected_property()
        {
            Foo foo = new Foo()
            {
                Bar = "Bar value that is ignored"
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Dummy);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName", "value that is ignored");

            bool isIgnored = memberDescriptor.ShouldBeIgnored(foo);

            Assert.IsFalse(isIgnored);
        }

        [TestMethod]
        public void ignore_multiple_values()
        {
            Foo foo = new Foo()
            {
                Bar = "value that is ignored"
            };
            Foo fooEmpty = new Foo()
            {
                Bar = String.Empty
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName", "value that is ignored",string.Empty);

            bool isIgnored = memberDescriptor.ShouldBeIgnored(foo);
            bool isIgnoredEmpty = memberDescriptor.ShouldBeIgnored(fooEmpty);
            Assert.IsTrue(isIgnored && isIgnoredEmpty);
         }

        

        [TestMethod]
        public void throw_exception_when_map_value_is_repeated()
        {
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName");
  
            try
            {
                memberDescriptor.Map(true, "valor").Map(true, "valor repetido");
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);

            }
        }


        [TestMethod]
        public void returns_a_property_value()
        {
            Foo foo = new Foo()
            {
                Bar = "this is a property value"
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName");

            object propertyValue = memberDescriptor.GetPropertyValue(foo);

            Assert.AreEqual("this is a property value", propertyValue);
        }


        [TestMethod]
        public void returns_a_property_mapped_value()
        {
            Foo foo = new Foo()
            {
                Bar = "this is a property value"
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName");
            memberDescriptor.Map("this is a property value", "mapped value");

            object propertyValue = memberDescriptor.GetPropertyValue(foo);

            Assert.AreEqual("mapped value", propertyValue);
        }


        [TestMethod]
        public void ignore_with_exactly_value()
        {
            Foo foo = new Foo()
            {
                Bar = "value that is ignored"
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName", "value that is ignored");

            bool isIgnored = memberDescriptor.ShouldBeIgnoredWithValue("value that is ignored");

            Assert.IsTrue(isIgnored);
        }

        [TestMethod]
        public void no_ignore_with_exactly_value()
        {
            Foo foo = new Foo()
            {
                Bar = "value that is ignored"
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName", "value that is ignored");

            bool isIgnored = memberDescriptor.ShouldBeIgnoredWithValue("with this value is not ignored");

            Assert.IsFalse(isIgnored);
        }

        [TestMethod]
        public void ignore_with_exactly_null_value()
        {
            Foo foo = new Foo()
            {
                Bar = null
            };
            var member = ReflectionHelper.GetMemberExpression<Foo>(f => f.Bar);
            MemberDescriptor memberDescriptor = new MemberDescriptor(member, "dummyName", null);

            bool isIgnored = memberDescriptor.ShouldBeIgnoredWithValue(null);

            Assert.IsTrue(isIgnored);
        }

    }
}

