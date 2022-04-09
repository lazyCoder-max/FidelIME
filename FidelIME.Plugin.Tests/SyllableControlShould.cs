using FidelIME.Plugin.IME;
using FidelIME.Plugin.IME.Interfaces;
using NUnit.Framework;

namespace FidelIME.Plugin.Tests
{
    [TestFixture]
    public class SyllableControlShould
    {
        [TestCase("a", ExpectedResult = "ኣ")]
        [TestCase("u", ExpectedResult = "ኡ")]
        [TestCase("U", ExpectedResult = "ኡ")]
        [TestCase("i", ExpectedResult = "ኢ")]
        [TestCase("I", ExpectedResult = "ኢ")]
        [TestCase("A", ExpectedResult = "እ")]
        [TestCase("o", ExpectedResult = "ኦ")]
        [TestCase("e", ExpectedResult = "አ")]
        [TestCase("E", ExpectedResult = "አ")]
        [Test]
        public string Return_Value_ToEthiopic(string value)
        {
            ISyllableControl syllableControl = new SyllableControl(new InputEditor());
            var result = syllableControl.ToEthiopic(value);
            return result;
        }
        [TestCase("ha", ExpectedResult = "ሃ")]
        [Test]
        public string Return_EthiopicSyllable_When_GetSyllable_Invoked(string value)
        {
            ISyllableControl syllableControl = new SyllableControl(new InputEditor());
            var result = syllableControl.GetSyllable(value);
            return result;
        }
    }
}
