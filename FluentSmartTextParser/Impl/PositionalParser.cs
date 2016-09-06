using FluentSmartTextParser.Extension;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FluentSmartTextParser.Impl
{
    public class PositionalParser : BaseParser, IParser
    {
        private readonly ISetter[] _setters;

        public PositionalParser(ISetter[] setters)
        {
            _setters = setters;
        }

        public ParserResult<T> Parse<T>(string file, Dictionary<string, string> schemaFields, List<SmartTextParserProperty> properties)
        {
            var result = new ParserResult<T>();

            PropertyInfo[] propertyInfoList = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var className = typeof(T).Name;

            var metadataErrors = GetMetadataErrorList(propertyInfoList, properties, className);

            if (metadataErrors.Any())
            {
                metadataErrors.ForEach(f => result.Errors.Add(f));

                return result;
            }

            var lineCount = 0;

            foreach (var line in File.ReadAllLines(file))
            {
                var lineLenght = line.Length;

                T newObject = (T)Activator.CreateInstance(typeof(T));

                var hasErrors = false;

                foreach (var property in properties)
                {
                    var startPosition = property.Positions["StartPosition"];
                    var endPosition = property.Positions["EndPosition"];

                    if(startPosition >= lineLenght)
                    {
                        if (property.Required)
                        {
                            result.Errors.Add(new ParserError()
                            {
                                Property = property.Name,
                                Description = $"Property {property.Name} can not be found between positions {startPosition} and {endPosition} at line {lineCount}"
                            });

                            hasErrors = true;
                        }

                        continue;
                    }

                    endPosition = endPosition > lineLenght ? lineLenght : endPosition;

                    var value = line.Substring(startPosition, endPosition - startPosition);

                    if (value.IsNullOrEmpty())
                    {
                        if (property.Required)
                        {
                            result.Errors.Add(new ParserError()
                            {
                                Property = property.Name,
                                Description = $"Required Property {property.Name} is empty at line {lineCount}"
                            });

                            hasErrors = true;
                        }

                        continue;
                    }
                    else
                    {
                        var setter = _setters.First(x => x.GetPropertyType() == property.Type);

                        var isSet = setter.Set<T>(newObject, property.Name, value, property.Custom);

                        if (!isSet)
                        {
                            result.Errors.Add(new ParserError()
                            {
                                Property = property.Name,
                                Description = $"Required Property {property.Name} at line {lineCount} is not a valid {setter.GetPropertyTypeName()}"
                            });

                            hasErrors = true;
                        }
                    }
                }

                if (!hasErrors)
                {
                    result.Results.Add(newObject);
                }

                lineCount++;
            }

            return result;
        }

        TextSchemaType IParser.GetSchemaType()
        {
            return TextSchemaType.Positional;
        }
    }
}
