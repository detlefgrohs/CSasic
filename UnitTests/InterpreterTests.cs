using System;
using CSasic;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests {
    public class InterpreterTests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void InterpreterSimpleTest() {
            var sourceCode = @"
    print ""test""
";
            
            Interpreter.Create().Interpret(sourceCode);

            Console.ReadLine();
        }
    }
}