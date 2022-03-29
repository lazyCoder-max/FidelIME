using FidelIME.Plugin.IME;
using NUnit.Framework;

namespace FidelIME.Plugin.Tests
{
    [TestFixture]
    public class InputEditorShould
    {
        InputEditor inputEditor = new InputEditor();
        [TestCase(null, ExpectedResult = true)]
        [TestCase("first", ExpectedResult = true)]
        [TestCase("second", ExpectedResult = false)]
        [Test]
        public bool GetResult_WhenIsFirstCharacter_Called(string value)
        {
            if (value != null)
                inputEditor.InputCharacter.Add(value);
            var result = inputEditor.IsFirstCharacter;
            return result;
        }
    }
}
