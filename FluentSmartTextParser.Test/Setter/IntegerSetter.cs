using FluentSmartTextParser.Impl;
using Moq;
using NUnit.Framework;

namespace FluentSmartTextParser.Test.Setter
{ 
    [TestFixture]
    public class IntegerSetterTest
    {
        [TestCase("245", 245)]
        [TestCase("269", 269)]
        [TestCase("16416649", 16416649)]
        [TestCase("1", 1)]
        [TestCase("532653463", 532653463)]
        public void Set_StringIsInteger_IsSet(string value, decimal expected)
        {
            FooInteger fooInteger = new FooInteger();

            IntegerSetter sut = new IntegerSetter();
            var isSet = sut.Set(fooInteger, "FooProperty", value);

            Assert.IsTrue(isSet);
            Assert.AreEqual(expected, fooInteger.FooProperty);            
        }

        [TestCase("245S")]
        [TestCase("235235SFA")]
        [TestCase("SOMERANDOMSTRING")]
        [TestCase("WHATEVER")]
        [TestCase("IMNOTADECIMAL")]
        public void Set_StringIsNotDecimal_IsNotSet(string value)
        {
            FooInteger fooInteger = new FooInteger();

            IntegerSetter sut = new IntegerSetter();
            var isSet = sut.Set(fooInteger, "FooProperty", value);

            Assert.IsFalse(isSet);
        }

        [TestCase("245S")]
        [TestCase("235235SFA")]
        [TestCase("SOMERANDOMSTRING")]
        [TestCase("WHATEVER")]
        [TestCase("IMNOTADECIMAL")]
        public void Set_FieldDoesNotExist_IsNotSet(string field)
        {
            FooInteger fooInteger = new FooInteger();

            IntegerSetter sut = new IntegerSetter();
            var isSet = sut.Set(fooInteger, field, "0");

            Assert.IsFalse(isSet);
        }
    }

    public class FooInteger
    {
        public int FooProperty { get; set; }
    }
}
