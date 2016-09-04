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
    public class DelimitedParser : BaseParser, IParser
    {
        private readonly ISetter[] _setters;

        public DelimitedParser(ISetter[] setters)
        {
            _setters = setters;
        }

        public ParserResult<T> Parse<T>(string file, Dictionary<string, string> schemaFields, List<SmartTextParserProperty> properties)
        {
            var result = new ParserResult<T>();

            PropertyInfo[] propertyInfoList = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var className = typeof(T).Name;

            var metadataErrors = GetMetadataErrorList(propertyInfoList, properties, className);

            if(metadataErrors.Any())
            {
                metadataErrors.ForEach(f => result.Errors.Add(f));

                return result;
            }

            var delimitedBy = schemaFields["DelimitedBy"];

            var lineCount = 0;

            foreach (var line in File.ReadAllLines(file))
            {
                var values = line.Split(new string[] { delimitedBy }, StringSplitOptions.None);

                T newObject = (T)Activator.CreateInstance(typeof(T));

                var hasErrors = false;

                foreach (var property in properties)
                {
                    int position = property.Positions["Position"];

                    if(property.Required)
                    {
                        if (values.Length <= position)
                        {
                            result.Errors.Add(new ParserError()
                            {
                                Property = property.Name,
                                Description = $"Property {property.Name} out of index at line {lineCount}"
                            });

                            hasErrors = true;

                            continue;
                        }

                        if (values[position].IsNullOrEmpty())
                        {
                            result.Errors.Add(new ParserError()
                            {
                                Property = property.Name,
                                Description = $"Required Property {property.Name} is empty at line {lineCount}"
                            });

                            hasErrors = true;

                            continue;
                        }
                    }                    

                    if(values.Length > position && !values[position].IsNullOrEmpty())
                    {                      
                        var setter = _setters.First(x => x.GetPropertyType() == property.Type);

                        var isSet = setter.Set<T>(newObject, property.Name, values[position]);

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

        public TextSchemaType GetSchemaType()
        {
            return TextSchemaType.DelimitedByString;
        }
    }
}
