using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Impl
{
    public class IntegerSetter : ISetter
    {
        public bool Set<T>(T affectedObject, string propertyName, string value)
        {
            int temporary = 0;

            if(!int.TryParse(value, out temporary))
            {
                return false;
            }

            var classProperty = typeof(T).GetProperty(propertyName);

            classProperty.SetValue(affectedObject, temporary);


            return true;
        }

        PropertyType ISetter.GetType()
        {
            return PropertyType.Integer;
        }

        public string GetTypeName()
        {
            return typeof(int).Name.ToUpper();
        }
    }
}
