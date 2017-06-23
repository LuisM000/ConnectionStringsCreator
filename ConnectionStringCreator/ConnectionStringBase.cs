using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ConnectionStringCreator.Descriptors;
using ConnectionStringCreator.Helpers;

namespace ConnectionStringCreator
{
    public abstract class ConnectionStringBase<T> where T: ConnectionStringBase<T>
    {
        private readonly IList<IMemberDescriptor> memberDescriptors;
        public ConnectionStringBase()
        {
            this.memberDescriptors = new List<IMemberDescriptor>();
            InitializePropertiesToValue();
        }

        protected abstract string AssignmentOperator { get; }
        protected abstract string Separator { get; }

        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        protected abstract void InitializePropertiesToValue();


        public virtual string GetConnectionString()
        {
            string connectionString=string.Empty;
            foreach (IMemberDescriptor memberDescriptor in this.memberDescriptors)
            {
                if (!memberDescriptor.ShouldBeIgnored(this))
                {
                    object propertyValue = memberDescriptor.GetPropertyValue(this);
                    connectionString += string.Concat(memberDescriptor.Name, this.AssignmentOperator,
                        propertyValue!=null?propertyValue.ToString():string.Empty, this.Separator);
                }
                
            }
            return connectionString;
        }

        private MemberDescriptor GetMemberDescriptor(Expression<Func<T, object>> expression)
        {
            string memberName = ReflectionHelper.GetMemberName(expression);
            return (MemberDescriptor)this.memberDescriptors.FirstOrDefault(m => m is IMap && ((MemberDescriptor)m).MemberName.Equals(memberName));
        }

        public void ChangePropertyText(Expression<Func<T, object>> expression, string newValue)
        {
            string memberName = ReflectionHelper.GetMemberName(expression);
            if (memberName != null)
            {
                IMemberDescriptor currentMember = this.GetMemberDescriptor(expression); 
                if (currentMember != null)
                    this.memberDescriptors.Remove(currentMember);
                this.memberDescriptors.Add(new MemberDescriptor(ReflectionHelper.GetMemberExpression(expression), newValue));

            }
        }
        public void ChangePropertyText(Expression<Func<T, object>> expression, string newValue, params object[] ignoreValues)
        {
            string memberName = ReflectionHelper.GetMemberName(expression);
            if (memberName != null)
            {
                IMemberDescriptor currentMember = this.GetMemberDescriptor(expression);
                if (currentMember != null)
                    this.memberDescriptors.Remove(currentMember);
                this.memberDescriptors.Add(new MemberDescriptor(ReflectionHelper.GetMemberExpression(expression), newValue, ignoreValues));
            }
        }

        public bool IsIgnoredWithValue(Expression<Func<T, object>> expression, object value)
        {
            return this.GetMemberDescriptor(expression).ShouldBeIgnoredWithValue(value);
        }

        public void AddStaticValues(string name, string value)
        {
            this.memberDescriptors.Add(new StaticMemberDescriptor(name,value));
        }

        public MemberDescriptor MapValue(Expression<Func<T, object>> expression)
        {
            return this.GetMemberDescriptor(expression);
        }

    }
}
