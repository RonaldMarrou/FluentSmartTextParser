using System;

namespace FluentSmartTextParser.Interface
{
    public interface IDelimitedDescriptor
    {
        IDelimitedPropertyDescriptor AddFirstStringProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IDelimitedPropertyDescriptor AddFirstIntegerProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IDelimitedPropertyDescriptor AddFirstDecimalProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);
    }
}
