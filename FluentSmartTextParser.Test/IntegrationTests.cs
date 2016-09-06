using FluentSmartTextParser.Impl;
using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using FluentSmartTextParser.Model.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FluentSmartTextParser.Test
{
    public class IntegrationTests
    {
        private string _delimitedFileLocation;
        private string _positionalFileLocation;

        [SetUp]
        public void SetUpTest()
        {
            _delimitedFileLocation = @"..\..\Files\DelimitedTextFile.txt";
            _positionalFileLocation = @"..\..\Files\PositionalTextFile.txt";
        }

        [Test]
        public void Parse_CheckDelimitedTextFile_ResultReturned()
        {
            var sut = new DelimitedParser(
                    new ISetter[]
                    {
                        new IntegerSetter(),
                        new DecimalSetter(),
                        new StringSetter(),
                        new DateTimeSetter()
                    }
                );

            var result = sut.Parse<MockedClass>
                (
                    _delimitedFileLocation,
                    new Dictionary<string, string>() { { "DelimitedBy", "," } },
                    new List<SmartTextParserProperty>()
                    {
                        new SmartTextParserProperty()
                        {
                            Name = "MockedStringProperty",
                            Required = true,
                            Type = PropertyType.String,
                            Positions = new Dictionary<string, int> { { "Position", 0 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedDateTimeProperty",
                            Required = true,
                            Type = PropertyType.DateTime,
                            Positions = new Dictionary<string, int> { { "Position", 1 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedIntegerProperty",
                            Required = true,
                            Type = PropertyType.Integer,
                            Positions = new Dictionary<string, int> { { "Position", 2 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedDecimalProperty",
                            Required = true,
                            Type = PropertyType.Decimal,
                            Positions = new Dictionary<string, int> { { "Position", 3 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedOptionalStringProperty",
                            Required = false,
                            Type = PropertyType.String,
                            Positions = new Dictionary<string, int> { { "Position", 4 } }
                        },
                        new SmartTextParserProperty()
                        {
                            Name = "MockedOptionalIntegerProperty",
                            Required = false,
                            Type = PropertyType.Integer,
                            Positions = new Dictionary<string, int> { { "Position", 5 } }
                        }
                    }
                );

            Assert.AreEqual(8, result.Results.Count);
        }

        [Test]
        public void Parse_CheckDelimitedTextFileWithFluent_ResultReturned()
        {
            var sut = new Impl.FluentSmartTextParser(
                    new SmartTextParser(
                        new ParserFactory(
                            new IParser[]
                            {
                                new DelimitedParser(
                                       new ISetter[]
                                       {
                                           new IntegerSetter(),
                                           new DecimalSetter(),
                                           new StringSetter(),
                                           new DateTimeSetter()
                                       }
                                    )
                            })
                ));

            var result = sut.DelimitedBy(",")
                .AddProperty("MockedStringProperty")
                    .Position(0)
                    .String()
                    .Required(true)
                .AddProperty("MockedDateTimeProperty")
                    .Position(1)
                    .DateTime("yyyy-MM-dd")
                    .Required(true)
                .AddProperty("MockedIntegerProperty")
                    .Position(2)
                    .Integer()
                    .Required(true)
                .AddProperty("MockedDecimalProperty")
                    .Position(3)
                    .Decimal()
                    .Required(true)
                .AddProperty("MockedOptionalStringProperty")
                    .Position(4)
                    .String()
                    .Required(false)
                .AddProperty("MockedOptionalIntegerProperty")
                    .Position(5)
                    .Integer()
                    .Required(false)
                .MapTo<MockedClass>()
                .Parse(_delimitedFileLocation);

            Assert.AreEqual(8, result.Results.Count);
        }

        [Test]
        public void Parse_CheckPositionalTextFileWithFluent_ResultReturned()
        {
            var sut = new Impl.FluentSmartTextParser(
                    new SmartTextParser(
                        new ParserFactory(
                            new IParser[]
                            {
                                new DelimitedParser(
                                       new ISetter[]
                                       {
                                           new IntegerSetter(),
                                           new DecimalSetter(),
                                           new StringSetter(),
                                           new DateTimeSetter()
                                       }
                                    ),
                                new PositionalParser(
                                       new ISetter[]
                                       {
                                           new IntegerSetter(),
                                           new DecimalSetter(),
                                           new StringSetter(),
                                           new DateTimeSetter()
                                       }
                                    )
                            })
                ));

            var result = sut.Positional()
                    .AddProperty("MockedStringProperty")
                        .StartPosition(0)
                        .EndPosition(8)
                        .String()
                        .Required(true)
                    .AddProperty("MockedDateTimeProperty")
                        .StartPosition(8)
                        .EndPosition(18)
                        .DateTime("yyyy-MM-dd")
                        .Required(true)
                    .AddProperty("MockedDecimalProperty")
                        .StartPosition(18)
                        .EndPosition(26)
                        .Decimal()
                        .Required(true)
                    .AddProperty("MockedOptionalStringProperty")
                        .StartPosition(26)
                        .EndPosition(52)
                        .String()
                        .Required(false)
                .MapTo<MockedClass>()
                .Parse(_positionalFileLocation);

            Assert.AreEqual(8, result.Results.Count);
        }
    }

    public class MockedClass
    {
        public string MockedStringProperty { get; set; }

        public DateTime MockedDateTimeProperty { get; set; }

        public int MockedIntegerProperty { get; set; }

        public decimal MockedDecimalProperty { get; set; }

        public string MockedOptionalStringProperty { get; set; }

        public int? MockedOptionalIntegerProperty { get; set; }
    }
}
