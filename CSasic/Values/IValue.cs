using CSasic.Expressions;

namespace CSasic.Values {
    public interface IValue : IExpression {
        string ToStr();
        double ToNum();
    }
}