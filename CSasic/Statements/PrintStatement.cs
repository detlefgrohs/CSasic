﻿using CSasic.Expressions;
using System;

namespace CSasic.Statements {
    public class PrintStatement : IStatement {
        private IExpression _value;
        public PrintStatement(IExpression value) {
            _value = value;
        }
        public void Execute(Interpreter interpreter) {
            Console.WriteLine(_value.Evaluate(interpreter).ToStr());
        }
    }
}