using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Impl
{
    public class StringSetter : ISetter
    {
        public bool Set<T>(T affectedObject, string propertyName, string value)
        {
            var classProperty = typeof(T).GetProperty(propertyName);

            classProperty.SetValue(affectedObject, value);

            return true;
        }

        PropertyType ISetter.GetType()
        {
            return PropertyType.Decimal;
        }

        public string GetTypeName()
        {
            return typeof(string).Name.ToUpper();
        }
    }
}
