using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectionStringCreator.Builders
{
    public class SqlServerConnectionStringBuilder
    {
        private SqlServerConnectionString sqlConnectionString;

        public SqlServerConnectionStringBuilder(string server, string database)
        {
            sqlConnectionString = new SqlServerConnectionString()
            {
                Server = server,
                Database = database,
                IntegratedSecurity = true
            };
        }

        public SqlServerConnectionStringBuilder(string server, string database, string user, string password)
        {
            sqlConnectionString = new SqlServerConnectionString()
            {
                Server = server,
                Database = database,
                User = user,
                Password = password
            };
        }

        public SqlServerConnectionStringBuilder WithIntegratedSecurity(bool integratedSecurity)
        {
            sqlConnectionString.IntegratedSecurity = integratedSecurity;
            if (sqlConnectionString.IntegratedSecurity)
            {
                sqlConnectionString.User = string.Empty;
                sqlConnectionString.Password=string.Empty;
            }
            return this;
        }

        public SqlServerConnectionStringBuilder WithUser(string user)
        {
            if (!sqlConnectionString.IsIgnoredWithValue(c=>c.User,user))
            {
                sqlConnectionString.User = user;
                sqlConnectionString.IntegratedSecurity = false;
            }
         
            return this;
        }

        public SqlServerConnectionStringBuilder WithPassword(string password)
        {
            if (!sqlConnectionString.IsIgnoredWithValue(c => c.Password, password))
            {
                sqlConnectionString.Password = password;
                sqlConnectionString.IntegratedSecurity = false;
            }

            return this;
        }

        public SqlServerConnectionStringBuilder WithEncrypt(bool? encrypt)
        {
            sqlConnectionString.Encrypt = encrypt;
            return this;
        }

        public SqlServerConnectionStringBuilder WithMultipleActiveResultSets(bool? multipleActiveResult)
        {
            sqlConnectionString.MultipleActiveResultSets = multipleActiveResult;
            return this;
        }

        public SqlServerConnectionStringBuilder WithTrustedConnection(bool? trustedConnection)
        {
            sqlConnectionString.TrustedConnection = trustedConnection;
            return this;
        }


        public static implicit operator SqlServerConnectionString(SqlServerConnectionStringBuilder builder)
        {
            return builder.sqlConnectionString;
        }
    }
}
