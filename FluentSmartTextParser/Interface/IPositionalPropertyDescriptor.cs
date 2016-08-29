using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSmartTextParser.Interface
{
    public interface IPositionalPropertyDescriptor
    {
        IPositionalPropertyDescriptor AddStringProperty(string name, int startPosition, int endPosition, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IPositionalPropertyDescriptor AddIntegerProperty(string name, int startPosition, int endPosition, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IPositionalPropertyDescriptor AddDecimalProperty(string name, int startPosition, int endPosition, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IParseDescriptor<T> MapTo<T>();
    }
}
