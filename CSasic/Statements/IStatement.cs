namespace CSasic.Statements {
    public interface IStatement {
        void Execute(Interpreter interpreter);
    }
}