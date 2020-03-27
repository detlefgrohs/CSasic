namespace CSasic {
    public class Token {
        public TokenType TokenType { get; set; }
        public string Text { get; set; }
        public Token(TokenType tokenType, string text) {
            TokenType = tokenType;
            Text = text;
        }
    }
}
