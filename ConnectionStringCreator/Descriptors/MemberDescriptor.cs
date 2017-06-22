using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ConnectionStringCreator.Helpers;

namespace ConnectionStringCreator.Descriptors
{

    public interface IMemberDescriptor
    {
        string Name { get; }
        bool ShouldBeIgnored(object value);
        object GetPropertyValue(object value);
    }

    public interface IMap
    {
        MemberDescriptor Map(object value, object mappedValue);
    }

    public class MemberDescriptor: IMemberDescriptor, IMap
    {
        private readonly MemberExpression member;
        private readonly List<PropertyMap> propertyMaps;
        private IList<object> IgnoredValues { get; set; }

        private readonly bool canBeIgnored;

        public MemberDescriptor(MemberExpression memberExpression, string name)
        {
            this.member = memberExpression;
            this.MemberName = ReflectionHelper.GetMemberName(memberExpression);
            this.Name = name;
            this.propertyMaps=new List<PropertyMap>();
        }

        public MemberDescriptor(MemberExpression memberExpression, string name, params object[] ignoredValues) : this(memberExpression, name)
        {
            this.canBeIgnored = true;
            if (ignoredValues != null)
                this.IgnoredValues = ignoredValues;
            else
            {
                this.IgnoredValues = new List<object> {null};
            }
        }


        public string MemberName { get; private set; }
        public string Name { get; set; }

        public MemberDescriptor Map(object value, object mappedValue)
        {
            PropertyMap propertyMap = new PropertyMap(value, mappedValue);
            this.CheckDuplicatePropertyMap(propertyMap);
            this.propertyMaps.Add(propertyMap);
            return this;
        }

        public bool ShouldBeIgnored(object value)
        {
            if (!this.canBeIgnored || this.IgnoredValues == null)
                return false;

            var currentvalue = ReflectionHelper.GetPropertyValue(value, this.member.Member.Name);
            if (this.IgnoredValues.Any(c =>(c==null && currentvalue==null) || (c!=null && c.Equals(currentvalue))))
                return true;

            return false;
        }

        public object GetPropertyValue(object value)
        {
            var memberValue = ReflectionHelper.GetPropertyValue(value, ReflectionHelper.GetMemberName(this.member));
            PropertyMap propertyMap = this.propertyMaps.FirstOrDefault(c => c.Value.Equals(memberValue));
            return propertyMap != null ? propertyMap.MappedValue : memberValue;
        }


        private void CheckDuplicatePropertyMap(PropertyMap propertyMap)
        {
            if (propertyMaps.Any(p => p.Value.Equals(propertyMap.Value)))
            {
                throw new ArgumentException(string.Format("Duplicate mapping for property {0} detected.", propertyMap.Value));
            }
        }
    }

    public class StaticMemberDescriptor : IMemberDescriptor
    {
        private readonly object currentValue;
        public StaticMemberDescriptor(string name, object value)
        {
            this.Name = name;
            this.currentValue = value;
        }

        public string Name { get; set; }

        public bool ShouldBeIgnored(object value)
        {
            return false;
        }

        public object GetPropertyValue(object value)
        {
            return this.currentValue;
        }

    }
}
