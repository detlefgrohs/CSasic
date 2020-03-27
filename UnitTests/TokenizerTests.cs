using CSasic;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests {
    public class TokenizerTests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TokenizerSimpleTest() {
            var tokens = Tokenizer.Create().Tokenize(@"
label: word
123
""String""
");
            

            tokens.Should().NotBeNull();
            tokens.Count.Should().Be(8);
            tokens[0].TokenType.Should().Be(TokenType.Line);
            tokens[1].TokenType.Should().Be(TokenType.Label);
            tokens[1].Text.Should().Be("label");
            tokens[2].TokenType.Should().Be(TokenType.Word);
            tokens[2].Text.Should().Be("word");
            tokens[3].TokenType.Should().Be(TokenType.Line);
            tokens[4].TokenType.Should().Be(TokenType.Number);
            tokens[4].Text.Should().Be("123");
            tokens[5].TokenType.Should().Be(TokenType.Line);
            tokens[6].TokenType.Should().Be(TokenType.String);
            tokens[6].Text.Should().Be("String");
            tokens[7].TokenType.Should().Be(TokenType.Line);

        }
    }
}