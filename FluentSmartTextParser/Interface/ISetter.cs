using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface
{
    public interface ISetter
    {
        bool Set<T>(T affectedObject, string propertyName, string value);

        PropertyType GetPropertyType();

        string GetPropertyTypeName();
    }
}
