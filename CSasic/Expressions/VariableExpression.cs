using CSasic.Values;

namespace CSasic.Expressions {
    public class VariableExpression : IExpression {
        private string _name;

        public VariableExpression(string name) {
            _name = name;
        }
        public IValue Evaluate(Interpreter interpreter) {
            if (interpreter.Variables.ContainsKey(_name))
                return interpreter.Variables[_name];
            return new NumberValue(0);
        }
    }
}
