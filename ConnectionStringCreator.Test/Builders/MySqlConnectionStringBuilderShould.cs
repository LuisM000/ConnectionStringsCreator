using System;
using ConnectionStringCreator.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringCreator.Test.Builders
{
    [TestClass]
    public class MySqlConnectionStringBuilderShould
    {
        [TestMethod]
        public void create_basic_connectionString_with_IntegratedSecurity()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder("server", "database");


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void create_basic_connectionString_with_User_and_Password()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                User = "user",
                Password = "password"
            };
            MySqlConnectionString mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder("server", "database", "user", "password");


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void remove_User_and_Password_when_sets_true_IntegratedSecurity()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database", "user", "password").WithIntegratedSecurity(true);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void no_remove_User_and_Password_when_sets_false_IntegratedSecurity()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                User = "user",
                Password = "password"
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database", "user", "password").WithIntegratedSecurity(false);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_User_and_removes_IntegratedSecurity_to_ConnectionString_when_User_contains_text()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                User = "user"
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithUser("user");


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }


        [TestMethod]
        public void not_add_User_and_no_removes_IntegratedSecurity_to_ConnectionString_when_User_is_Empty()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithUser(string.Empty);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void not_add_User_and_no_removes_IntegratedSecurity_to_ConnectionString_when_User_is_Null()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithUser(null);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }


        [TestMethod]
        public void add_Password_and_removes_IntegratedSecurity_to_ConnectionString_when_Password_contains_text()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                Password = "password"
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithPassword("password");


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }


        [TestMethod]
        public void not_add_Password_and_no_removes_IntegratedSecurity_to_ConnectionString_when_Password_is_Empty()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithPassword(string.Empty);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void not_add_Password_and_no_removes_IntegratedSecurity_to_ConnectionString_when_Password_is_Null()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithPassword(null);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_Encrypt_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                Encrypt = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithEncrypt(true);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_WithSSLMode_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                SSLMode = MySqlConnectionString.SSLModes.Preferred
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithSSLMode(MySqlConnectionString.SSLModes.Preferred);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_CertificatePassword_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                CertificatePassword = "certificate password"
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithCertificatePassword("certificate password");


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_AllowBatch_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                AllowBatch = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithAllowBatch(true);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_AllowUserVariables_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                AllowUserVariables = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithAllowUserVariables(true);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_AllowZeroDateTime_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                AllowZeroDateTime = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithAllowZeroDateTime(true);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_ConvertZeroDateTime_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                ConvertZeroDateTime = true
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithConvertZeroDateTime(true);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_ConnectionLifeTime_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                ConnectionLifeTime = 2
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithConnectionLifeTime(2);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_DefaultCommandTimeout_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                DefaultCommandTimeout = 22
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithDefaultCommandTimeout(22);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }

        [TestMethod]
        public void add_ConnectionTimeout_to_ConnectionString()
        {
            MySqlConnectionString mySqlConnectionStringExpected = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true,
                ConnectionTimeout = 222
            };
            MySqlConnectionString mySqlConnectionStringBuilder =
                new MySqlConnectionStringBuilder("server", "database").WithConnectionTimeout(222);


            Assert.AreEqual(mySqlConnectionStringExpected.GetConnectionString(), mySqlConnectionStringBuilder.GetConnectionString());
        }
    }
}
