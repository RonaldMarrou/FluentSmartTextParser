using FluentSmartTextParser.Interface;
using System;
using System.Collections.Generic;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using System.Reflection;
using System.Linq;
using System.IO;

namespace FluentSmartTextParser.Impl
{
    public class DelimitedParser : IParser
    {
        private readonly ISetter[] _setters;

        public DelimitedParser(ISetter[] setters)
        {
            _setters = setters;
        }

        public ParserResult<T> Parse<T>(string file, Dictionary<string, string> schemaFields, List<SmartTextParserProperty> properties)
        {
            var result = new ParserResult<T>();

            PropertyInfo[] propertyInfoList = typeof(T).GetProperties(BindingFlags.Public);

            var notFoundProperties = properties.Where(f => !propertyInfoList.Any(g => g.Name.Equals(f.Name)));

            foreach(var notFoundProperty in notFoundProperties)
            {
                result.Errors.Add(new ParserError()
                {
                    Property = notFoundProperty.Name,
                    Description = $"Property {notFoundProperty.Name} not found on class {typeof(T).Name} metadata"
                });
            }

            var wrongNotRequiredProperties = properties.Where(f => !f.Required  && f.Type != PropertyType.String && propertyInfoList.Any(
                x => x.Name.Equals(f) && (x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                ));

            foreach (var wrongNotRequiredProperty in wrongNotRequiredProperties)
            {
                result.Errors.Add(new ParserError()
                {
                    Property = wrongNotRequiredProperty.Name,
                    Description = $"Property {wrongNotRequiredProperty.Name} must be required due to class {typeof(T).Name} metadata"
                });
            }

            if (result.Errors.Any())
            {
                return result;
            }

            var delimitedBy = schemaFields["DelimitedBy"];

            var lineCount = 0;

            foreach(var line in File.ReadAllLines(file))
            {
                var values = line.Split(delimitedBy.ToCharArray());

                foreach(var property in properties)
                {
                    int position = property.Positions["Position"];

                    if (property.Required && values.Length <= position)
                    {
                        result.Errors.Add(new ParserError()
                        {
                            Property = property.Name,
                            Description = $"Property {property.Name} out of index at line {lineCount}"
                        });
                    }      
                    
                    if(property.Required && string.IsNullOrEmpty(values[position].Trim()))
                    {
                        result.Errors.Add(new ParserError()
                        {
                            Property = property.Name,
                            Description = $"Required Property {property.Name} is empty at line {lineCount}"
                        });
                    }

                    if(!property.Required && values.Length <= position)
                    {
                        lineCount++;

                        continue;
                    }

                    T newObject = (T)Activator.CreateInstance(typeof(T));

                    var setter = _setters.First(x => x.GetType() == property.Type);

                    var isSet = setter.Set<T>(newObject, property.Name, values[position]);

                    if(!isSet)
                    {
                        result.Errors.Add(new ParserError()
                        {
                            Property = property.Name,
                            Description = $"Required Property {property.Name} at line {lineCount} is not a valid {setter.GetTypeName()}"
                        });
                    }

                    result.Results.Add(newObject);

                    lineCount++;
                }
            }


            throw new Exception();
        }

        TextSchemaType IParser.GetType()
        {
            return TextSchemaType.DelimitedByString;
        }
    }
}
