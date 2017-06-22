namespace ConnectionStringCreator.Test.DummyClasses
{
    public class DummyConnectionString:ConnectionStringBase<DummyConnectionString>
    {
        public string DummyProperty { get; set; }
        public bool DummyBoolProperty { get; set; }

        protected override string AssignmentOperator
        {
            get { return "="; }
        }

        protected override string Separator
        {
            get { return ";"; }
        }

        protected override void InitializePropertiesToValue()
        {
        }
    }
}
