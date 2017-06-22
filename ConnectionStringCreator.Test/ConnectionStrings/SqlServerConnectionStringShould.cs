using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringCreator.Test.ConnectionStrings
{
    [TestClass]
    public class SqlServerConnectionStringShould
    {
        [TestMethod]
        public void generate_connectionString_with_basic_values()
        {
            SqlServerConnectionString sqlConnectionString=new SqlServerConnectionString();

            string connectionString = sqlConnectionString.GetConnectionString();

            Assert.AreEqual("Data Source=;Initial Catalog=;", connectionString);
        }


        [TestMethod]
        public void generate_connectionString_with_Server_Database_User_and_Password()
        {
            SqlServerConnectionString sqlConnectionString = new SqlServerConnectionString
            {
                Server = "server",
                Database = "database",
                User = "user",
                Password = "password"
            };

            string connectionString = sqlConnectionString.GetConnectionString();

            Assert.AreEqual("Data Source=server;Initial Catalog=database;User ID=user;Password=password;", connectionString);
         }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_IntegratedSecurity()
        {
            SqlServerConnectionString sqlConnectionString = new SqlServerConnectionString
            {
                Server = "server",
                Database = "database",
                IntegratedSecurity = true
            };

            string connectionString = sqlConnectionString.GetConnectionString();

            Assert.AreEqual("Data Source=server;Initial Catalog=database;Integrated Security=True;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_MultipleActiveResultSets()
        {
            SqlServerConnectionString sqlConnectionString = new SqlServerConnectionString
            {
                Server = "server",
                Database = "database",
                MultipleActiveResultSets = true
            };

            string connectionString = sqlConnectionString.GetConnectionString();

            Assert.AreEqual("Data Source=server;Initial Catalog=database;MultipleActiveResultSets=True;", connectionString);
        }

        [TestMethod]
        public void generate_connectionString_with_Server_Database_and_TrustedConnection()
        {
            SqlServerConnectionString sqlConnectionString = new SqlServerConnectionString
            {
                Server = "server",
                Database = "database",
                TrustedConnection = true
            };

            string connectionString = sqlConnectionString.GetConnectionString();

            Assert.AreEqual("Data Source=server;Initial Catalog=database;Trusted_Connection=True;", connectionString);
        }
    }
}
