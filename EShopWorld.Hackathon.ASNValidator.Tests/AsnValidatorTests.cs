using EShopWorld.Hackathon.ASNValidator.Core;
using Xunit;

namespace EShopWorld.Hackathon.ASNValidator.Tests
{
    public class AsnValidatorTests
    {
        [Fact]
        public void XmlFileFailsValidation()
        {
            var passesValidation =
                AsnValidator.Validate("Schema.xsd", "WillFail.xml", out var validationExceptionMessage);
            Assert.False(passesValidation);
            Assert.Equal(
                "The element 'Root' has invalid child element 'Child3'. List of possible elements expected: 'Child2'.",
                validationExceptionMessage);
        }

        [Fact]
        public void XmlFilePassesValidation()
        {
            var passesValidation = AsnValidator.Validate("Schema.xsd", "WillPass.xml", out _);
            Assert.True(passesValidation);
        }

        [Fact]
        public void XmlFileWithEscapeCharactersFailsValidation()
        {
            var passesValidation =
                AsnValidator.Validate("Schema.xsd", "EscapeCharacters.xml", out var validationExceptionMessage);
            Assert.False(passesValidation);
            Assert.Equal(
                "The '<' character, hexadecimal value 0x3C, cannot be included in a name. Line 3, position 20.",
                validationExceptionMessage);
        }
    }
}