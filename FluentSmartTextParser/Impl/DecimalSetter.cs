using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Impl
{
    public class DecimalSetter : ISetter
    {
        public bool Set<T>(T affectedObject, string propertyName, string value)
        {
            decimal temporary = 0;

            if(!decimal.TryParse(value, out temporary))
            {
                return false;
            }

            var classProperty = typeof(T).GetProperty(propertyName);

            classProperty.SetValue(affectedObject, temporary);


            return true;
        }

        PropertyType ISetter.GetType()
        {
            return PropertyType.Decimal;
        }

        public string GetTypeName()
        {
            return typeof(decimal).Name.ToUpper();
        }
    }
}
