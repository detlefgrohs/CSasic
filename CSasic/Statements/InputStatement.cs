using CSasic.Values;
using System;

namespace CSasic.Statements {
    public class InputStatement : IStatement {
        private string _name;
        public InputStatement(string name) {
            _name = name;
        }
        public void Execute(Interpreter interpreter) {
            var stringValue = Console.ReadLine();

            if (double.TryParse(stringValue, out var doubleValue))
                interpreter.SetVariable(_name, new NumberValue(doubleValue));
            else
                interpreter.SetVariable(_name, new StringValue(stringValue));
        }
    }
}