using FluentSmartTextParser.Impl;
using Moq;
using NUnit.Framework;

namespace FluentSmartTextParser.Test.Setter
{ 
    [TestFixture]
    public class DecimalSetterTest
    {
        [TestCase("245", 245)]
        [TestCase("269.74", 269.74)]
        [TestCase("16416649.6499", 16416649.6499)]
        [TestCase("1", 1)]
        [TestCase("532653463", 532653463)]
        public void Set_StringIsDecimal_IsSet(string value, decimal expected)
        {
            FooDecimal fooDecimal = new FooDecimal();

            DecimalSetter sut = new DecimalSetter();
            var isSet = sut.Set(fooDecimal, "FooProperty", value, null);

            Assert.IsTrue(isSet);
            Assert.AreEqual(expected, fooDecimal.FooProperty);            
        }

        [TestCase("245S")]
        [TestCase("235235SFA")]
        [TestCase("SOMERANDOMSTRING")]
        [TestCase("WHATEVER")]
        [TestCase("IMNOTADECIMAL")]
        [TestCase(null)]
        public void Set_StringIsNotDecimal_IsNotSet(string value)
        {
            FooDecimal fooDecimal = new FooDecimal();

            DecimalSetter sut = new DecimalSetter();
            var isSet = sut.Set(fooDecimal, "FooProperty", value, null);

            Assert.IsFalse(isSet);
        }

        [TestCase("245S")]
        [TestCase("235235SFA")]
        [TestCase("SOMERANDOMSTRING")]
        [TestCase("WHATEVER")]
        [TestCase("IMNOTADECIMAL")]
        public void Set_FieldDoesNotExist_IsNotSet(string field)
        {
            FooDecimal fooDecimal = new FooDecimal();

            DecimalSetter sut = new DecimalSetter();
            var isSet = sut.Set(fooDecimal, field, "0", null);

            Assert.IsFalse(isSet);
        }
    }

    public class FooDecimal
    {
        public decimal FooProperty { get; set; }
    }
}
