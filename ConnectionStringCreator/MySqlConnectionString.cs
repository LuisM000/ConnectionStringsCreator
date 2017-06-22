namespace ConnectionStringCreator
{
    public class MySqlConnectionString : ConnectionStringBase<MySqlConnectionString>
    {
        public enum SSLModes { Preferred=1, Required=2, None = 0 };
        protected override string AssignmentOperator { get { return "="; } }
        protected override string Separator { get { return ";"; } }

        public bool IntegratedSecurity { get; set; }
        public int? Port { get; set; }
        public bool? Encrypt { get; set; }
        public SSLModes SSLMode { get; set; }
        public string CertificatePassword { get; set; }
        public bool? AllowBatch { get; set; }
        public bool? AllowUserVariables { get; set; }
        public bool? AllowZeroDateTime { get; set; }
        public bool? ConvertZeroDateTime { get; set; }
        public int? ConnectionLifeTime { get; set; }
        public int? DefaultCommandTimeout { get; set; }
        public int? ConnectionTimeout { get; set; }

        protected override void InitializePropertiesToValue()
        {
            base.ChangePropertyText(c => c.Server, "Server");
            base.ChangePropertyText(c => c.Database, "Database");
            base.ChangePropertyText(c => c.User, "Uid", null, string.Empty);
            base.ChangePropertyText(c => c.Password, "Pwd", null, string.Empty);
            base.ChangePropertyText(c => c.IntegratedSecurity, "IntegratedSecurity", false);
            base.ChangePropertyText(c => c.Port, "Port", null);
            base.ChangePropertyText(c => c.Encrypt, "Encrypt", null);
            base.ChangePropertyText(c => c.SSLMode, "SslMode", SSLModes.None);
            base.ChangePropertyText(c => c.CertificatePassword, "CertificatePassword", null, string.Empty);
            base.ChangePropertyText(c => c.AllowBatch, "AllowBatch", null);
            base.ChangePropertyText(c => c.AllowUserVariables, "AllowUserVariables", null);
            base.ChangePropertyText(c => c.AllowZeroDateTime, "AllowZeroDateTime", null);
            base.ChangePropertyText(c => c.ConvertZeroDateTime, "ConvertZeroDateTime", null);
            base.ChangePropertyText(c => c.ConnectionLifeTime, "ConnectionLifeTime", null);
            base.ChangePropertyText(c => c.DefaultCommandTimeout, "default command timeout", null);
            base.ChangePropertyText(c => c.ConnectionTimeout, "Connection Timeout", null);

            base.MapValue(c => c.IntegratedSecurity).Map(true, "yes").Map(false, "no");
            base.MapValue(c => c.Encrypt).Map(true, "true").Map(false, "false");
            base.MapValue(c => c.SSLMode).Map(SSLModes.Preferred, "Preferred").Map(SSLModes.Required, "Required");

        }

    }
}
