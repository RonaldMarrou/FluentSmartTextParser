using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Impl
{
    public class StringSetter : ISetter
    {
        public bool Set<T>(T affectedObject, string propertyName, string value)
        {
            var classProperty = typeof(T).GetProperty(propertyName);

            if (classProperty == null)
            {
                return false;
            }

            classProperty.SetValue(affectedObject, value);

            return true;
        }

        public PropertyType GetPropertyType()
        {
            return PropertyType.Decimal;
        }

        public string GetPropertyTypeName()
        {
            return typeof(string).Name.ToUpper();
        }
    }
}
