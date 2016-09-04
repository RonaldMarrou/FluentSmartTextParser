using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedPropertyTypeDescriptor
    {
        IDelimitedPropertyDescriptor Integer();

        IDelimitedPropertyDescriptor Decimal();

        IDelimitedPropertyDescriptor String();
    }
}
