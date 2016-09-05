using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using System.Collections.Generic;

namespace FluentSmartTextParser.Impl
{
    public class IntegerSetter : ISetter
    {
        public bool Set<T>(T affectedObject, string propertyName, string value, Dictionary<string, string> custom)
        {
            int temporary = 0;

            if(!int.TryParse(value, out temporary))
            {
                return false;
            }

            var classProperty = typeof(T).GetProperty(propertyName);

            if (classProperty == null)
            {
                return false;
            }

            classProperty.SetValue(affectedObject, temporary);


            return true;
        }

        PropertyType ISetter.GetPropertyType()
        {
            return PropertyType.Integer;
        }

        public string GetPropertyTypeName()
        {
            return typeof(int).Name.ToUpper();
        }
    }
}
