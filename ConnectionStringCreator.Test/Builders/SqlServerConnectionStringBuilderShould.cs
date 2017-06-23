using System;
using ConnectionStringCreator.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringCreator.Test.Builders
{
    [TestClass]
    public class SqlServerConnectionStringBuilderShould
    {
        [TestMethod]
        public void create_basic_connectionString_with_IntegratedSecurity()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder = new SqlServerConnectionStringBuilder("server","database");
            

            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(),sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void create_basic_connectionString_with_User_and_Password()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                User = "user",
                Password = "password"
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder = new SqlServerConnectionStringBuilder("server", "database","user","password");


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void remove_User_and_Password_when_sets_true_IntegratedSecurity()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder = 
                new SqlServerConnectionStringBuilder("server", "database", "user", "password").WithIntegratedSecurity(true);
            

            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void no_remove_User_and_Password_when_sets_false_IntegratedSecurity()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                User = "user",
                Password = "password"
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database", "user", "password").WithIntegratedSecurity(false);


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_User_and_removes_IntegratedSecurity_to_ConnectionString_when_User_contains_text()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                User = "user"
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithUser("user");


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }


        [TestMethod]
        public void not_add_User_and_no_removes_IntegratedSecurity_to_ConnectionString_when_User_is_Empty()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithUser(string.Empty);


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void not_add_User_and_no_removes_IntegratedSecurity_to_ConnectionString_when_User_is_Null()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithUser(null);


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }


        [TestMethod]
        public void add_Password_and_removes_IntegratedSecurity_to_ConnectionString_when_Password_contains_text()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                Password = "password"
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithPassword("password");


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }


        [TestMethod]
        public void not_add_Password_and_no_removes_IntegratedSecurity_to_ConnectionString_when_Password_is_Empty()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithPassword(string.Empty);


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void not_add_Password_and_no_removes_IntegratedSecurity_to_ConnectionString_when_Password_is_Null()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithPassword(null);


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_Encrypt_to_ConnectionString()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                Encrypt = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithEncrypt(true);


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_MultipleActiveResultSets_to_ConnectionString()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithMultipleActiveResultSets(true);


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_WithTrustedConnection_to_ConnectionString()
        {
            SqlServerConnectionString sqlServerConnectionStringExpected = new SqlServerConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                TrustedConnection = true
            };
            SqlServerConnectionString sqlServerConnectionStringBuilder =
                new SqlServerConnectionStringBuilder("server", "database").WithTrustedConnection(true);


            Assert.AreEqual(sqlServerConnectionStringExpected.GetConnectionString(), sqlServerConnectionStringBuilder.GetConnectionString());
        }
        
    }
}
