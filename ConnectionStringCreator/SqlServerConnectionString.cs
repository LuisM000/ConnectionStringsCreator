namespace ConnectionStringCreator
{
    public class SqlServerConnectionString:ConnectionStringBase<SqlServerConnectionString>
    {
        protected override string AssignmentOperator { get { return "="; } }
        protected override string Separator { get { return ";"; } }


        public bool? Encrypt { get; private set; }
        public bool IntegratedSecurity { get; set; }
        public bool? MultipleActiveResultSets { get; set; }
        public bool? TrustedConnection { get; set; }

        protected override void InitializePropertiesToValue()
        {
            base.ChangePropertyText(c => c.Server, "Data Source");
            base.ChangePropertyText(c => c.Database, "Initial Catalog");
            base.ChangePropertyText(c => c.User, "User ID", null, string.Empty);
            base.ChangePropertyText(c => c.Password, "Password", null, string.Empty);
            base.ChangePropertyText(c => c.Encrypt, "Encrypt", null);
            base.ChangePropertyText(c => c.IntegratedSecurity, "Integrated Security", false);
            base.ChangePropertyText(c => c.MultipleActiveResultSets, "MultipleActiveResultSets", null);
            base.ChangePropertyText(c => c.TrustedConnection, "Trusted_Connection", null);

        }

    }
}
