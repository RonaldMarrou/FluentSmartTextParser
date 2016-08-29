namespace FluentSmartTextParser.Interface
{
    public interface IDescriptor
    {
        IPositionalDescriptor Positional();

        IDelimitedDescriptor DelimitedBy(string delimitedBy);
    }
}
