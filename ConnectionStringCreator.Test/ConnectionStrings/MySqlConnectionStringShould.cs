using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringCreator.Test.ConnectionStrings
{
    [TestClass]
    public class MySqlConnectionStringShould
    {
        [TestMethod]
        public void generate_connectionString_with_basic_values()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString();

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=;Database=;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_user_and_password()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString
            {
                Server = "server",
                Database = "database",
                User = "user",
                Password = "password"
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;Uid=user;Pwd=password;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_IntegratedSecurity()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;IntegratedSecurity=yes;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_Port()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                Port = 8080
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;Port=8080;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_Encription()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                Encrypt = true
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;Encrypt=true;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_SSLMode_Preferred()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                SSLMode = MySqlConnectionString.SSLModes.Preferred
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;SslMode=Preferred;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_SSLMode_Required()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                SSLMode = MySqlConnectionString.SSLModes.Required
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;SslMode=Required;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_CertificatePassword()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                CertificatePassword = "certificate"
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;CertificatePassword=certificate;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_AllowBatch()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                AllowBatch = false
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;AllowBatch=False;", connectionString);
        }


        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_AllowUserVariables()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                AllowUserVariables = true
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;AllowUserVariables=True;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_AllowZeroDateTime()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                AllowZeroDateTime = true
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;AllowZeroDateTime=True;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_ConvertZeroDateTime()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                ConvertZeroDateTime = true
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;ConvertZeroDateTime=True;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_ConnectionLifeTime()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                ConnectionLifeTime = 300
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;ConnectionLifeTime=300;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_DefaultCommandTimeout()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                DefaultCommandTimeout = 20
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;default command timeout=20;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_ConnectionTimeout()
        {
            MySqlConnectionString mySqlConnectionString = new MySqlConnectionString()
            {
                Server = "server",
                Database = "database",
                ConnectionTimeout = 5
            };

            string connectionString = mySqlConnectionString.GetConnectionString();

            Assert.AreEqual("Server=server;Database=database;Connection Timeout=5;", connectionString);
        }

    }
}
