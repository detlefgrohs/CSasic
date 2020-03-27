using CSasic.Values;

namespace CSasic.Expressions {
    public interface IExpression {
        IValue Evaluate(Interpreter interpreter);
    }
}