using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectionStringCreator.Builders
{
    public class MySqlConnectionStringBuilder
    {
        private MySqlConnectionString mySqlConnectionString;

        public MySqlConnectionStringBuilder(string server, string database)
        {
            mySqlConnectionString = new MySqlConnectionString()
            {
                Server = server,
                Database = database,
                IntegratedSecurity = true
            };
        }

        public MySqlConnectionStringBuilder(string server, string database, string user, string password)
        {
            mySqlConnectionString = new MySqlConnectionString()
            {
                Server = server,
                Database = database,
                User = user,
                Password = password
            };
        }



        public MySqlConnectionStringBuilder WithIntegratedSecurity(bool integratedSecurity)
        {
            mySqlConnectionString.IntegratedSecurity = integratedSecurity;
            if (mySqlConnectionString.IntegratedSecurity)
            {
                mySqlConnectionString.User = string.Empty;
                mySqlConnectionString.Password = string.Empty;
            }
            return this;
        }

        public MySqlConnectionStringBuilder WithUser(string user)
        {
            if (!mySqlConnectionString.IsIgnoredWithValue(c => c.User, user))
            {
                mySqlConnectionString.User = user;
                mySqlConnectionString.IntegratedSecurity = false;
            }

            return this;
        }

        public MySqlConnectionStringBuilder WithPassword(string password)
        {
            if (!mySqlConnectionString.IsIgnoredWithValue(c => c.Password, password))
            {
                mySqlConnectionString.Password = password;
                mySqlConnectionString.IntegratedSecurity = false;
            }

            return this;
        }


        public MySqlConnectionStringBuilder WithPort(int? port)
        {
            mySqlConnectionString.Port = port;
            return this;
        }
        public MySqlConnectionStringBuilder WithEncrypt(bool? encrypt)
        {
            mySqlConnectionString.Encrypt = encrypt;
            return this;
        }
        public MySqlConnectionStringBuilder WithSSLMode(MySqlConnectionString.SSLModes sslMode)
        {
            mySqlConnectionString.SSLMode = sslMode;
            return this;
        }
        public MySqlConnectionStringBuilder WithCertificatePassword(string certificatePassword)
        {
            mySqlConnectionString.CertificatePassword = certificatePassword;
            return this;
        }
        public MySqlConnectionStringBuilder WithAllowBatch(bool? allowBatch)
        {
            mySqlConnectionString.AllowBatch = allowBatch;
            return this;
        }
        public MySqlConnectionStringBuilder WithAllowUserVariables(bool? allowUserVariables)
        {
            mySqlConnectionString.AllowUserVariables = allowUserVariables;
            return this;
        }
        public MySqlConnectionStringBuilder WithAllowZeroDateTime(bool? allowZeroDateTime)
        {
            mySqlConnectionString.AllowZeroDateTime = allowZeroDateTime;
            return this;
        }
        public MySqlConnectionStringBuilder WithConvertZeroDateTime(bool? convertZeroDateTime)
        {
            mySqlConnectionString.ConvertZeroDateTime = convertZeroDateTime;
            return this;
        }
        public MySqlConnectionStringBuilder WithConnectionLifeTime(int? connectionLifeTime)
        {
            mySqlConnectionString.ConnectionLifeTime = connectionLifeTime;
            return this;
        }
        public MySqlConnectionStringBuilder WithDefaultCommandTimeout(int? defaultCommandTimeout)
        {
            mySqlConnectionString.DefaultCommandTimeout = defaultCommandTimeout;
            return this;
        }
        public MySqlConnectionStringBuilder WithConnectionTimeout(int? connectionTimeout)
        {
            mySqlConnectionString.ConnectionTimeout = connectionTimeout;
            return this;
        }

        public static implicit operator MySqlConnectionString(MySqlConnectionStringBuilder builder)
        {
            return builder.mySqlConnectionString;
        }
    }
}
