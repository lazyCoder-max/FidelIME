using FidelIME.Plugin.IME;
using FidelIME.Plugin.IME.Interfaces;
using NUnit.Framework;

namespace FidelIME.Plugin.Tests
{
    [TestFixture]
    public class SyllableControlShould
    {
        [TestCase(arg: new string[] { "a", "b" }, ExpectedResult = "ኣብ")]
        [TestCase(arg: new string[] { "se", "la", "m" }, ExpectedResult = "ሰላም")]
        [TestCase(arg: new string[] { "selamta" }, ExpectedResult = "ሰላምታ")]
        [TestCase(arg: new string[] { "gemena" }, ExpectedResult = "ገመና")]
        [TestCase(arg: new string[] { "qdus" }, ExpectedResult = "ቅዱስ")]
        [TestCase(arg: new string[] { "zebider" }, ExpectedResult = "ዘቢደር")]
        [TestCase(arg: new string[] { "gemecis" }, ExpectedResult = "ገመቺስ")]
        [TestCase(arg: new string[] { "quanqua" }, ExpectedResult = "ቋንቋ")]
        [TestCase(arg: new string[] { "betamdesblognal" }, ExpectedResult = "በታምደስብሎግናል")]
        [TestCase(arg: new string[] { "fw" }, ExpectedResult = "ᎈ")]
        [TestCase(arg: new string[] { "mwie" }, ExpectedResult = "ᎂ")]
        // check if the second
        [Test]
        public string Return_Value_ToEthiopic(string[] value)
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
