using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface
{
    public interface ISmartTextParser
    {
        ParserResult<T> Parse<T>();
    }
}
