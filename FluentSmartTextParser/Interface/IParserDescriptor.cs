using FluentSmartTextParser.Model;

namespace FluentSmartTextParser.Interface
{
    public interface IParserDescriptor<T>
    {
        ParserResult<T> Parse(string file);
    }
}
