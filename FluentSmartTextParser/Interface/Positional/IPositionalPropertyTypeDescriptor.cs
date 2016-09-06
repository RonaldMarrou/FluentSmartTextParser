namespace FluentSmartTextParser.Interface.Positional
{
    public interface IPositionalPropertyTypeDescriptor
    {
        IPositionalPropertyDescriptor Integer();

        IPositionalPropertyDescriptor Decimal();

        IPositionalPropertyDescriptor String();

        IPositionalPropertyDescriptor DateTime(string format = null);
    }
}
