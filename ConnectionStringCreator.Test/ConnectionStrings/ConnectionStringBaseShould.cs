using ConnectionStringCreator.Test.DummyClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringCreator.Test.ConnectionStrings
{
    [TestClass]
    public class ConnectionStringBaseShould
    {
        [TestMethod]
        public void change_property_name()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c=>c.DummyProperty,"NewDummy");

            string connection = connectionString.GetConnectionString();

            Assert.IsTrue(connection.Contains("NewDummy"));
        }

        [TestMethod]
        public void change_property_name_with_ignore_values()
        {
            DummyConnectionString connectionString = new DummyConnectionString()
            {
                DummyProperty = "ignored string"
            };
            connectionString.ChangePropertyText(c => c.DummyProperty, "Dummy","ignored string");

            string connection = connectionString.GetConnectionString();

            Assert.IsFalse(connection.Contains("Dummy"));
        }


        [TestMethod]
        public void create_connectionString_with_DummyProperty_without_value()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.DummyProperty, "Dummy");

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Dummy=;",connection);
        }

        [TestMethod]
        public void create_connectionString_with_DummyProperty_with_value()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.DummyProperty, "Dummy");
            connectionString.DummyProperty = "Dummy value";

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Dummy=Dummy value;", connection);
        }

        [TestMethod]
        public void create_connectionString_with_DummyProperty_with_value_but_is_ignored()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.DummyProperty, "Dummy","Dummy value");
            connectionString.DummyProperty = "Dummy value";

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual(string.Empty, connection);
        }

        [TestMethod]
        public void create_connectionString_with_DummyProperty_and_Server()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.Server, "Server");
            connectionString.ChangePropertyText(c => c.DummyProperty, "Dummy");
            connectionString.DummyProperty = "Dummy value";
            connectionString.Server = "Server value";

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Server=Server value;Dummy=Dummy value;", connection);
        }

        [TestMethod]
        public void create_connectionString_with_DummyBoolProperty()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.DummyBoolProperty, "Dummy bool");
            connectionString.DummyBoolProperty = true;

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Dummy bool=True;", connection);
        }
        

        [TestMethod]
        public void create_connectionString_with_single_mapped_DummyBoolProperty()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.DummyBoolProperty, "Dummy bool");
            connectionString.DummyBoolProperty = true;
            connectionString.MapValue(c => c.DummyBoolProperty).Map(true, "Verdadero");

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Dummy bool=Verdadero;", connection);
        }

        [TestMethod]
        public void create_connectionString_with_multiple_mapped_DummyBoolProperty()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.DummyBoolProperty, "Dummy bool");
            connectionString.DummyBoolProperty = false;
            connectionString.MapValue(c => c.DummyBoolProperty).Map(true, "Verdadero").Map(false,"Falso");

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Dummy bool=Falso;", connection);
        }

        [TestMethod]
        public void create_connectionString_with_mapped_DummyBoolProperty_but_not_use_mapped_value()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.DummyBoolProperty, "Dummy bool");
            connectionString.DummyBoolProperty = false;
            connectionString.MapValue(c => c.DummyBoolProperty).Map(true, "Verdadero");

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Dummy bool=False;", connection);
        }

        [TestMethod]
        public void add_new_static_value_to_connectionString()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.AddStaticValues("Servidor","1985:20");

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Servidor=1985:20;", connection);
        }

        [TestMethod]
        public void create_connectionString_with_DummyProperty_with_value_and_static_value()
        {
            DummyConnectionString connectionString = new DummyConnectionString();
            connectionString.ChangePropertyText(c => c.DummyProperty, "Dummy");
            connectionString.DummyProperty = "Dummy value";
            connectionString.AddStaticValues("Servidor", "1985:20");

            string connection = connectionString.GetConnectionString();

            Assert.AreEqual("Dummy=Dummy value;Servidor=1985:20;", connection);
        }

    }
}
