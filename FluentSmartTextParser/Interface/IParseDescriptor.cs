using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface
{
    public interface IParseDescriptor<T>
    {
        ParseResult<T> Parse();
    }
}
