using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSmartTextParser.Interface
{
    public interface IDelimitedPropertyDescriptor
    {
        IDelimitedPropertyDescriptor AddStringProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IDelimitedPropertyDescriptor AddIntegerProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IDelimitedPropertyDescriptor AddDecimalProperty(string name, int position, int minLenght, int maxLenght, Func<string, string> extraValidationMethod, bool required = false);

        IParseDescriptor<T> MapTo<T>();
    }
}
