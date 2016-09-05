using FluentSmartTextParser.Model;
using System.Collections.Generic;

namespace FluentSmartTextParser.Interface
{
    public interface ISetter
    {
        bool Set<T>(T affectedObject, string propertyName, string value, Dictionary<string, string> custom);

        PropertyType GetPropertyType();

        string GetPropertyTypeName();
    }
}
