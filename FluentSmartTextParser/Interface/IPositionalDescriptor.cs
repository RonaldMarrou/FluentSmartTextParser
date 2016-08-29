using System;

namespace FluentSmartTextParser.Interface
{
    public interface IPositionalDescriptor
    {
        IPositionalPropertyDescriptor AddFirstStringProperty(string name, int startPosition, int endPosition, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IPositionalPropertyDescriptor AddFirstIntegerProperty(string name, int startPosition, int endPosition, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IPositionalPropertyDescriptor AddFirstDecimalProperty(string name, int startPosition, int endPosition, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);
    }
}
