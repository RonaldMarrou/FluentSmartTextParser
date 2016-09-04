namespace FluentSmartTextParser.Interface.Delimited
{
    public interface IDelimitedTypeDescriptor
    {
        IDelimitedPropertyDescriptor DelimitedString();

        IDelimitedPropertyDescriptor DelimitedDecimal();

        IDelimitedPropertyDescriptor DelimitedInteger();
    }
}
