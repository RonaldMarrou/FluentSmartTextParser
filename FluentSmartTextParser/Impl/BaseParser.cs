using FluentSmartTextParser.Extension;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentSmartTextParser.Impl
{
    public abstract class BaseParser
    {
        protected List<ParserError> GetMetadataErrorList(PropertyInfo[] propertyInfoList, List<SmartTextParserProperty> properties, string className)
        {
            List<ParserError> parserErrors = new List<ParserError>();

            var notFoundProperties = properties.Where(f => !propertyInfoList.Any(g => g.Name.Equals(f.Name) && g.PropertyType.Name.Equals(f.Type.GetDotNetType())));

            foreach (var notFoundProperty in notFoundProperties)
            {
                parserErrors.Add(new ParserError()
                {
                    Property = notFoundProperty.Name,
                    Description = $"Property {notFoundProperty.Name} not found on class {className} metadata"
                });
            }

            var wrongNotRequiredProperties = properties.Where(f => !f.Required && f.Type != PropertyType.String && propertyInfoList.Any(
                x => x.Name.Equals(f) && (x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                ));

            foreach (var wrongNotRequiredProperty in wrongNotRequiredProperties)
            {
                parserErrors.Add(new ParserError()
                {
                    Property = wrongNotRequiredProperty.Name,
                    Description = $"Property {wrongNotRequiredProperty.Name} must be required due to class {className} metadata"
                });
            }

            return parserErrors;
        }
    }
}
