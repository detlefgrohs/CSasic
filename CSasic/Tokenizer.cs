using System;
using System.Collections.Generic;

namespace CSasic {
    public class Tokenizer {
        private enum TokenizerState { Default, Word, Number, String, Comment }
        private static readonly Dictionary<char, TokenType> SingleCharTokens = new Dictionary<char, TokenType> {
            { '\n', TokenType.Line },
            { '=', TokenType.Equals },
            { '+', TokenType.Operator },
            { '-', TokenType.Operator },
            { '*', TokenType.Operator },
            { '/', TokenType.Operator },
            { '<', TokenType.Operator },
            { '>', TokenType.Operator },
            { '(', TokenType.LeftParen },
            { ')', TokenType.RightParen }
        };
        public static Tokenizer Create() {
            return new Tokenizer();
        }
        private Token _currentToken;
        private TokenizerState _currentTokenizerState;
        private List<Token> _tokens;
        public List<Token> Tokenize(string sourceCode) {
            _tokens = new List<Token>();
            _currentToken = new Token(TokenType.Unknown, string.Empty);
            _currentTokenizerState = TokenizerState.Default;

            foreach (var character in sourceCode) { 
                ReprocessCharacter: // ToDo: Get rid of goto to reprocess characters
                switch (_currentTokenizerState) {
                    case TokenizerState.Default:
                        if (SingleCharTokens.ContainsKey(character)) _tokens.Add(new Token(SingleCharTokens[character], character.ToString()));
                        else if (char.IsLetter(character)) StartToken(TokenizerState.Word, character.ToString());
                        else if (char.IsDigit(character)) StartToken(TokenizerState.Number, character.ToString());
                        else if (character.Equals('"')) StartToken(TokenizerState.String);
                        else if (character.Equals('\'')) StartToken(TokenizerState.Comment);
                        break;
                    case TokenizerState.Word:
                        if (char.IsLetterOrDigit(character)) _currentToken.Text += character;
                        else if (character.Equals(':')) EndToken(TokenType.Label);
                        else {
                            EndToken(TokenType.Word);
                            goto ReprocessCharacter;
                        }
                        break;
                    case TokenizerState.Number: // ToDo: support negative numbers and floating point numbers.
                        if (char.IsDigit(character)) _currentToken.Text += character;
                        else {
                            EndToken(TokenType.Number);
                            goto ReprocessCharacter;
                        }
                        break;
                    case TokenizerState.String:
                        if (character.Equals('"')) EndToken(TokenType.String);
                        else _currentToken.Text += character;
                        break;
                    case TokenizerState.Comment:
                        if (character.Equals('\n')) EndToken(TokenType.Comment);
                        break;
                    default:
                        throw new Exception($"Unknown tokenizer state reached.");
                }
            }
            return _tokens;
        }
        private void StartToken(TokenizerState tokenizerState, string character = "") {
            _currentTokenizerState = tokenizerState;
            _currentToken.Text += character;
        }
        private void EndToken(TokenType tokenType) {
            _currentToken.TokenType = tokenType;
            _tokens.Add(_currentToken);
            _currentTokenizerState = TokenizerState.Default;
            _currentToken = new Token(TokenType.Unknown, string.Empty);
        }
    }
}